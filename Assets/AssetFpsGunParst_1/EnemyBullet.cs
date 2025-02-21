using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
public class EnemyBullet : MonoBehaviour
{
     public float speed = 10f; // Tốc độ của đạn
    private Vector3 direction; // Hướng bay của đạn
    private bool isInit;
    
   public void Init(Transform targetParam)
    {
  
        
        Vector3 target = targetParam.position;

        // Xác định hướng di chuyển
        direction = (target - transform.position).normalized;

        // Xoay đạn về hướng mục tiêu
        transform.forward = direction; // Đảm bảo đạn luôn nhìn đúng hướng





     transform.forward = targetParam.transform.position; // Đảm bảo đạn luôn nhìn đúng hướng
      transform.DOMove(targetParam.transform.position, 0.3f).OnComplete(delegate{
        
        transform.localEulerAngles = Vector3.zero;
         SimplePool2.Despawn(this.gameObject);
         
         });
    }

    
   
}

