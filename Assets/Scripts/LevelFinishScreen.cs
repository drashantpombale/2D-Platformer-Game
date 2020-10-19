using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelFinishScreen : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private PickUpKeys puk;
    public void LevelFinished() {
        Button[] buttons = gameObject.GetComponentsInChildren<Button>();
        Debug.Log("Buttons:" + buttons.Length);
        TextMeshProUGUI[] text = gameObject.GetComponentsInChildren<TextMeshProUGUI>();
        Debug.Log("Keys:"+text.Length);
        buttons[0].onClick.AddListener(NextLevel);
        buttons[1].onClick.AddListener(Exit);
        text[0].text = "Keys Collected: " + puk.GetKeys();
        text[2].text = "Lives Left: " + player.GetLives();
        player.LevelFinish();
        gameObject.SetActive(true);
    }

    private void Exit()
    {
        SceneManager.LoadScene(0);
    }

    private void NextLevel()
    {
        LevelManager.Instance.LevelComplete();
    }


}
