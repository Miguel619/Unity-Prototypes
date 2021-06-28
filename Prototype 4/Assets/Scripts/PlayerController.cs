using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject powerUpIndicator;
    private GameObject focal;
    private Rigidbody playerRb;
    private SpawnManager sm;
    public AudioClip[] clash;
    private AudioSource playerSound;
    public float speed = 5f;
    private float powerUpStrength = 10f;
    private bool isPoweredUp = false;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focal = GameObject.Find("Focal Point");
        sm = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        playerSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        playerRb.AddForce(focal.transform.forward * Input.GetAxis("Vertical") * speed);
        powerUpIndicator.transform.position = transform.position;
        if(transform.position.y < -10f){
            sm.setGameOver();
            Debug.Log("Game Over Man!");
            
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Power Up"))
        {
            Destroy(other.gameObject);
            isPoweredUp = true;
            powerUpIndicator.SetActive(true);
            StartCoroutine(PowerUpTimer());
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && isPoweredUp){
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            playerSound.PlayOneShot(clash[Random.Range(2,4)], 1f);
        }else{
            playerSound.PlayOneShot(clash[Random.Range(0,2)], 1f);
        }
    }
    IEnumerator PowerUpTimer(){
        yield return new WaitForSeconds(7);
        isPoweredUp = false;
        powerUpIndicator.SetActive(false);
    }
}
