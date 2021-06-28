using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float speed = 15.0f;
    public float rotationSpeed = 65.0f;
    public float jumpForce = 50f;
    private Rigidbody playerRb;
    private bool isGrounded = true;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        playerRb.AddForce(Vector3.right * speed * Input.GetAxis("Vertical") * Time.deltaTime);
        playerRb.AddForce(Vector3.back * speed * Input.GetAxis("Horizontal") * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.AddForce(Vector3.up * jumpForce);
            isGrounded = false;
        }
        // transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
}
