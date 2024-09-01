using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerOneScoreText;
    [SerializeField] private TextMeshProUGUI playerTwoScoreText;
    
    private int _scorePlayerOne;
    private int _scorePlayerTwo;

    private void Start()
    {
        _scorePlayerOne = 0;
        _scorePlayerTwo = 0;
        UpdateScoreText(playerOneScoreText, _scorePlayerOne);
        UpdateScoreText(playerTwoScoreText, _scorePlayerTwo);
    }
    
    public void UpdateScoreText(string player)
    {
        switch (player)
        {
            case "PlayerOne":
                _scorePlayerOne++;
                UpdateScoreText(playerOneScoreText, _scorePlayerOne);
                break;
            case "PlayerTwo":
                _scorePlayerTwo++;
                UpdateScoreText(playerTwoScoreText, _scorePlayerTwo);
                break;
            default:
                Debug.LogError("Player HUD - UpdateScoreText - string player not recognized");
                break;
        }
    }

    private void UpdateScoreText(TextMeshProUGUI scoreText, int score)
    {
        scoreText.text = score.ToString();
    }
    
}
