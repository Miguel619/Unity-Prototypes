using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public ParticleSystem explosion;
    private GameManager gm;
    private Rigidbody targetRb;
    private float minSpeed = 13;
    private float maxSpeed = 18;
    private float maxTorque = 10;
    private float xRange = -4;
    private float yAxis = -6;
    public int pointVal = 5;
    
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(),ForceMode.Impulse);
        transform.position = new Vector3(getRandomX(), yAxis);
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    Vector3 RandomForce(){
        return Vector3.up* Random.Range(minSpeed,maxSpeed);
    }
    Vector3 RandomTorque(){
        return new Vector3 (getTorqueAxis(),getTorqueAxis(),getTorqueAxis());
    }
    float getTorqueAxis(){
        return Random.Range(-maxTorque,maxTorque);
    }
    float getRandomX(){
        return Random.Range(-4, 4);
    }
    private void OnMouseDown()
    {
        if(gm.activeGame){
            Instantiate(explosion, transform.position, explosion.transform.rotation);
            gm.UpdateScore(pointVal);
            Destroy(gameObject);
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if(gameObject.CompareTag("Good"))
            gm.GameOver();
    }
    
}
