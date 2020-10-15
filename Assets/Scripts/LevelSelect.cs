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
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(Level);
        switch(levelStatus){
            case LevelStatus.Locked:
                Debug.Log("Level is locked");
                break;
            case LevelStatus.Unlocked:
                SceneManager.LoadScene(Level);
                break;
            case LevelStatus.Completed:
                SceneManager.LoadScene(Level);
                break;
        }
    }
}
