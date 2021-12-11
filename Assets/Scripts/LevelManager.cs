using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager SharedInstance;
    public List<LevelBlock> AllTheLevelBlocks = new List<LevelBlock>();
    public List<LevelBlock> CurrentTheLevelBlocks = new List<LevelBlock>();
    public Transform LevelStartPosition;

    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateInitialBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLevelBlock()
    {
        
    }

    public void RemoveLevelBlock()
    {
        
    }

    public void RemoveAllLevelBlock()
    {
        
    }

    public void GenerateInitialBlocks()
    {
        for (int i = 0; i < 2; i++)
        {
            AddLevelBlock();
        }
    }
}
