using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleData", menuName = "Grid/Obstacle Data")]
public class ObstacleData : ScriptableObject
{
    public bool[] obstaclearray = new bool[100];
}
