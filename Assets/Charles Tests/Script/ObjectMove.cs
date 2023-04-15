using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Tilemaps;

public class ObjectMove : MonoBehaviour
{
    public Vector3 position;
    public List<Vector3> move = new List<Vector3>(3);
    public Tilemap tileMap;

    private void Start()
    {
        position = transform.position;
        StartCoroutine(Move(3));
    }

    private void Update()
    {

    }

    IEnumerator Move(int Time)
    {
        move.Clear();
        print("Debut");

        move.Add(transform.position);
        move.Add(tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(transform.position.x, transform.position.y, 0))));


        TileBase tile = tileMap.GetTile(tileMap.LocalToCell(new Vector3(transform.position.x, transform.position.y)));
        if (tile != null)
        {
            string a = tile.ToString();
            string[] word = a.Split(" ");

            Debug.Log($"/{word[0]}/");

            if (word[0] == "TileTest_4")
            {
                move.Add(tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(transform.position.x, transform.position.y + 1, 0))));
                Vector3[] pathArr = move.ToArray();

                transform.DOPath(pathArr, Time);
            }
        }
        yield return new WaitForSeconds(Time);

        print("fin");
        StartCoroutine(Move(Time));
    }
}
