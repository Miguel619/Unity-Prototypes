using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    private GameManager gm;
    private Button button;
    public int difficulty;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        
    }

    void SetDifficulty(){
        Debug.Log(button.gameObject.name + " was clicked");
        gm.StartGame(difficulty);
    }
}
