using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject endLevelScreen;

    [SerializeField]
    private string nextSceneName;

    private Text coinCounter, timeCounter, fullScore;

    private void Start()
    {
        endLevelScreen.SetActive(true);
        coinCounter = endLevelScreen.transform.GetChild(2).GetComponent<Text>();
        timeCounter = endLevelScreen.transform.GetChild(3).GetComponent<Text>();
        fullScore = endLevelScreen.transform.GetChild(4).GetComponent<Text>();
        endLevelScreen.SetActive(false);
    }

    private void OpenEndLevelScreen()
    {
        endLevelScreen.SetActive(true);
        Time.timeScale = 0;
        int coins = CoinManager.Instance.coinCount;
        int coinScore = coins * 10;
        coinCounter.text = "Coins: "+coins+" x 10 = "+ coinScore;

        int timeScore = 0 * - 10;
        timeCounter.text = "Time: 0 x -10 = "+timeScore;

        fullScore.text = "Final Score: "+ coinScore +" + "+ timeScore+" = "+(coinScore+timeScore);
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(nextSceneName);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OpenEndLevelScreen();
        }
    }
}
