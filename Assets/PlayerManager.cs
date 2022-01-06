using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int Min_Draging; // Draging detection
    Rigidbody Body;
    private Vector3 FirstTouch;
    private Vector3 SecondTouch;
    private Vector3 Direction;
    public float Speed;
    private float DeltaX;
    private GameObject Hostage;
    void Start(){
        Body= GetComponent<Rigidbody>();
    }

    void Update(){
        //if (!InputManager.isStart) return;
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

        
        CheckHoldingHostage();
        CheckThrowingHostage();

    }
    void CheckHoldingHostage(){
        if (InputManager.isHoldingHostage && Hostage==null){
            InputManager.isHoldingHostage=false;
        }
        else if (!InputManager.isHoldingHostage && Hostage!=null){
            Time.timeScale=0.5f;
        }
        else if (InputManager.isHoldingHostage && Hostage!=null){
            Debug.Log("Hold");
            Time.timeScale=1f;
        }
    }
    void CheckThrowingHostage(){
        if (InputManager.isThrowingHostage && Hostage==null){
            InputManager.isThrowingHostage=false;
        }
        else if (!InputManager.isHoldingHostage && Hostage!=null){
            Time.timeScale=0.5f;
        }
        else if (InputManager.isHoldingHostage && Hostage!=null){
            Debug.Log("Hold");
            Time.timeScale=1f;
        }
    }
    void HoldAHostage(){
        Hostage.transform.parent=this.transform;
    }
    void OnTriggerStay(Collider other){
        if (other.CompareTag("Policeman")){
            Hostage=other.gameObject;
        }
    }
    void OnTriggerExit(Collider other){
        if (other.CompareTag("Policeman")){
            Hostage=null;
        }
    }

}
