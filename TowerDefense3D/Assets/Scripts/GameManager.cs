using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject RestartButton;
    void Start()
    {
        RestartButton.SetActive(false);
    }

    public void StartButtonClick(){
        GameObject.Find("EnemyManager").GetComponent<EnemyManager>().StartGame();
        StartButton.SetActive(false);
    }

    public void RestartButtonClick(){
        StartButton.SetActive(true);
        RestartButton.SetActive(false);
    }

    public void GameEnds()
    {
        RestartButton.SetActive(true);
    }
}
