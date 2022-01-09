using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour{
    public GameObject BrokenPrefab;
    void OnTriggerEnter(Collider other){
        this.gameObject.SetActive(false);
        Instantiate(BrokenPrefab,this.transform.position,Quaternion.identity);
    }
}
