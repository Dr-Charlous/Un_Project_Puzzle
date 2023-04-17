using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Mine : MonoBehaviour
{
    public int Time;
    public GameObject SpawnObject;
    public GameObject Sortie;
    [SerializeField] Tilemap tileMap;

    private void Start()
    {
        tileMap = GameObject.FindObjectOfType<Tilemap>();
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
