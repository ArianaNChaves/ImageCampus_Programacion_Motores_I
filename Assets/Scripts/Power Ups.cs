using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerUps : MonoBehaviour
{
    [SerializeField] private Movement[] playersMovement;
    [SerializeField] private ShieldSize[] playersShield;
    
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
        int changeSpeed = Random.Range(0, 3);
        foreach (var playerSpeed in playersMovement)
        {
            playerSpeed.ChangeSpeedModifier(changeSpeed);
        }
    }
    private void ChangeShieldSize()
    {
        int changeShieldSize = Random.Range(0, 3);
        foreach (var playerShield in playersShield)
        {
            playerShield.ChangeShieldSizeModifier(changeShieldSize);
        }
    }

}