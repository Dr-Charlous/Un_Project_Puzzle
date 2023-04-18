using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class MousePlus : MonoBehaviour
{
    [SerializeField] Tilemap tileMap;
    public List<GameObject> BlockPrefab = new(4);
    public GameObject BlockPreview;
    public bool Preview = false;
    public int number;

    void Start()
    {
        tileMap = GameObject.FindObjectOfType<Tilemap>();
        Preview = false;
        BlockPreview.SetActive(Preview);
    }

    public void Update()
    {
        if (Preview == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                number += 1;

                if (number == 4)
                    number = 0;
            }

            BlockPreview.GetComponent<SpriteRenderer>().sprite = BlockPrefab[number].GetComponent<SpriteRenderer>().sprite;

            Color color = BlockPreview.GetComponent<SpriteRenderer>().color;
            color.a = 0.5f;
            BlockPreview.GetComponent<SpriteRenderer>().color = color;

            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 9);
            BlockPreview.transform.position = Camera.main.ScreenToWorldPoint(position);

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 i = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                TileBase tile = tileMap.GetTile(tileMap.LocalToCell(new Vector3(i.x, i.y)));

                if (tile == null) return;

                string a = tile.ToString();
                string[] word = a.Split(" ");
                Debug.Log($"/{word[0]}/");

                if (word[0] == "Sol")
                {
                    GameObject block = Instantiate(BlockPrefab[number], Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.rotation, GameObject.FindGameObjectWithTag("Folder").transform);

                    block.transform.position = tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(block.transform.position.x, block.transform.position.y, 0)));
                }
            }
        }
    }

    public void ActivatePreview()
    {
        Preview = !Preview;
        BlockPreview.SetActive(Preview);
    }
}
