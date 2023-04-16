using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Tilemaps;

public class ObjectMove : MonoBehaviour
{
    [SerializeField] Vector3 position;
    [SerializeField] List<Vector3> move = new List<Vector3>(3);
    [SerializeField] Tilemap tileMap;
    [SerializeField] int Time;
    [SerializeField] bool running = false;

    private void Start()
    {
        position = transform.position;
        tileMap = GameObject.FindObjectOfType<Tilemap>();
        //StartCoroutine(Move(3));
    }

    private void Update()
    {
        Vector3 i = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(1) && tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(i.x, i.y, transform.position.z))) == tileMap.GetCellCenterWorld(tileMap.LocalToCell(transform.position)))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Rail" && running == false)
        {
            running = true;
            move.Clear();

            //move.Add(collision.transform.position);
            move.Add(tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(collision.transform.position.x, collision.transform.position.y, 0))));
            move.Add(tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(transform.position.x, transform.position.y, 0))));

            if (gameObject.name == "Up(Clone)")
            {
                move.Add(tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(transform.position.x, transform.position.y + 1, 0))));
                Vector3[] pathArr = move.ToArray();

                collision.transform.DOPath(pathArr, Time);
                print("why");
            }
            if (gameObject.name == "Down(Clone)")
            {
                move.Add(tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(transform.position.x, transform.position.y - 1, 0))));
                Vector3[] pathArr = move.ToArray();

                collision.transform.DOPath(pathArr, Time);
                print("it");
            }
            if (gameObject.name == "Right(Clone)")
            {
                move.Add(tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(transform.position.x + 1, transform.position.y, 0))));
                Vector3[] pathArr = move.ToArray();

                collision.transform.DOPath(pathArr, Time);
                print("doesn't");
            }
            if (gameObject.name == "Left(Clone)")
            {
                move.Add(tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(transform.position.x - 1, transform.position.y, 0))));
                Vector3[] pathArr = move.ToArray();

                collision.transform.DOPath(pathArr, Time);
                print("work");
            }
            StartCoroutine(wait(3));
            
        }
    }

    IEnumerator wait(int Time)
    {
        yield return new WaitForSeconds(Time);
        running = false;
    }

    //IEnumerator Move(int Time)
    //{
    //    move.Clear();

    //    move.Add(transform.position);
    //    move.Add(tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(transform.position.x, transform.position.y, 0))));


    //    TileBase tile = tileMap.GetTile(tileMap.LocalToCell(new Vector3(transform.position.x, transform.position.y)));
    //    if (tile != null)
    //    {
    //        string a = tile.ToString();
    //        string[] word = a.Split(" ");

    //        Debug.Log($"/{word[0]}/");

    //        if (word[0] == "Up")
    //        {
    //            move.Add(tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(transform.position.x, transform.position.y + 1, 0))));
    //            Vector3[] pathArr = move.ToArray();

    //            transform.DOPath(pathArr, Time);
    //        }
    //        else if (word[0] == "Down")
    //        {
    //            move.Add(tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(transform.position.x, transform.position.y - 1, 0))));
    //            Vector3[] pathArr = move.ToArray();

    //            transform.DOPath(pathArr, Time);
    //        }
    //        else if (word[0] == "Right")
    //        {
    //            move.Add(tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(transform.position.x + 1, transform.position.y, 0))));
    //            Vector3[] pathArr = move.ToArray();

    //            transform.DOPath(pathArr, Time);
    //        }
    //        else if (word[0] == "Left")
    //        {
    //            move.Add(tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(transform.position.x - 1, transform.position.y, 0))));
    //            Vector3[] pathArr = move.ToArray();

    //            transform.DOPath(pathArr, Time);
    //        }
    //    }
    //    yield return new WaitForSeconds(Time);

    //    StartCoroutine(Move(Time));
    //}
}
