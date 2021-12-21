using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float runningSpeed = 1.5f;
    public int enemyDamage = 10;
    private Rigidbody2D rigidBody;
    private Vector3 _startPosition;
    public bool facingRight = false;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        _startPosition = this.transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        //this.transform.position = _startPosition;
    }

    private void FixedUpdate()
    {
        float currentRunningSpeed = runningSpeed;
        if (facingRight)
        {
            currentRunningSpeed = runningSpeed;
            this.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            currentRunningSpeed = -runningSpeed;
            this.transform.eulerAngles = Vector3.zero;
        }

        if (GameManager.SharedInstance.currentGameState == GameState.InGame)
        {
            rigidBody.velocity = new Vector2(currentRunningSpeed, rigidBody.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            collision.GetComponent<PlayerController>().CollectHealth(-enemyDamage);
            return;
        }
        else
        {
            if (collision.tag.Equals("Coin"))
            {
                return;
            }
            else
            {
                this.facingRight = !facingRight;
            }
        }
    }
}
