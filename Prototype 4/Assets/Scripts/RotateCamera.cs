using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    
    public float rotateSpeed = 115f;

    void Start()
    {
        
    }
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * Input.GetAxis("Horizontal"));
        
    }
}
