using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (GetLevelStatus("Level1") == LevelStatus.Locked) {
            SetLevelStatus("Level1", LevelStatus.Unlocked);
        }    
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus) {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }
    public LevelStatus GetLevelStatus(string level) {
        LevelStatus levelstatus = (LevelStatus)PlayerPrefs.GetInt(level,0);
        return levelstatus;
    }

    public void LevelComplete() {
        Scene currentscene = SceneManager.GetActiveScene();
        SetLevelStatus(currentscene.name, LevelStatus.Completed);
        int nextsceneindex = currentscene.buildIndex + 1;
        Scene nextscene = SceneManager.GetSceneByBuildIndex(nextsceneindex);
        string nextLevel = "Level" + nextsceneindex;
        SetLevelStatus(nextLevel, LevelStatus.Unlocked);
        Debug.Log("Scene Name: " + currentscene.name + "Scene Index: " + currentscene.buildIndex + " calculated: " + nextsceneindex);
        Debug.Log("Scene Name: " + nextscene.name + "Scene Index: " + nextscene.buildIndex);
        SceneManager.LoadScene(nextLevel);
    }
}   
