using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Modifier : MonoBehaviour
{
    [SerializeField] private Movement[] playersMovement;
    [SerializeField] private ShieldSize[] playersShield;
    [SerializeField] private Line[] lines;
    [SerializeField] private TextMeshProUGUI notificationText;
    
    
    private const string SPEED_NOTIFICATION = "Players Speed Changed!";
    private const string SHIELD_SIZE_NOTIFICATION = "Shields Size Changed!";
    private const string LINE_SIZE_NOTIFICATION = "Lines Size Changed!";
    private void OnEnable()
    {
        Buff.OnBuffDespawn += RandomPower;
    }

    private void Start()
    {
        ClearNotificationText();
    }

    private void OnDisable()
    {
        Buff.OnBuffDespawn -= RandomPower;
    }
    private void RandomPower()
    {
        int random = Random.Range(0, 3);
        switch (random)
        {
            case 0:
                ChangePlayersSpeed();
                ChangeNotificationText(SPEED_NOTIFICATION);
                break;
            case 1:
                ChangeShieldSize();
                ChangeNotificationText(SHIELD_SIZE_NOTIFICATION);
                break;
            case 2:
                ChangeLineSize();
                ChangeNotificationText(LINE_SIZE_NOTIFICATION);
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

    private void ChangeLineSize()
    {
        int changeLineSize = Random.Range(0, 2);
        foreach (var line in lines)
        {
            line.ChangeShieldSizeModifier(changeLineSize);
        }
    }

    private void ChangeNotificationText(string text)
    {
        notificationText.text = text;
        Invoke(nameof(ClearNotificationText), 2.0f);
    }

    private void ClearNotificationText()
    {
        notificationText.text = "";
    }

}
