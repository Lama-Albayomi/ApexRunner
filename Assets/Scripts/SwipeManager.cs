using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeManager : MonoBehaviour{
    private Vector2 StartPos;
    private Vector2 EndPos;
    public int Min_Swipeing; // Draging detection
    private bool FingerDown;


    void Awake(){

    }
    void Update(){

        // Mobile
        if (Input.touchCount>0 &&Input.touches[0].phase==TouchPhase.Began){
            StartPos=Input.touches[0].position;
        }

        if (Input.touchCount>0 && Input.touches[0].phase==TouchPhase.Ended){
            EndPos=Input.touches[0].position;

            // up swipe
            if (EndPos.y>=StartPos.y+Min_Swipeing){
                InputManager.isThrowingHostage=true;
                Debug.Log("Touch Up");
            }

            // down swipe
            else if (EndPos.y<StartPos.y-Min_Swipeing){
                InputManager.isHoldingHostage=true;
                Debug.Log("Touch Down");
            }
        }

        // PC
        if (Input.GetMouseButtonDown(0)){
            StartPos=Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0)){
            EndPos=Input.mousePosition;

            // up swipe
            if (EndPos.y>=StartPos.y+Min_Swipeing){
                InputManager.isThrowingHostage=true;
                Debug.Log("Mouse Up");
            }

            // down swipe
            else if (EndPos.y<StartPos.y-Min_Swipeing){
                InputManager.isHoldingHostage=true;
                Debug.Log("Mouse Down");
            }
        }
    } 
}
