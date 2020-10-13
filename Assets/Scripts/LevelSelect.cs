using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelSelect : MonoBehaviour
{
    [SerializeField]
    private string Level;

    private Button lvl;

    private void Awake()
    {
        lvl = GetComponent<Button>();
        lvl.onClick.AddListener(LoadLevel);
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(Level);
    }
}
