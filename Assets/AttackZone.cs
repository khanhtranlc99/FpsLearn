using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    public BotBase botBase;
    bool isSeeTarget;
 
    public float coolDown ;

   private void OnTriggerStay(Collider other)
    {
       if(other.gameObject.name == "PlayerController")
       {
        isSeeTarget = true;
       
       }
    }

      private void OnTriggerExit(Collider other)
    {
          if(other.gameObject.name == "PlayerController")
       {
        isSeeTarget = false;
     
       }
    }

    private void Update()
    {
       if(isSeeTarget)
       {
             coolDown += 1*Time.deltaTime;
             if(coolDown >= 3)
             {
                 botBase.Attack();
                 coolDown = 0;
             }
                  
       }
    }
}
