using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Button retryButton;
    [SerializeField]
    private Button exitButton;
    [SerializeField]
    private PlayerController pc;


    public void Gameover() {
        gameObject.SetActive(true);
        retryButton.onClick.AddListener(RetryLevel);
        exitButton.onClick.AddListener(ExitLevel);
    }

    private void ExitLevel()
    {
        pc.LoadLevel(0);
    }

    private void RetryLevel()
    {
        pc.LoadLevel(SceneManager.GetActiveScene().buildIndex);
    }
}
