using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicemanManager : MonoBehaviour{
    public GameObject Bullet;
    public Transform ShootPostion;
    private Animator animator;

    void Start(){
        animator = GetComponent<Animator>();
        InvokeRepeating("Shoot",2,3);
    }

    void Update()
    {
        
    }
    void Shoot (){
        // Play shooting animation
        animator.SetInteger("State",1);
        Instantiate (Bullet,ShootPostion.position,Quaternion.identity);
        // Play Idle animation
        //animator.SetInteger("State",0);

    }
}
