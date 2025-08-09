using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public GridManager gridManager; // reference to your grid
    public ObstacleData obstacleData;

    private bool isMoving = false;

    void Update()
    {
        if (isMoving) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                TileLocation tile = hit.collider.GetComponentInParent<TileLocation>();
                if (tile != null)
                {
                    StartCoroutine(MoveToTile(tile.x, tile.y));
                }
            }
        }
    }

    IEnumerator MoveToTile(int targetX, int targetY)
    {
        // Getting the path for the goal grid
        List<Vector2Int> path = BFSPathfinding((int)transform.position.x, (int)transform.position.z, targetX, targetY);

        if (path == null) 
            yield break; // No path

        isMoving = true;
        foreach (Vector2Int step in path)
        {
            Vector3 targetPos = new Vector3(step.x, transform.position.y, step.y);
            while (Vector3.Distance(transform.position, targetPos) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
        isMoving = false;

        Enemybot enemy = FindObjectOfType<Enemybot>();
        if (enemy != null)
            enemy.Takeaturn(new Vector2Int(targetX, targetY));
    }

    public List<Vector2Int> BFSPathfinding(int startX, int startY, int goalX, int goalY)
    {
        Vector2Int[] direction = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };
        bool[,] visited = new bool[10, 10];
        Dictionary<Vector2Int, Vector2Int> cameFrom = new Dictionary<Vector2Int, Vector2Int>();

        Queue<Vector2Int> queue = new Queue<Vector2Int>();
        Vector2Int start = new Vector2Int(startX, startY);
        Vector2Int goal = new Vector2Int(goalX, goalY);

        queue.Enqueue(start);
        visited[startX, startY] = true;

        while (queue.Count > 0)
        {
            Vector2Int current = queue.Dequeue();
            if (current == goal) break;

            foreach (var dir in direction)
            {
                Vector2Int next = current + dir;

                if (next.x >= 0 && next.x < 10 && next.y >= 0 && next.y < 10)
                {
                    int index = next.y * 10 + next.x;
                    if (!visited[next.x, next.y] && !obstacleData.obstaclearray[index])
                    {
                        queue.Enqueue(next);
                        visited[next.x, next.y] = true;
                        cameFrom[next] = current;
                    }
                }
            }
        }

        if (!cameFrom.ContainsKey(goal)) return null;

        // Rebuild path
        List<Vector2Int> path = new List<Vector2Int>();
        Vector2Int temp = goal;
        while (temp != start)
        {
            path.Add(temp);
            temp = cameFrom[temp];
        }
        path.Reverse();
        return path;
    }
}
