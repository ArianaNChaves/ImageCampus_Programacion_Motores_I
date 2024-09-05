using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Line : MonoBehaviour
{
    public event Action<string> OnLineCollision;
    
    [SerializeField] private string scorePointTo;
    [SerializeField] private PoolController poolController;
    
    private LineSizeVariation _lastLineSizeVariation;
    
    private const float NORMAL = 8.4f;
    private const float SMALL = 3.5f;
    
    private enum LineSizeVariation
    {
        Default,
        Normal,
        Small,
    }

    private void Start()
    {
        _lastLineSizeVariation = LineSizeVariation.Normal;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            OnLineCollision?.Invoke(scorePointTo);
            poolController.ReturnToPool(ObjectType.Ball, other.gameObject);
        }
    }
    
    public void SetLineSize(float value)
    {
        Vector3 newScale = gameObject.transform.localScale;
        newScale.y = value;
        gameObject.transform.localScale = newScale;
    }
    
    public void ChangeShieldSizeModifier(float change)
    {
        switch (change)
        {
            case 0:
                if (_lastLineSizeVariation != LineSizeVariation.Normal)
                {
                    SetLineSize(NORMAL);
                    _lastLineSizeVariation = LineSizeVariation.Normal;
                }
                else
                {
                    ChangeShieldSizeModifier(1);
                }
                break;
            case 1:
                if (_lastLineSizeVariation != LineSizeVariation.Small)
                {
                    SetLineSize(SMALL);
                    _lastLineSizeVariation = LineSizeVariation.Small;
                }
                else
                {
                    ChangeShieldSizeModifier(0);
                }

                break;
            default:
                Debug.LogError("Line Size - Change Line Size Modifier - Out of range");
                break;
        }
        Debug.Log($"Line Size: {_lastLineSizeVariation}");
    }
}
