using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour{
    public GameObject Animation;
    void Start(){
    }

    void Update(){
        
    }
    void OnTriggerExit(Collider other){
        if(other.transform.CompareTag("Player")){
            InputManager.isStart =false;
            other.gameObject.SetActive(false);
            Animation.SetActive(true);
        }
    }
    
    
}
