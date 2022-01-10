using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public enum Screen {Start, TryAgain, EndLevel};
public class UiManager : MonoBehaviour
{
    
    public static UiManager instanse;
    
    public  GameObject EndScreen;
    public  GameObject StartScreen;
    public  GameObject TryAgainScreen;
    void Awake(){
        instanse = this;
    }
    
    public void StartGame(){
        StartScreen.SetActive(false);
        InputManager.isStart=true;
    }
    public void ActiveEndScreen(){
        EndScreen.SetActive(true);
    }
    public void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }public void ActiveTryAgainScreen(){
        TryAgainScreen.SetActive(true);
    }
    public void ReLodeScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
