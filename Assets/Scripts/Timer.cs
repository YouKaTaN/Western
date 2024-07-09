using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Action TimeIsOver;

    [SerializeField] private TextMeshProUGUI textTimer;
    [SerializeField] private float timeForLevel;

    [SerializeField] private Image timeProgress;
    private float countdown;
    private bool timerIsStopped;

    public static readonly string BEST_TIME = "best_time";

    private void OnEnable()
    {
        FinishTrigger.PlayerFinished += StopTimer;
    }

    private void OnDisable()
    {
        FinishTrigger.PlayerFinished -= StopTimer;
    }

    private void Start()
    {
        countdown = timeForLevel;
    }

    private void Update()
    {
        CountdownTime();
    }

    private void CountdownTime()
    {
        if (timerIsStopped) return;

        countdown -= Time.deltaTime;

        textTimer.text = countdown.ToString("F0");

        timeProgress.fillAmount = countdown / timeForLevel;

        if (countdown < 0)
        {
            textTimer.text = "0";
            timerIsStopped = true;

            TimeIsOver?.Invoke();
        }
    }

    private void StopTimer()
    {
        timerIsStopped = true;

        float resaultTime = timeForLevel - countdown;

        if (PlayerPrefs.HasKey(BEST_TIME))
        {
            if (resaultTime < PlayerPrefs.GetFloat(BEST_TIME))
            {
                PlayerPrefs.SetFloat(BEST_TIME, resaultTime);
            }
        }
        else
        {
            PlayerPrefs.SetFloat(BEST_TIME, resaultTime);
        }
    }
}
