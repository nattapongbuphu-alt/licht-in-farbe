using Unity.Netcode;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerCameraFollow : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            var vcam = GameObject.FindFirstObjectByType<CinemachineCamera>();

            if (vcam != null)
            {
                // ตรวจสอบให้แน่ใจว่าไม่ใส่ค่าตัวเองลงไป
                vcam.Follow = this.transform; 
                vcam.LookAt = null; 
                
                // รีเซ็ตตำแหน่งกล้องเบื้องต้นเพื่อหยุดการไหล
                vcam.transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
            }
        }
    }
}