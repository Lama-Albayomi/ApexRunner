using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public GameObject Hosageprefab;
    public GameObject Hostage;

    void Start(){
        Instance= this;
    }

    void Update(){
        if (InputManager.isHoldingHostage&&Hostage==null){
            InputManager.isHoldingHostage=false;
        }
        if (InputManager.isThrowingHostage&&Hostage==null){
            InputManager.isHoldingHostage=false;
        }
    }
    public void PlayerDie(){
        InputManager.isStart=false;
    }

    public bool CanHostage(GameObject hostage){
        Time.timeScale=0.5f;
        if (InputManager.isHoldingHostage){
            Hostage=hostage;
            return true;
        }
        return false;
    }

    public GameObject HoldHostage(){
        return Hosageprefab;
    }

}
