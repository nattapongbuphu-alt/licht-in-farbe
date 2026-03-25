using Unity.Netcode;
using UnityEngine;

public class SpawnManager : MonoBehaviour 
{
    [SerializeField] private NetworkPrefabsList playerList; 
    [SerializeField] private Transform[] spawnPoints;

    void Start()
    {
        if (NetworkManager.Singleton != null)
        {
            NetworkManager.Singleton.ConnectionApprovalCallback = ApprovalCheck;
        }
    }

    private void ApprovalCheck(NetworkManager.ConnectionApprovalRequest request, NetworkManager.ConnectionApprovalResponse response)
    {
        response.Approved = true;
        response.CreatePlayerObject = true;

        int playerIndex = (int)request.ClientNetworkId;
        int spawnIndex = playerIndex % spawnPoints.Length;

        response.Position = spawnPoints[spawnIndex].position;
        response.Rotation = Quaternion.identity;

        if (playerList != null && playerIndex < playerList.PrefabList.Count)
        {
            GameObject prefab = playerList.PrefabList[playerIndex].Prefab;
            NetworkObject netObj = prefab.GetComponent<NetworkObject>();
            
            if (netObj != null)
            {
                // สำหรับ Unity 6 ให้ใช้ PrefabIdHash แทน GlobalObjectIdHash
                response.PlayerPrefabHash = netObj.PrefabIdHash;
            }
        }
    }
}