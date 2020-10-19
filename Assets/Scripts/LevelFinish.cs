using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    [SerializeField]
    LevelFinishScreen lf;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null) {
            Debug.Log("Congratulations, you finished the level!!, On to the next level.");
            lf.LevelFinished();

        }
    }
}
