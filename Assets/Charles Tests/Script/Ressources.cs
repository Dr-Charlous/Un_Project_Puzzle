using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ressources : MonoBehaviour
{
    public bool _hasMoved;

    private void Start()
    {
        _hasMoved = false;
    }

    private void Update()
    {
        if (_hasMoved == true)
            StopCoroutine(Dead());
        else if (_hasMoved == false)
            StartCoroutine(Dead());
    }

    void OnCollisionExit()
    {
        _hasMoved = false;
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(3);
        if (_hasMoved == false)
            Destroy(gameObject);
    }
}
