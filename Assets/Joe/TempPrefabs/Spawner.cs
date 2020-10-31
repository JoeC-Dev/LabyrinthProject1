using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Set In Inspector")]
    public GameObject temp;


    public static GameObject ball; 
    // Start is called before the first frame update
    void Start()
    {
       
        ball = Instantiate<GameObject>(temp);
        ball.transform.position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
