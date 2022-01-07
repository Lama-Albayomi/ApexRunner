using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int Min_Draging; // Draging detection
    Rigidbody Body;
    public Transform HostageGrab;
    private Vector3 FirstTouch;
    private Vector3 SecondTouch;
    public float Speed;
    private float DeltaX;
    private GameObject Hostage;
    private Animator animator;
    private bool Started;
    void Start(){
        Body= GetComponent<Rigidbody>();
        animator=GetComponent<Animator>();
    }

    void Update(){
        // dont start moving untill the game starts 
        if (!InputManager.isStart ) return;

        // stop idel animation and call runnin g animation only once;
        if(!Started){
            animator.SetInteger("State",1);
            Started=true;
        }

        Body.velocity = transform.forward * Speed;

        // Mobile
        if (Input.touchCount>0 &&Input.touches[0].phase==TouchPhase.Moved){
            SecondTouch = Input.touches[0].position;
            DeltaX=transform.position.x+Input.touches[0].deltaPosition.x /100;
        }

        if (DeltaX>2){
            DeltaX=2;
        }else if (DeltaX<-2){
            DeltaX=-2;
        }
        transform.position=new Vector3(DeltaX,transform.position.y,transform.position.z);
        // PC
        if(Input.GetMouseButton(0)){
            FirstTouch = Input.mousePosition;
            //Delta = FirstTouch-SecondTouch;
            SecondTouch = FirstTouch;

            //transform.position=new Vector3(transform.position.x+Delta.x /100,transform.position.y,transform.position.z);
        }

    }
    void HoldAHostage(){
        Hostage=LevelManager.Instance.HoldHostage();
        Instantiate(Hostage,HostageGrab.position,Quaternion.identity,HostageGrab);
        //Hostage.transform.parent=this.transform;
    }
    void OnCollisionEnter( Collision other){
        if (other.transform.CompareTag("Bullet")){
            // set die animation
            animator.SetInteger("State",2);

            other.gameObject.SetActive(false);
            // endGame
            LevelManager.Instance.PlayerDie();

            Body.velocity=Vector3.zero;
        }
        else if (other.transform.CompareTag("Policeman")){
            
            animator.SetInteger("State",2);
            LevelManager.Instance.PlayerDie();
            Body.velocity=Vector3.zero;
        }
    }
    void OnTriggerStay(Collider other){
        if (other.CompareTag("Policeman")){
            if (LevelManager.Instance.CanHostage(other.gameObject)){
                HoldAHostage();
                other.gameObject.SetActive(false);
            }
        }
    }
    void OnTriggerExit(Collider other){
        if (other.CompareTag("Policeman")){
            
        }
    }

}
