using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [HideInInspector]
    public int coinCount=0;

    [SerializeField]
    private TextMeshProUGUI coinCounter;
    private playerControler playercontroler;

    public static CoinManager Instance { get; private set; }
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (coinCount >= 10)
        {
            playercontroler.currentHealth++;
            coinCount -= 10;
        }
    }

    public void UpdateCoinCounter(int value)
    {
        coinCount += value;
        coinCounter.text = coinCount.ToString();
    }
}
