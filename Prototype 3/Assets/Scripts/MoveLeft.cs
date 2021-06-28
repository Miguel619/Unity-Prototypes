using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    private PlayerController pcScript;
    private float leftBound = -8;
    private int points;

    void Start()
    {
        pcScript = GameObject.Find("Player").GetComponent<PlayerController>();
        points = 0;
    }
    void Update()
    {
        if(pcScript.gameOver == false){
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }else if(gameObject.CompareTag("Obstacle")){
            Destroy(gameObject);
        }
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle")){
            Debug.Log(++pcScript.points);
            Destroy(gameObject);
            
        }
            
    }
}
