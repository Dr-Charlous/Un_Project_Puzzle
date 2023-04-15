using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpriteTileDetect : MonoBehaviour
{
    public Tilemap tilemap;

    void Update()
    {
        Vector3 i = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        TileBase tile = tilemap.GetTile(tilemap.LocalToCell(new Vector3(i.x, i.y)));
        if (tile != null) { }
        //print(tile.ToString());
    }
}
