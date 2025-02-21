using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBot : BotBase
{
    public EnemyBullet enemyBullet;
    public Transform postShoot;
    public float currentHeath;
    public override void Attack()
    {
      
       var temp = SimplePool2.Spawn(enemyBullet);
         temp.transform.position = postShoot.transform.position;
        temp.Init(target.transform);
    }

    

    public override void Init()
    { 
         currentHeath = heath;
        fillheath.fillAmount = 1;
       isInit = true;
    }

    public override void TakeDame(float dame)
    {
       currentHeath -= dame;
       var percent = (float) currentHeath/heath;
         fillheath.fillAmount = percent;
         if(  fillheath.fillAmount <= 0)
         {
            SimplePool2.Despawn(this.gameObject);
         }
    }

    public override void Update()
    {
       if(isInit)
       {
           agent.SetDestination(target.transform.position);
       }
    }

}
