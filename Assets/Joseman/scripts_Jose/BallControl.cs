using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float moveSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(hInput, 0.0f, vInput) * moveSpeed * Time.deltaTime);
    }
}
