using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeManager : MonoBehaviour{

    Rigidbody Body;
    private Vector3 FirstTouch;
    private Vector3 SecondTouch;
    private Vector3 Direction;
    public float Speed;
    private float DeltaX;

    void Awake(){
        Body = GetComponent<Rigidbody>();
    }
    void Update(){
        if (Input.GetMouseButtonDown(0)){
            FirstTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0)){
            SecondTouch = Input.mousePosition;
            DeltaX= (SecondTouch.x-FirstTouch.x)/100;
        }

        if (DeltaX>1){
            DeltaX=1;
        }else if (DeltaX<-1){
            DeltaX=-1;
        }
        transform.position=new Vector3(DeltaX,transform.position.y,transform.position.z +Speed * Time.deltaTime);
    } 

    
    void FixedUpdate() {
        
    }


    void GetInput(){
        
    }
    void UpdateForward(){
        //transform.forward=Vector3.Slerp(transform.forward,TargetForward,Time.deltaTime*SmoothMovement);
    }
}
