using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Tốc độ của đạn
    private Vector3 direction; // Hướng bay của đạn


    void Start()
    {
        // Lấy vị trí trung tâm màn hình làm mục tiêu
        Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 30);
        Vector3 target = Camera.main.ScreenToWorldPoint(screenCenter);

        // Xác định hướng di chuyển
        direction = (target - transform.position).normalized;

        // Xoay đạn về hướng mục tiêu
        transform.forward = direction; // Đảm bảo đạn luôn nhìn đúng hướng
    }

    void Update()
    {
        // Di chuyển đạn theo hướng đã tính toán
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision != null)
        {
            SimplePool2.Despawn(this.gameObject);
        }
    }
}
