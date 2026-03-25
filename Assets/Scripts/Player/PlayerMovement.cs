using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 moveInput;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // ใช้ FixedUpdate สำหรับการเคลื่อนที่ที่ใช้ Rigidbody
    void FixedUpdate()
    {
        // ตรวจสอบว่าเป็นเจ้าของตัวละครนี้หรือไม่
        if (!IsOwner) return;

        // ขยับตัวละคร
        rb.velocity = moveInput * moveSpeed;
    }

    // รับค่าจาก New Input System
    public void OnMove(InputValue value)
    {
        if (!IsOwner) return;
        moveInput = value.Get<Vector2>();
    }
}