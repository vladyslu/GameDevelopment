using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch1 : MonoBehaviour
{
    public PolygonCollider2D map2;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            map2.enabled = true;
        }
    }








    // Update is called once per frame
    void Update()
    {
        
    }
}
