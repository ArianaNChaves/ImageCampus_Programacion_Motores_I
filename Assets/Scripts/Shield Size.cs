using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSize : MonoBehaviour
{
    private const int MIN_VARIATION = 2;
    private const float MAX_SIZE = 4;
    private const float MIN_SIZE = 0.5f;
    public void SetShieldSize(float value)
    {
        Vector3 newScale = gameObject.transform.localScale;
        newScale.x = value;
        gameObject.transform.localScale = newScale;
    }

    public void ChangeShieldSizeModifier(float variation)
    {
        if (variation == 0)
        {
            variation = MIN_VARIATION;
        }
        
        float newSize = transform.localScale.x + variation;
        
        if (newSize <= MAX_SIZE && newSize >= MIN_SIZE)
        {
            SetShieldSize(newSize);
        }
    }
    
    public float GetShieldSize()
    {
        return gameObject.transform.localScale.x;
    }
}
