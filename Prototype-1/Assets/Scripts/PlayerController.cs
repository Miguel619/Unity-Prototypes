using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 25.0f;
    private float turnSpeed = 45.0f;
    public Camera thirdPerson;
    public Camera firstPerson;

    void Start(){
        thirdPerson.enabled = true;
        firstPerson.enabled = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            thirdPerson.enabled = !thirdPerson.enabled;
            firstPerson.enabled = !firstPerson.enabled;
        }
        // move forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * Input.GetAxis("Vertical"));
        // Turn
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * Input.GetAxis("Horizontal"));
    }
}
