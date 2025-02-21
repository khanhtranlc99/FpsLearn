using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class WeaponController : MonoBehaviour
{
    public GameObject bullet;
    public Transform postShoot;
    public GameObject target;
    public Camera camera2;
    public Animator animator;
    bool coolDown;
    public List<LazeAnim> lazeAnims;
    public LazeAnim GetLazeAnim
    {
        get
        {
            foreach (var anim in lazeAnims)
            {
                if(!anim.isOK)
                {
                    anim .isOK = true;
                    return anim;
                }       
            }
            return null;
        }
    }
    
    private void Start()
    {
      
        SimplePool2.Preload(bullet,70);
    }
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(postShoot.position, postShoot.forward * 10f, Color.red);
        if (Input.GetMouseButtonDown(0))
        {
            var tempBullet = SimplePool2.Spawn(bullet);
            tempBullet.transform.position = postShoot.position;
            var tempLaze = GetLazeAnim;
            if(tempLaze != null )
            {
                animator.Play(tempLaze.outStr);
            }
            else
            {
                animator.Play("Weapon");
                foreach (var anim in lazeAnims)
                {
                    anim.isOK = false;
                }
            }
           
        }


       
    }


}
[System.Serializable]
public class LazeAnim
{
    public bool isOK;
    public string inStr;
    public string outStr;

}