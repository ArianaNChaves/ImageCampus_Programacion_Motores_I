using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    

    private Line _line;
    private int _score;


    private void OnEnable()
    {
        _line.OnLineCollision += UpdateScore;
    }
    private void OnDisable()
    {
        _line.OnLineCollision -= UpdateScore;
    }

    private void Start()
    {
        _score = 0;
    }

    private void UpdateScore()
    {
        _score++;
    }
    
    public int GetScore()
    {
        return _score;
    }
}
