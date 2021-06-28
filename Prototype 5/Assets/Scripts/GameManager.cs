using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public List<GameObject> targets;
    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    
    private int score;
    private float spawnRate = 1;
    public bool activeGame;
    public void StartGame(int difficulty)
    {
        titleScreen.gameObject.SetActive(false);
        activeGame = true;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(score);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTarget(){
        while(activeGame){
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            
        }
        
    }
    public void UpdateScore(int points){
        score += points;
        if(score < 0)
            score = 0;
        scoreDisplay.text = "Score\n" + score;
    }
    public void GameOver(){
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        activeGame = false;
    }
    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
