using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
 
    [SerializeField]
    private Button startButton;

    private void Awake()
    {
        startButton.onClick.AddListener(BeginGame);    
    }

    private void BeginGame()
    {
        SceneManager.LoadScene(1);
    }
}
