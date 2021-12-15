using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO: We must destroy the previous block
        Debug.Log("We must destroy previous block!");
        if (collision.tag.Equals("Player"))
        {
            LevelManager.SharedInstance.AddLevelBlock();
            LevelManager.SharedInstance.RemoveLevelBlock();
        }
    }
}
