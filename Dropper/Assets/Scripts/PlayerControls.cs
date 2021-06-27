using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private float speed = 15.0f;
    private float rotationSpeed = 65.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed * Input.GetAxis("Vertical"));
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }
}
