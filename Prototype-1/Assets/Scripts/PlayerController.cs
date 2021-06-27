using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 25.0f;
    private float turnSpeed = 45.0f;
    void Update()
    {
        // move forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * Input.GetAxis("Vertical"));
        // Turn
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * Input.GetAxis("Horizontal"));
    }
}
