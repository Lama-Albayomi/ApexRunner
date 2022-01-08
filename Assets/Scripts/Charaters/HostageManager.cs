using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostageManager : MonoBehaviour
{
    public GameObject Bullet;
    public Transform ShootPostion;
    private Animator animator;
    public bool IsThrown;

    public int Bullets; // how many shoots does he has
    public float timeBetweenShoots; // stats time
    private float Timer;
    
    private Vector3 ThrowDirection;

    void Start(){
        animator = GetComponent<Animator>();
        Timer= timeBetweenShoots;
    }

    void Update(){
        if (IsThrown) return;

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
    void Throwing(){
        // Random right or left direction
        int randomThrowingDirection= Random.Range(0,2);
        Rigidbody body = gameObject.AddComponent<Rigidbody>();
        switch(randomThrowingDirection){
            case 0 :
            // right
            ThrowDirection = new Vector3 (1,1,0);
            break;
            case 1 :
            // left
            ThrowDirection = new Vector3 (-1,1,0);
            break;
        }
        //transform.Translate(ThrowDirection*3,Space.World);
        body.AddForce(ThrowDirection*4,ForceMode.Impulse);
        animator.SetInteger("State",2);
        transform.parent=null;
        IsThrown=true;
    }
}
