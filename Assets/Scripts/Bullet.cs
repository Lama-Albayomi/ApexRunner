using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position=new Vector3(transform.position.x,transform.position.y,transform.position.z-speed *Time.deltaTime);
    }
    
    void OnBecameInvisible()
    {
        gameObject.SetActive (false);
    }
    
}
