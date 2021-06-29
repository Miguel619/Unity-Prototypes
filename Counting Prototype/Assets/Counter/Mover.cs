using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private float bound = 15f;

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed * Input.GetAxis("Horizontal"));
        if(transform.position.z < -bound){
            transform.position = new Vector3(0,0,-bound);
        }
        if(transform.position.z > bound){
            transform.position = new Vector3(0,0,bound);
        }
            
    }
}
