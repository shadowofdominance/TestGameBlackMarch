using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybot : MonoBehaviour, InterfaceAi
{
    public float moveSpeed = 3f;
    public ObstacleData obstacleData;
    public PlayerController player; // reference to your player
    public GridManager gridManager;

    private bool isMoving = false;

    public void Takeaturn(Vector2Int playerPos)
    {
        if (isMoving) 
            return;
        StartCoroutine(MoveTowardsPlayer(playerPos));
    }

    IEnumerator MoveTowardsPlayer(Vector2Int playerPos)
    {
        // Possible goal tiles: 4 adjacent spots
        Vector2Int[] goalOffsets = {
            Vector2Int.up, Vector2Int.down,
            Vector2Int.left, Vector2Int.right
        };

        List<Vector2Int> possibleGoals = new List<Vector2Int>();
        foreach (var offset in goalOffsets)
        {
            Vector2Int testPos = playerPos + offset;
            if (testPos.x >= 0 && testPos.x < 10 && testPos.y >= 0 && testPos.y < 10)
            {
                int index = testPos.y * 10 + testPos.x;
                if (!obstacleData.obstaclearray[index])
                {
                    possibleGoals.Add(testPos);
                }
            }
        }

        // Find shortest path to any of these possible goals
        List<Vector2Int> bestPath = null;
        foreach (var goal in possibleGoals)
        {
            List<Vector2Int> path = player.BFSPathfinding((int)transform.position.x, (int)transform.position.z, goal.x, goal.y);
            if (path != null && (bestPath == null || path.Count < bestPath.Count))
                bestPath = path;
        }

        if (bestPath == null) 
            yield break; // Now enemy can reach player over here!

        isMoving = true;
        foreach (Vector2Int step in bestPath)
        {
            Vector3 targetPos = new Vector3(step.x, transform.position.y, step.y);

            transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z));
            while (Vector3.Distance(transform.position, targetPos) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
                yield return null;
            }
            transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z));
        }
        isMoving = false;
    }
}
