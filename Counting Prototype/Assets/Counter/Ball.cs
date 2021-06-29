using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private GameManager gm;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();   
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player")){
            // add points
            gm.addPoint();
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("Ground")){
            // count to lives
            gm.subLives();
            Destroy(gameObject);
        }

    }
    
}
