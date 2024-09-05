using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSize : MonoBehaviour
{
    private const float SMALL = 0.5f;
    private const float BIG = 2.0f;
    private const float MEDIUM = 1.0f;

    private ShieldSizeVariation _lastShieldSizeVariation;
    
    private enum ShieldSizeVariation
    {
        Default,
        Medium,
        Big,
        Small
    }

    private void Start()
    {
        _lastShieldSizeVariation = ShieldSizeVariation.Small;
    }

    public void SetShieldSize(float value)
    {
        Vector3 newScale = gameObject.transform.localScale;
        newScale.x = value;
        gameObject.transform.localScale = newScale;
    }

    public void ChangeShieldSizeModifier(float change)
    {
        switch (change)
        {
            case 0:
                if (_lastShieldSizeVariation != ShieldSizeVariation.Medium)
                {
                    SetShieldSize(MEDIUM);
                    _lastShieldSizeVariation = ShieldSizeVariation.Medium;
                }
                else
                {
                    ChangeShieldSizeModifier(1);
                }
                break;
            case 1:
                if (_lastShieldSizeVariation != ShieldSizeVariation.Big)
                {
                    SetShieldSize(BIG);
                    _lastShieldSizeVariation = ShieldSizeVariation.Big;
                }
                else
                {
                    ChangeShieldSizeModifier(2);
                }

                break;
            case 2:
                if (_lastShieldSizeVariation != ShieldSizeVariation.Small)
                {
                    SetShieldSize(SMALL);
                    _lastShieldSizeVariation = ShieldSizeVariation.Small;
                }
                else
                {
                    ChangeShieldSizeModifier(0);
                }
                break;
            default:
                Debug.LogError("Shield Size - Change Shield Size Modifier - Out of range");
                break;
        }
        Debug.Log($"Size: {_lastShieldSizeVariation}");
    }
    
}
