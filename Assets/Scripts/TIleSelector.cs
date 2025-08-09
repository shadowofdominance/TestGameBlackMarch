using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelector : MonoBehaviour
{
    public Camera cam;
    public UIManager uimanager;

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //Updating the UI if the mouse hovers over the tile!
        if (Physics.Raycast(ray, out hit))
        {
            TileLocation tile = hit.collider.GetComponentInParent<TileLocation>();
            if (tile != null)
                uimanager.UpdateUI($"Tile: ({tile.x}, {tile.y})");
            else
                uimanager.UpdateUI("Tile Co-Ordinates: --");

        }
    }
}
