using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float speed = 5f;
    [SerializeField] GameObject body;
    [SerializeField] Transform cameraTransform;
    [SerializeField] float mouseSensitivity = 2f; // Độ nhạy chuột

    private float rotationX = 0f; // Góc quay theo trục X (Pitch)

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Khóa chuột vào giữa màn hình
        rigidbody.freezeRotation = true; // Ngăn Rigidbody tự xoay
    }

    void Update()
    {
        // Nhận input di chuyển
        Vector3 moveDirection = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += transform.right;
        }
        moveDirection = moveDirection.normalized * speed;
        rigidbody.velocity = new Vector3(moveDirection.x, rigidbody.velocity.y, moveDirection.z);

        // Nhảy
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Xử lý chuột để xoay nhân vật
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Xoay thân nhân vật theo chiều ngang (Yaw)
        body.transform.Rotate(Vector3.up * mouseX);

        // Xoay camera theo chiều dọc (Pitch), giới hạn góc quay để tránh lật ngược
        rotationX += mouseY; // Đảo dấu để sửa lỗi ngược chiều
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}