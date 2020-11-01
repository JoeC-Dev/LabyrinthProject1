using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    //boolean for is goal is touched 
    static public bool correctH = false;

    //when the ball collides with a goal set the bool to trrue
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ball")
        {
            Goal.correctH = true;
        }
    }
}
