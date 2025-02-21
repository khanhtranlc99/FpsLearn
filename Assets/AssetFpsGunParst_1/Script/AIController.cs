using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
     public List<BotBase> lsBotBase;
    void Start()
    {
        foreach(var item in lsBotBase)
        {
            item.Init();
        }
    }

    
}
