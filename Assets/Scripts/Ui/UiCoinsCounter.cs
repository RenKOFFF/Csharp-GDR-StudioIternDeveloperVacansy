using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class UiCoinsCounter : MonoBehaviour
{
    private TextMeshProUGUI _textUI;
    private int _coinsCount;
    private int _maxCoinsSpawned;

    public static UnityEvent OnCoinsOveredEvent = new UnityEvent(); 

    private void Start()
    {
        _textUI = GetComponent<TextMeshProUGUI>();
        UpdateText();
    }
    private void OnEnable() 
    {
        Coin.OnPlayerTookTheCoinEvent.AddListener(ChangeCoinsCount);
        ObjectSpawner.OnObjectIsSwawnedEvent.AddListener(ChangeLeftCoins);
    }

    private void ChangeCoinsCount()
    {
        _coinsCount++;
        UpdateText();
    }

    private void UpdateText()
    {
        if (_textUI != null) _textUI.text = $"Coins: {_coinsCount} \nCoins Left: {_maxCoinsSpawned - _coinsCount}";

        if (_maxCoinsSpawned == _coinsCount) OnCoinsOveredEvent.Invoke();
    }

    private void ChangeLeftCoins(ObjectSpawner sender, int coinsCount)
    {
        if (sender.tag == "CoinsSpawner")
        {
            _maxCoinsSpawned = coinsCount;
            UpdateText();
        }
    }
}
