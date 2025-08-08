using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public ObstacleData obstacleData;
    public GameObject obstaclePrefab;

    private void Start()
    {
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                int index = y * 10 + x;
                if (obstacleData.obstaclearray[index])
                {
                    //Adjusted this manually as spheres were spawning below the floor!
                    Vector3 spawnPostion = new Vector3(x, 4.95f, y);
                    Instantiate(obstaclePrefab, spawnPostion, Quaternion.identity);
                }
            }
        }
    }
}
