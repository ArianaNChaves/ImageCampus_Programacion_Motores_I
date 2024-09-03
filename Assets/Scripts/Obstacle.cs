using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    public void StartDespawn(float delay)
    {
        Invoke(nameof(Despawn), delay);
    }
    private void Despawn()
    {
        ObstacleSpawn.OnObstacleDespawned?.Invoke();
    }
}
