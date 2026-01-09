using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public int currentLevel = 1;
    public float mapLength = 20f;

    private float currentX = 0;

    // Level prefaps
    [SerializeField] private List<GameObject> maps;

    private void Start()
    {
        SpawnLevel();
    }

    public void SpawnLevel()
    {
        if (currentLevel > maps.Count)
        {
            SceneMoveManager.Instance.MoveToMenuScene();
            return;
        }

        Instantiate(maps[currentLevel - 1], new Vector3(currentX, 0, 0), Quaternion.identity);
        currentX += mapLength;
        currentLevel++;
    }

    public void SpawnLevel(int level)
    {
        Instantiate(maps[level - 1], new Vector3(currentX, 0, 0), Quaternion.identity);
        currentX += mapLength;
        currentLevel = level;
        currentLevel++;
    }
}
