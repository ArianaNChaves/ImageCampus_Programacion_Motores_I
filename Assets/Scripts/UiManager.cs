using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button openSettingsButton;
    [SerializeField] private Button openCreditsButton;

    [Header("Panels")] 
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject buttonsContainerPanel;

    [Header("Silders")] 
    [SerializeField] private Slider playerOneSlider;
    [SerializeField] private Slider playerTwoSlider;
    
    [Header("Texts")] 
    [SerializeField] private TextMeshProUGUI playerOneSpeedText;
    [SerializeField] private TextMeshProUGUI playerTwoSpeedText;
    
    [Header("Players Movement")] 
    [SerializeField] private Movement playerOneMovement;
    [SerializeField] private Movement playerTwoMovement;
    private void Awake()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        creditsButton.onClick.AddListener(OnCreditsButtonClicked);
        settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        openCreditsButton.onClick.AddListener(OnOpenCreditsButtonClicked);
        openSettingsButton.onClick.AddListener(OnOpenSettingsButtonClicked);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel.activeSelf)
            {
                playerOneMovement.SetCanMove(false);
                playerTwoMovement.SetCanMove(false);
                ResetPauseMenu();
                pausePanel.SetActive(true);
            }
            else
            {
                pausePanel.SetActive(false);
                playerOneMovement.SetCanMove(true);
                playerTwoMovement.SetCanMove(true);
            }
        }

        SetTextSpeed();
        SetPlayersSpeed();
    }
//-------------------------------------------------- Buttons
    private void OnPlayButtonClicked()
    {
        pausePanel.SetActive(false);
        playerOneMovement.SetCanMove(true);
        playerTwoMovement.SetCanMove(true);
    }
    private void OnExitButtonClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    private void OnCreditsButtonClicked()
    {
        creditsPanel.SetActive(true);
        buttonsContainerPanel.SetActive(false);
    }
    private void OnSettingsButtonClicked()
    {
        settingsPanel.SetActive(true);
        buttonsContainerPanel.SetActive(false);
    }
    private void OnOpenSettingsButtonClicked()
    {
        buttonsContainerPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
    private void OnOpenCreditsButtonClicked()
    {
        buttonsContainerPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
    
//-------------------------------------------------- Methods    
    private void SetTextSpeed()
    {
        if (!settingsPanel.activeSelf) return;

        playerOneSpeedText.text = playerOneMovement.GetPlayerSpeed().ToString("F1");
        playerTwoSpeedText.text = playerTwoMovement.GetPlayerSpeed().ToString("F1");
    }

    private void SetPlayersSpeed()
    {
        if (!settingsPanel.activeSelf) return;
        playerOneMovement.SetPlayerSpeed(playerOneSlider.value * 10);
        playerTwoMovement.SetPlayerSpeed(playerTwoSlider.value * 10);
    }

    private void ResetPauseMenu()
    {
        buttonsContainerPanel.SetActive(true);
        creditsPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }
}
