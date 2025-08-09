using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    // Public variables and refernces
    public int width = 10;
    public int height = 10;
    public GameObject tilePrefab1; //used to add the tile prefab in the unity editor. 
    public GameObject tilePrefab2;
    // Public variables end

    void Start()
    {
         GenerateGrid();
    }
    void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Just used odd or even grid number
                GameObject prefabToUse = ((x + y) % 2 == 0) ? tilePrefab1 : tilePrefab2;

                GameObject spawnedTile = Instantiate(prefabToUse, new Vector3(x, 0, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x},{y}";

                TileLocation tile = spawnedTile.GetComponent<TileLocation>();
                tile.SetCoordinates(x, y);
            }
        }
    }
}
