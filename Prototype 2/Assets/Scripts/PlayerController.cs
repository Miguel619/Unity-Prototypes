using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 30.0f;
    public int xPosition = 10;
    public GameObject cookie;
    
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed * Input.GetAxis("Horizontal"));
        if(transform.position.x < -xPosition)
        {
            transform.position = new Vector3(-xPosition, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xPosition)
        {
            transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(cookie, transform.position, cookie.transform.rotation);
        }
    }
}
