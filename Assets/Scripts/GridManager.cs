using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    // Public variables
    public int width = 10;
    public int height = 10;
    public GameObject tilePrefab; //used to add the tile prefab in the unity editor. 
    // Public variables end
    void Start()
    {
         GenerateGrid();
    }
    void GenerateGrid()
    {
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                GameObject spawnedTile = Instantiate(tilePrefab, new Vector3(x,0,y), Quaternion.identity);
                spawnedTile.name = $"Tile {x},{y}";

                TileLocation tile = spawnedTile.GetComponent<TileLocation>();
                tile.SetCoordinates(x,y);
            }
        }
    }
}
