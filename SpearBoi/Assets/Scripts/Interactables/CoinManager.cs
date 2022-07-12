using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [HideInInspector]
    public int coinCount;

    [SerializeField]
    private TextMeshProUGUI coinCounter;

    public static CoinManager Instance { get; private set; }
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateCoinCounter(int value)
    {
        coinCount += value;
        coinCounter.text = coinCount.ToString();
    }
}
