using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject RestartButton;
    public char status = 'f';
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
        GameObject.Find("EnemyManager").GetComponent<EnemyManager>().Restart();
        if(status == 'f')
          GameObject.Find("TowerManager").GetComponent<TowerManager>().RestartDefeat();
        RestartButton.SetActive(false);
    }

    public void GameEnds(char st)
    {
        status = st;
        RestartButton.SetActive(true);
    }
}
