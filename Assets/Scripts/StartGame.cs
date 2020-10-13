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
    [SerializeField]
    private Button selectLevel;

    private void Awake()
    {
        startButton.onClick.AddListener(BeginGame);
        selectLevel.onClick.AddListener(LevelSelect);
    }

    private void LevelSelect()
    {
        gameObject.transform.Find("LevelSelector").gameObject.SetActive(true);
    }

    private void BeginGame()
    {
        SceneManager.LoadScene(1);
    }
}
