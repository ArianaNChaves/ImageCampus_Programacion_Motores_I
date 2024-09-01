using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Line : MonoBehaviour
{
    [SerializeField] private string scorePointTo;
    public event Action<string> OnLineCollision;
    
    
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            OnLineCollision?.Invoke(scorePointTo);
        }
    }
}