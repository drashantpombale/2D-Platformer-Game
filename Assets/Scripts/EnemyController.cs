using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;
    private Animator animator;
    private bool movingRight = true;
    private Vector3 scale;

    void Start()
    {
        scale = transform.localScale;
    }
    void Update()
    {
        LeftRight();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController pc = collision.gameObject.GetComponent<PlayerController>();
            pc.PlayerHurt();
        }
        else if (collision.gameObject.CompareTag("LeftWayPoint"))
        {
            movingRight = true;
            scale.x = -1f * scale.x;
        }
        else if (collision.gameObject.CompareTag("RightWayPoint"))
        {
            movingRight = false;
            scale.x = -1f *scale.x;
            Debug.Log(collision.gameObject.layer);
        }
    }
        void LeftRight()
    {
        if (movingRight) {
            transform.position += Vector3.right * 3 * speed * Time.deltaTime;
            transform.localScale = scale;
        }
        else {
            transform.position += Vector3.right * 3 * -1f *speed * Time.deltaTime;
            transform.localScale = scale;
        }
    }

}

