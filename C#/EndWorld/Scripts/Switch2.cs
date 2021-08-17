using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch2 : MonoBehaviour
{
    public PolygonCollider2D map1;

    // Start is called before the first frame update
    void Start()
    {

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            map1.enabled = false;
        }
    }




    // Update is called once per frame
    void Update()
    {

    }
}
