using Unity.Netcode;
using UnityEngine;
using Unity.Cinemachine; // สังเกตการสะกดชื่อ Namespace ใหม่

public class CameraFollow : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        // เช็คว่าเป็นตัวละครของเรา (เครื่องนี้) เท่านั้น
        if (IsOwner)
        {
            // หา Cinemachine Camera ใน Scene
            var vcam = GameObject.FindAnyObjectByType<CinemachineCamera>();

            if (vcam != null)
            {
                // สั่งให้กล้องตามตัวละครนี้
                vcam.Follow = transform;
            }
        }
    }
}