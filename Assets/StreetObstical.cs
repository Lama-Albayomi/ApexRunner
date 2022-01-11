using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetObstical : MonoBehaviour{
    PlayerManager player;
    void Start(){
        

    }
    void Update(){
        

    }
    public IEnumerator PushPlayer(){
        player.GoBack();
        yield return new WaitForSeconds(0.7f);
        player.GoForword();
    }
    void OnCollisionEnter(Collision other){
        if (other.transform.CompareTag("Player")){
            player = other.transform.GetComponent<PlayerManager>();
            StartCoroutine(PushPlayer());
        }
    }

    /*
    void OnTriggerStay(Collider other){
        if (other.CompareTag("Player")){
                other.GetComponent<PlayerManager>().GoBack();
            if (PlayerHit){
                other.GetComponent<PlayerManager>().GoBack();
            Debug.Log("OnTriggerStay");
            }
        }
    }
    */
}
