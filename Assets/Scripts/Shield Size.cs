using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSize : MonoBehaviour
{
    private const int SHIELD_DIVISOR = 2;
    public void SetShieldSize(float value)
    {
        Vector3 newScale = gameObject.transform.localScale;
        newScale.x = value/SHIELD_DIVISOR;
        gameObject.transform.localScale = newScale;
    }
}
