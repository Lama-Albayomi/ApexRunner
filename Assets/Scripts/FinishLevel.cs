using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour{
    public GameObject Animation;
    void Start(){
        Camera.main.backgroundColor=Random.ColorHSV();
    }

    void Update(){
        
    }
    void OnTriggerExit(Collider other){
        if(other.transform.CompareTag("Player")){
            other.gameObject.SetActive(false);
            Animation.SetActive(true);
        }
    }
}
