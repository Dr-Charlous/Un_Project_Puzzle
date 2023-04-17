using System.Collections.Generic;
using UnityEngine;

public class Facto : MonoBehaviour
{
    public List<GameObject> ObjectsNeed = new();
    public List<bool> ObjectsValid = new();
    public GameObject ObjResult;

    void Start()
    {
        for (int i = 0; i < ObjectsNeed.Count; i++)
        {
            ObjectsValid.Add(false);
        }
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
            Instantiate(ObjResult, transform.position, transform.rotation);
            for (int i = 0; i < ObjectsNeed.Count; i++)
            {
                ObjectsValid[i] = false;
            }
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
                Destroy(collision.gameObject);
            }
        }
    }
}
