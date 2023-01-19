using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private int maxTime;

    private float timer;
    private Text timeDisplay;

    [HideInInspector]
    public int timeLeft;

    public static TimeManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        timeDisplay = transform.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        timeLeft = Mathf.RoundToInt(maxTime - timer);
        timeDisplay.text = timeLeft.ToString();

        if (timer>maxTime)
        {
            LevelManager.Instance.Retry();
        }
    }
}
