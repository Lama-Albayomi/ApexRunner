using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostageManager : MonoBehaviour
{
    public GameObject Bullet;
    public Transform ShootPostion;
    private Animator animator;

    public int Bullets; // how many shoots does he has
    public float timeBetweenShoots; // stats time
    private float Timer;

    void Start(){
        animator = GetComponent<Animator>();
        Timer= timeBetweenShoots;
    }

    void Update(){
        
        if(Bullets>0){
            if(Timer<=0){
                Shoot();
                Timer=timeBetweenShoots;
            }else{
                Timer-=Time.deltaTime;;
            }
        }
    }
    void Shoot (){
        // Play shooting animation\
        animator.SetInteger("State",1);
        Instantiate (Bullet,ShootPostion.position,Quaternion.identity);
        Bullets--;
        // Play Idle animation
        //animator.SetInteger("State",0);

    }
}
