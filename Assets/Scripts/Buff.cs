using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    public static event Action OnBuffDespawn;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            Despawn();
            Debug.Log("BUFFOOOO");
        }
    }
    
    private void Despawn()
    {
        OnBuffDespawn?.Invoke();
    }
}
