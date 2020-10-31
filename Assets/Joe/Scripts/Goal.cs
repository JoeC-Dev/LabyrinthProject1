using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    static public bool correctH = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ball")
        {
            Goal.correctH = true;
        }
    }
}
