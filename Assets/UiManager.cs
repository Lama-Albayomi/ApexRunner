using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject StartScreen;
    public void StartGame(){
        StartScreen.SetActive(false);
        InputManager.isStart=true;
    }

    void switchScreen(){

    }
}
