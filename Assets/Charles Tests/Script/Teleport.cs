using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Tilemaps;

public class Teleport : MonoBehaviour
{
    List<Vector3> move = new List<Vector3>(3);
    Tilemap tileMap;
    [SerializeField] int Time;
    bool running = false;
    [SerializeField] bool Enter = false;
    [SerializeField] bool Exit = false;
    [SerializeField] GameObject EnterObj;
    [SerializeField] GameObject ExitObj;
    [Header("Direction :")]
    [SerializeField] bool Up = false;
    [SerializeField] bool Right = false;
    [SerializeField] bool Down = false;
    [SerializeField] bool Left = false;

    bool _hasMoved;

    private void Start()
    {
        tileMap = GameObject.FindObjectOfType<Tilemap>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (Enter == true && collision.gameObject.CompareTag("Ressources"))
        {
            collision.transform.DOKill();
            collision.transform.position = ExitObj.transform.position;
        }
        if (Exit == true && collision.gameObject.CompareTag("Ressources") && running == false)
        {
            running = true;
            move.Clear();

            move.Add(new Vector3(transform.position.x, transform.position.y, 0));

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
    }

    IEnumerator wait(int Time)
    {
        yield return new WaitForSeconds(Time);
        running = false;
    }
}