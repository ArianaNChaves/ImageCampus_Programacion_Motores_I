using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    public static event Action OnBuffDespawn;
    
    public void StartDespawn(float delay)
    {
        Invoke(nameof(Despawn), delay);
    }

    private void Despawn()
    {
        OnBuffDespawn?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            Despawn();
            Debug.Log("BUFFOOOO");
        }
    }
}
