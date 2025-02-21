using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public abstract class BotBase : MonoBehaviour
{
    public Image fillheath;
    public float heath;
    public bool isInit;
    public NavMeshAgent agent;
    public GameObject target;


   
    public abstract void Init();
    public abstract void Attack();
    public abstract void TakeDame(float dame);
    public virtual void Update()
    {

    }
}
