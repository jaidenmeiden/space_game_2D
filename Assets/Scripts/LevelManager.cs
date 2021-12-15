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
        int randomIdx = Random.Range(0, AllTheLevelBlocks.Count);
        LevelBlock block;
        Vector3 spawnPosition = Vector3.zero;
        if (CurrentTheLevelBlocks.Count == 0)
        {
            block = Instantiate(AllTheLevelBlocks[0]);
            spawnPosition = LevelStartPosition.position;
        }
        else
        {
            block = Instantiate(AllTheLevelBlocks[randomIdx]);
            spawnPosition = CurrentTheLevelBlocks[CurrentTheLevelBlocks.Count -1].ExitPoint.position;
        }
        
        block.transform.SetParent(this.transform, false);
        Vector3 correction = new Vector3(
            spawnPosition.x - block.StartPoint.position.x,
            spawnPosition.y - block.StartPoint.position.y,
            0
            );
        block.transform.position = correction;
        CurrentTheLevelBlocks.Add(block);
    }

    public void RemoveLevelBlock()
    {
        LevelBlock oldBlock = CurrentTheLevelBlocks[0];
        CurrentTheLevelBlocks.Remove(oldBlock);
        Destroy(oldBlock.gameObject);
    }

    public void RemoveAllLevelBlock()
    {
        while (CurrentTheLevelBlocks.Count > 0)
        {
            RemoveLevelBlock();
        }
    }

    public void GenerateInitialBlocks()
    {
        for (int i = 0; i < 2; i++)
        {
            AddLevelBlock();
        }
    }
}
