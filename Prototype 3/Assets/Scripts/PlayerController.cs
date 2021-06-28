using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody playerRb;
    public ParticleSystem explosion;
    public ParticleSystem dirt;
    public AudioClip crashSound;
    public AudioClip jumpSound;
    private AudioSource playerAudio;
    private Vector3 initialGravity;
    public float jumpForce;
    private float leftBound = -7;
    public int points = 0;
    // private float gravityModifier = 1f;
    
    private bool isOnGround = true;
    public bool gameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        initialGravity = Physics.gravity;
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            Physics.gravity = initialGravity * Random.Range(.45f,1.35f);
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            isOnGround = false;
            playerAnimator.SetBool("Death_b", false);
            dirt.Stop();
        }
        if(transform.position.x < leftBound){
            Destroy(gameObject);
            gameOver = true;
            Debug.Log("Game Over!");
        }
        playerAnimator.SetBool("Jump_trig", !isOnGround);    
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground")){
            isOnGround = true;
            dirt.Play();
        }
            
        if(collision.gameObject.CompareTag("Obstacle")){
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            playerAudio.PlayOneShot(crashSound, 1.0f);
            explosion.Play();
            dirt.Stop();
        }
            
    }
    
}
