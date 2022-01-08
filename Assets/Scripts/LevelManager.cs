using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public GameObject Hosageprefab;
    public bool Hostage= false;

    void Start(){
        Instance= this;
    }

    void Update(){
        if (InputManager.isHoldingHostage&& !Hostage){
            InputManager.isHoldingHostage=false;
        }

        if (InputManager.isThrowingHostage&& !Hostage){
            InputManager.isThrowingHostage=false;
        }
    }
    public void PlayerDie(){
        InputManager.isStart=false;
    }

    public bool CanHoldAHostage(){
        Time.timeScale=0.5f;
        if (InputManager.isHoldingHostage){
            Hostage=true;
            return true;
        }
        return false;
    }
    public void DidNotHoldTheHostage(){
        Time.timeScale=1f;
    }

    public GameObject GetHostage(){
        Time.timeScale=1f;
        return Hosageprefab;
    }

    public bool CanThrowHostage(){
        if (InputManager.isThrowingHostage){
            Hostage=false;
            return true;
        }
        return false;
    }

}
