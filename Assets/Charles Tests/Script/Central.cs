using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Central : MonoBehaviour
{
    public List<GameObject> ObjectsNeed = new();
    [HideInInspector] public List<bool> ObjectsValid = new();
    [HideInInspector] public bool finish;
    Tilemap tileMap;

    void Start()
    {
        for (int i = 0; i < ObjectsNeed.Count; i++)
        {
            ObjectsValid.Add(false);
        }
        finish = false;

        tileMap = GameObject.FindObjectOfType<Tilemap>();
        //transform.position = tileMap.GetCellCenterWorld(tileMap.LocalToCell(new Vector3(transform.position.x, transform.position.y, transform.position.z)));
    }

    void Update()
    {
        int y = 0;
        for (int i = 0; i < ObjectsNeed.Count; i++)
        {
            if (ObjectsValid[i] == true)
            {
                y += 1;
            }
        }
        if (y == ObjectsNeed.Count)
        {
            finish = true;
            Time.timeScale = 0.1f;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        string[] s = collision.name.Split('(');
        print(s[0]);
        for (int i = 0; i < ObjectsNeed.Count; i++)
        {
            if (s[0] == ObjectsNeed[i].name && ObjectsValid[i] == false)
            {
                ObjectsValid[i] = true;
            }
        }
        Destroy(collision.gameObject);
    }
}
