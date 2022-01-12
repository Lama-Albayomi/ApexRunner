using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour{
    public GameObject BrokenPrefab;
    void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            this.gameObject.SetActive(false);
            Instantiate(BrokenPrefab,this.transform.position,Quaternion.identity);
        }
    }
}
