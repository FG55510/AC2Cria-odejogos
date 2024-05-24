using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text txtScore;
    public TMP_Text txtLife;
    public TMP_Text txtEnd;
    // Start is called before the first frame update
    void Start()
    {
        txtLife.text = "Life: 3";
        txtScore.text = "Score: 0";
        txtEnd.text = "";
    }
    public void ChangeScore (int value){
        txtScore.text = "Score: " + value.ToString();
    }

    public void ChangeLife (int value){
        txtLife.text = "Life: " + value.ToString();
    }

    public void GameOver(){
        txtEnd.text = "Game Over!";
    }

    public void Win(){
        txtEnd.text = "You Win!";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
