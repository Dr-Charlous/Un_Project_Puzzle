using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ressources : MonoBehaviour
{
    public bool _hasMoved;

    private void Start()
    {
        _hasMoved = false;
        StartCoroutine(Dead());
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(3);
        if (_hasMoved == false)
            Destroy(gameObject);
        _hasMoved = false;
        StartCoroutine(Dead());
    }
}
