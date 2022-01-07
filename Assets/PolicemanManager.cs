using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicemanManager : MonoBehaviour{
    public GameObject Bullet;
    public Transform ShootPostion;
    private Animator animator;

    
    public float timeBetweenShoots; // stats time
    private float Timer;

    void Start(){
        animator = GetComponent<Animator>();
        Timer= timeBetweenShoots;
    }

    void Update()
    {
        if (!InputManager.isStart) return;

        if(Timer<=0){
            Shoot();
            // reset timer
            Timer=timeBetweenShoots;
        }else{
            Timer-=Time.deltaTime;;
        }
    }
    void Shoot (){
        // Play shooting animation
        animator.SetInteger("State",1);
        Instantiate (Bullet,ShootPostion.position,Quaternion.identity);
        // Play Idle animation
        //animator.SetInteger("State",0);

    }
}
