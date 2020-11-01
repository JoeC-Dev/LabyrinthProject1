using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Set In Inspector")]
    public GameObject temp;

    //static game object so it can be called in the control script
    public static GameObject ball; 
    //instantiates a ball at the beginning of the round at the position of the spawner
    void Start()
    {
       
        ball = Instantiate<GameObject>(temp);
        ball.transform.position = this.transform.position;
    }
}
