using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public SO_GameData gameData;
    public static UIManager ui;
    public GameObject player;

    public string fase2;
    public string fase3;

    public int score;
    public int life;

    void Awake () {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void LoadScene(string Fase){
        SceneManager.LoadScene(Fase);
    }
    // Start is called before the first frame update
    void Start()
    {
        ui = FindAnyObjectByType<UIManager>();
        score = gameData.score;
        ui.ChangeScore(score);
        life = gameData.life;
        ui.ChangeLife(life);
    }

    public void SetScore(int value){

        gameData.score += value;
        score = gameData.score;
        ui.ChangeScore(score);
        if (score == 2) {
            LoadScene(fase2);
        }
        if (score == 4)
        {
            LoadScene(fase3);
        }
        if(score == 5)
        {
            Victory();
        }
    }

    public void SetLife(int value){
        gameData.life += value;
        life = gameData.life;
        ui.ChangeLife(life);
        if(life<=0){
            Destroy(player);
            Lose();

        }
    }

    public void Lose(){
        ui.GameOver();
    }

    public void Victory(){
        ui.Win();
    }
    
    
}
