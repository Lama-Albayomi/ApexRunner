using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public GameObject Hosageprefab;
    public GameObject[] Levels;
    public bool Hostage= false;

    void Start(){
        Instance= this;
        Instantiate(Levels[Random.Range(0,Levels.Length)]);
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
        UiManager.instanse.ActiveTryAgainScreen();
    }
    public void PlayerEndlevel(){
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
