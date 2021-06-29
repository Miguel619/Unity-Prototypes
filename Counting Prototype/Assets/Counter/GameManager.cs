using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public Text scoreText;
    public Text livesText;
    public Text gameOverText;
    public TextMeshProUGUI startText;
    public TextMeshProUGUI restart;
    public int score;
    public int lives = 5;
    private float spawnRate;
    private bool activeGame;
    public void StartGame()
    {
        startText.gameObject.SetActive(false);
        restart.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        score = 0;
        lives = 5;
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;
        spawnRate = Random.Range(0.1f, 1f);
        activeGame = true;
        StartCoroutine(Spawner(spawnRate));
    }

    // Update is called once per frame
    void Update()
    {
        if(lives <= 0){
            activeGame = false;
            gameOverText.gameObject.SetActive(true);
        }
    }

    IEnumerator Spawner(float time){
        while(activeGame){
            Instantiate(ball, new Vector3(0,12, Random.Range(-15, 15)), ball.transform.rotation);
            yield return new WaitForSeconds(time);
        }
    }
    public void addPoint(){
        if(activeGame){
            score++;
            scoreText.text = "Score: " + score;
        }
        
    }
    public void subLives(){
        if(activeGame){
            lives--;
            livesText.text = "Lives: " + lives;
        }
        
    }


}
