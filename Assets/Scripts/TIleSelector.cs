using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TIleSelector : MonoBehaviour
{
    public Camera cam;
    public UIManager uimanager;

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            TileLocation tile = hit.collider.GetComponentInParent<TileLocation>();
            if (tile != null)
            {
                uimanager.UpdateTileInfo($"Tile: ({tile}")
            }
    }
}
