using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDall : MonoBehaviour{
    public float ThrowForce=100;
    private float Force;
    public Rigidbody Body;
    void Start(){
        //Body= GetComponent<Rigidbody>();
        Throwing();
    }

    public void Throwing(){
        foreach (Rigidbody body in this.transform.GetComponentsInChildren<Rigidbody>()){
            Force = Random.Range(ThrowForce-5,ThrowForce+5);
            body.velocity=Vector3.forward*Force;
        }
        //Body.AddForce(Vector3.forward*ThrowForce);
        //Body.velocity=Vector3.forward*ThrowForce;
    }
}
