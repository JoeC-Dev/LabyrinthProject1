using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TrapWall : MonoBehaviour
{
    public GameObject trapWall;


    void Awake()
    {
        trapWall.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
            
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ball")
        {
            trapWall.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
