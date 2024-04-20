using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake() {  instance = this; }

    void Start() //Used to initialize the text element from the Unity Editor
    {
        GetComponent<UnitButtonScript>().Init();
    }
}
