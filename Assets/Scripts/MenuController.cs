using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Button startButton;

    [SerializeField]
    private Button optionsButton;

    [SerializeField]
    private Button exitButton;
    private void Awake()
    {
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    private void OnDestroy()
    {
        startButton.onClick.RemoveListener(StartGame);
        exitButton.onClick.RemoveListener(ExitGame);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    private void OptionsMenu()
    {
        Debug.Log("Click Options");
    }

    private void ExitGame()
    {
        Debug.Log("Exit");
    }

}
