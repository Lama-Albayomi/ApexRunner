using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyColorChanger : MonoBehaviour
{
    public Color32[] Colors;
    // Start is called before the first frame update
    void Start()
    {
        ChangeingColor();
    }
    void ChangeingColor(){
        Camera.main.backgroundColor=Colors[Random.Range(0,Colors.Length)];
    }
}
