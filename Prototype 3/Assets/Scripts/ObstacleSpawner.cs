using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnLocation = new Vector3(25,0,0);
    public float startDelay = 2f;
    public float repeatDelay = 2f;
    private PlayerController psScript;

    // Update is called once per frame
    void Start()
    {
        InvokeRepeating("SpawnObject", startDelay, repeatDelay);
        psScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void SpawnObject()
    {
        if(psScript.gameOver == false)
            Instantiate(obstaclePrefab, spawnLocation, obstaclePrefab.transform.rotation);
    }
}
