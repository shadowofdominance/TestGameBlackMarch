using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLocation : MonoBehaviour
{
    public int x;
    public int y;

    public void SetCoordinates(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
