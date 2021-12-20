using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float runningSpeed = 1.5f;
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
        this.transform.position = _startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
