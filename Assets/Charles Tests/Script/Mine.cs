using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Mine : MonoBehaviour
{
    public int Time;
    public GameObject SpawnObject;
    [HideInInspector] public GameObject Sortie;
    Tilemap tileMap;

    private void Start()
    {
        tileMap = GameObject.FindObjectOfType<Tilemap>();
        //transform.position = tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(transform.position.x, transform.position.y, transform.position.z)));

        GameObject block = Instantiate(SpawnObject, Sortie.transform.position, SpawnObject.transform.rotation);
        block.transform.position = tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(block.transform.position.x, block.transform.position.y, 0)));

        StartCoroutine(spawn(Time));
    }

    IEnumerator spawn(int Time)
    {
        yield return new WaitForSeconds(Time);
        GameObject block = Instantiate(SpawnObject, Sortie.transform.position, SpawnObject.transform.rotation);
        block.transform.position = tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(block.transform.position.x, block.transform.position.y, 0)));
        StartCoroutine(spawn(Time));
    }
}
