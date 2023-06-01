using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] TMP_Text gameScoreUI;
    [SerializeField] TMP_Text gameFinishedScoreUI;
    [SerializeField] TMP_Text timerUI;
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject gameFinishUI;

    public void ShowTitle(bool show)
    {
        titleUI.SetActive(show);
    }

    public void ShowGameUI(bool show)
    {
        gameUI.SetActive(show);
    }

    public void ShowGameFinish(bool show)
    {
        gameFinishUI.SetActive(show);
    }

    public void SetScore(int score)
    {
        gameScoreUI.text = score.ToString();
    }

    public void SetScoreFinished(int score)
    {
        gameFinishedScoreUI.text = score.ToString();
    }

    public void SetTimer(float timer)
    {
        timerUI.text = timer.ToString("F1");
    }
}
