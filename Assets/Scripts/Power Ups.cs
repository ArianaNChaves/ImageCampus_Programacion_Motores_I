using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUps : MonoBehaviour
{
    [SerializeField] private Movement[] playersMovement;
    [SerializeField] private ShieldSize[] playersShield;
    
    private const int SPEED_VARIATION = 5;
    private const float SHIELD_SIZE_VARIATION = 2.0f;
    private void OnEnable()
    {
        Buff.OnBuffDespawn += RandomPower;
    }
    private void OnDisable()
    {
        Buff.OnBuffDespawn -= RandomPower;
    }
    private void RandomPower()
    {
        int random = Random.Range(0, 2);
        switch (random)
        {
            case 0:
                ChangePlayersSpeed();
                break;
            case 1:
                ChangeShieldSize();
                break;
            default:
                Debug.Log("Random fuera de rango");
                break;
        }
    }
    private void ChangePlayersSpeed()
    {
        float newSpeed = Random.Range(-SPEED_VARIATION, SPEED_VARIATION);
        foreach (var playerSpeed in playersMovement)
        {
            playerSpeed.ChangeSpeedModifier(newSpeed);
        }
    }
    private void ChangeShieldSize()
    {
        float newShieldSize = Random.Range(-SHIELD_SIZE_VARIATION, SHIELD_SIZE_VARIATION);
        foreach (var playerShield in playersShield)
        {
            playerShield.ChangeShieldSizeModifier(newShieldSize);
        }
    }

}
