using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [Header("Sprites")] 
    [SerializeField] private SpriteRenderer playerOneSpriteRenderer;
    [SerializeField] private SpriteRenderer playerTwoSpriteRenderer;
    [SerializeField] private RawImage playerOneSpriteImage;
    [SerializeField] private RawImage playerTwoSpriteImage;
    
    [Header("Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button colorOnePlayerOneButton;
    [SerializeField] private Button colorTwoPlayerOneButton;
    [SerializeField] private Button colorOnePlayerTwoButton;
    [SerializeField] private Button colorTwoPlayerTwoButton;

    [Header("Panels")] 
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject playersHUDPanel;

    [Header("Silders")] 
    [SerializeField] private Slider playerOneSlider;
    [SerializeField] private Slider playerTwoSlider;
    [SerializeField] private Slider shieldSlider;
    
    [Header("Texts")] 
    [SerializeField] private TextMeshProUGUI playerOneSpeedText;
    [SerializeField] private TextMeshProUGUI playerTwoSpeedText;
    
    [Header("Rect Transforms")] 
    [SerializeField] private RectTransform shieldImageRectTransform;
    
    [Header("Players Scripts")] 
    [SerializeField] private Movement playerOneMovement;
    [SerializeField] private Movement playerTwoMovement;
    [SerializeField] private ShieldSize playerOneShield;
    [SerializeField] private ShieldSize playerTwoShield;
    
    private const int SHIELD_SIZE = 200;
    private const int SPEED_MULTIPLIER = 10;
    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        //player 1
        colorOnePlayerOneButton.onClick.AddListener(OnColorOnePlayerOneButtonClicked);
        colorTwoPlayerOneButton.onClick.AddListener(OnColorTwoPlayerOneButtonClicked);
        playerOneSlider.onValueChanged.AddListener(SetPlayerOneSpeed);
        //player 2
        colorOnePlayerTwoButton.onClick.AddListener(OnColorOnePlayerTwoButtonClicked);
        colorTwoPlayerTwoButton.onClick.AddListener(OnColorTwoPlayerTwoButtonClicked);
        playerTwoSlider.onValueChanged.AddListener(SetPlayerTwoSpeed);
        //Shield
        shieldSlider.onValueChanged.AddListener(SetShieldWidth);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!mainMenuPanel.activeSelf)
            {
                playersHUDPanel.SetActive(false);
                mainMenuPanel.SetActive(true);
            }
            else
            {
                mainMenuPanel.SetActive(false);
                playersHUDPanel.SetActive(true);
            }
        }
        SetTextSpeed();
    }
//-------------------------------------------------- Buttons
    private void OnPlayButtonClicked()
    {
        mainMenuPanel.SetActive(false);
    }
    private void OnExitButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
//Player 1
    private void OnColorOnePlayerOneButtonClicked()
    {
        playerOneSpriteImage.color = Color.cyan;
        playerOneSpriteRenderer.color = Color.cyan;
    }
    private void OnColorTwoPlayerOneButtonClicked()
    {
        playerOneSpriteImage.color = Color.magenta;
        playerOneSpriteRenderer.color = Color.magenta;
    }
//Player 2
    private void OnColorOnePlayerTwoButtonClicked()
    {
        playerTwoSpriteImage.color = Color.red;
        playerTwoSpriteRenderer.color = Color.red;
    }
    private void OnColorTwoPlayerTwoButtonClicked()
    {
        playerTwoSpriteImage.color = Color.yellow;
        playerTwoSpriteRenderer.color = Color.yellow;
    }
    
//-------------------------------------------------- Methods    
    private void SetTextSpeed()
    {
        playerOneSpeedText.text = playerOneMovement.GetPlayerSpeed().ToString("F1");
        playerTwoSpeedText.text = playerTwoMovement.GetPlayerSpeed().ToString("F1");
    }
    private void SetPlayerOneSpeed(float value)
    {
        playerOneMovement.SetPlayerSpeed(value * SPEED_MULTIPLIER);
    }
    private void SetPlayerTwoSpeed(float value)
    {
        playerTwoMovement.SetPlayerSpeed(value * SPEED_MULTIPLIER);
    }
    private void SetShieldWidth(float value)
    {
        shieldImageRectTransform.sizeDelta = new Vector2(value * SHIELD_SIZE, shieldImageRectTransform.sizeDelta.y);
        playerOneShield.SetShieldSize(value);
        playerTwoShield.SetShieldSize(value);
    }

}
