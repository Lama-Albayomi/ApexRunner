using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour{
    public float Speed;

    void Start(){
        
    }

    void Update(){
        
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            other.GetComponent<PlayerManager>().SetSlowSpeed(Speed);
        }
    }
    void OnTriggerExit(Collider other){
        if(other.CompareTag("Player")){
            other.GetComponent<PlayerManager>().SetNormalSpeed();
        }
    }
}
