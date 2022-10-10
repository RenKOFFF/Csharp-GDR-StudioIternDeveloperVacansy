using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIEndGamePanel : MonoBehaviour
{
    [SerializeField] private RectTransform _uiWinPanel;
    [SerializeField] private RectTransform _uiLosePanel;
    private void Awake()
    {
        Player.OnPlayerDeathEvent.AddListener(ShowLosePanel);
        UiCoinsCounter.OnCoinsOveredEvent.AddListener(ShowWinPanel);
    }

    private void ShowWinPanel()
    {
        _uiWinPanel.gameObject.SetActive(true);
    }

    private void ShowLosePanel()
    {
        _uiLosePanel.gameObject.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
