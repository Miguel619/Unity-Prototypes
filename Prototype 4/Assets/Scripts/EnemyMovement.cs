using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody enemyRb;
    private GameObject player;
    private SpawnManager sm;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        sm = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    
    void Update()
    {
        Vector3 lookDirection = player.transform.position - transform.position;
        enemyRb.AddForce(lookDirection.normalized * speed);
        if(transform.position.y < -10f){
            sm.explode();
            Destroy(gameObject);
        }
        if(sm.gameOver == true){
            Destroy(gameObject);
        }
    }
}
