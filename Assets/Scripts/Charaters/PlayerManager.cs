using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int Min_Draging; // Draging detection
    Rigidbody Body;
    public Transform HostageGrab;
    [SerializeField]
    private float Speed;
    private float InitialSpeed;

    // Private
    private float DeltaX;
    private GameObject Hostage;
    private GameObject IsNearPoliceman;
    private Animator animator;
    private bool Started;
    private Vector3 FirstTouch;
    private Vector3 SecondTouch;
    void Start(){
        Body= GetComponent<Rigidbody>();
        animator=GetComponent<Animator>();
        InitialSpeed = Speed;
    }

    void Update(){
        // dont start moving untill the game starts 
        if (!InputManager.isStart ) return;
        
        MoveLeftAndRight();
        
        if (IsNearPoliceman!=null){
            if (LevelManager.Instance.CanHoldAHostage() && Hostage == null){
                HoldAHostage();
            }
        }
        if(Hostage != null){
            if (LevelManager.Instance.CanThrowHostage()){
                ThrowTheHostage();
            }
        }
        
        
        
    }

    void MoveLeftAndRight(){
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

         // PC
        if (Input.GetMouseButtonDown(0)){
            SecondTouch= Input.mousePosition;
        }
        if(Input.GetMouseButton(0)){
            FirstTouch = Input.mousePosition;
            DeltaX = transform.position.x+(FirstTouch.x-SecondTouch.x)/100;
            SecondTouch = FirstTouch;

        }

        if (DeltaX>2){
            DeltaX=2;
        }else if (DeltaX<-2){
            DeltaX=-2;
        }
        transform.position=new Vector3(DeltaX,transform.position.y,transform.position.z);
       
    }
    void HoldAHostage(){
        Hostage = Instantiate(LevelManager.Instance.GetHostage()
        ,HostageGrab.position,Quaternion.identity,HostageGrab);

        IsNearPoliceman.gameObject.SetActive(false);
        IsNearPoliceman=null;
    }
    void ThrowTheHostage(){
        Hostage.SendMessage("Throwing");
        Hostage=null;
    }
    public void SetSlowSpeed(float Speed){
        this.Speed=Speed;
    }
    public void SetNormalSpeed(){
        Speed=InitialSpeed;
    }
    void OnCollisionEnter( Collision other){
        if (other.transform.CompareTag("Bullet")){
            // set die animation

            other.gameObject.SetActive(false);
            if (Hostage==null){
                EndGame();
            }else{

            }
            
        }
        else if (other.transform.CompareTag("Policeman")){
            if (Hostage==null){
                EndGame();
            }else{

            }
        }
    }
    void EndGame(){

        animator.SetInteger("State",2);
            // endGame
        LevelManager.Instance.PlayerEndlevel();
        Body.velocity=Vector3.zero;
    }
    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Policeman")){
            IsNearPoliceman=other.gameObject;
        } 
    }
    void OnTriggerStay(Collider other){
        
    }
    void OnTriggerExit(Collider other){
        
    }

}
