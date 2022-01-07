using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    void Start(){
        Instance= this;
    }

    void Update(){
        
    }
    public void PlayerDie(){
        InputManager.isStart=false;
    }
}
