using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Tilemaps;

public class ObjectMove : MonoBehaviour
{
    List<Vector3> move = new List<Vector3>(3);
    Tilemap tileMap;
    [SerializeField] int Time;
    bool running = false;
    [Header("Direction :")]
    [SerializeField] bool Up = false;
    [SerializeField] bool Right = false;
    [SerializeField] bool Down = false;
    [SerializeField] bool Left = false;

    bool _hasMoved;

    private void Start()
    {
        tileMap = GameObject.FindObjectOfType<Tilemap>();
        transform.position = tileMap.GetCellCenterWorld(tileMap.LocalToCell(transform.position));
    }

    private void Update()
    {
        Vector3 i = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(1) && tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(i.x, i.y, transform.position.z))) == tileMap.GetCellCenterWorld(tileMap.LocalToCell(transform.position)))
        {
            Destroy(gameObject);
        }
    }



    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ressources" && running == false)
        {
            running = true;
            move.Clear();

            move.Add(tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(transform.position.x, transform.position.y, 0))));

            if (Up)
            {
                move.Add(tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(transform.position.x, transform.position.y + 1, 0))));
                Vector3[] pathArr = move.ToArray();

                collision.transform.DOPath(pathArr, Time);
                collision.gameObject.GetComponent<Ressources>()._hasMoved = true;
            }
            if (Down)
            {
                move.Add(tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(transform.position.x, transform.position.y - 1, 0))));
                Vector3[] pathArr = move.ToArray();

                collision.transform.DOPath(pathArr, Time);
                collision.gameObject.GetComponent<Ressources>()._hasMoved = true;

            }
            if (Right)
            {
                move.Add(tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(transform.position.x + 1, transform.position.y, 0))));
                Vector3[] pathArr = move.ToArray();

                collision.transform.DOPath(pathArr, Time);
                collision.gameObject.GetComponent<Ressources>()._hasMoved = true;

            }
            if (Left)
            {
                move.Add(tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(transform.position.x - 1, transform.position.y, 0))));
                Vector3[] pathArr = move.ToArray();

                collision.transform.DOPath(pathArr, Time);
                collision.gameObject.GetComponent<Ressources>()._hasMoved = true;

            }
            StartCoroutine(wait(3));
            
        }
        else if (collision.tag == "Rail")
        {
            Destroy(collision.gameObject);
        }
    }

    IEnumerator wait(int Time)
    {
        yield return new WaitForSeconds(Time);
        running = false;
    }
}
