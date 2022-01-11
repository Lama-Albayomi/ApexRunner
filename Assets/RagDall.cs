using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagDall : MonoBehaviour{
    public float ThrowForce=100;
    public Rigidbody Body;
    void Start(){
        //Body= GetComponent<Rigidbody>();
        Throwing();
    }

    public void Throwing(){
        foreach (Rigidbody body in this.transform.GetComponentsInChildren<Rigidbody>())
        {
            body.velocity=Vector3.forward*Random.RandomRange(5,20);
        }
        //Body.AddForce(Vector3.forward*ThrowForce);
        //Body.velocity=Vector3.forward*ThrowForce;
    }
}
