using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    private AudioSource finalBoom;
    public GameObject sign;
    private float spawnRange = 9f;
    public int enemyCount;
    public int wave = 1;
    public bool gameOver = false;
    void Start()
    {
        spawnEnemies(wave);
        finalBoom = GetComponent<AudioSource>();
    }
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyMovement>().Length;
        if(enemyCount == 0 && !gameOver){
            wave++;
            spawnEnemies(wave);
        }
        
    }

    private Vector3 GenerateSpawn(){
        float spawnX = Random.Range(-spawnRange, spawnRange);
        float spawnZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnX,0,spawnZ);
        return spawnPos;
    }
    void spawnEnemies(int i){
        for(int j = 0; j < i; j++){
            Instantiate(enemyPrefab, GenerateSpawn(), enemyPrefab.transform.rotation);
        }
        spawnPowerUp();
    }
    void spawnPowerUp(){
        Instantiate(powerUpPrefab, GenerateSpawn(), powerUpPrefab.transform.rotation);
    }
    public void setGameOver(){
        finalBoom.Play();
        gameOver = true;
        sign.SetActive(true);
    }
    public void explode(){
        finalBoom.Play();
    }
}
