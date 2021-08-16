using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] BoxCollider2D bc;

    Vector2 cubeSize;
    Vector2 cubeCenter;

    private float nextActionTime = 1f;
    public float period = 150f;
   
    public bool boss;
    private bool playerInside = false;
    public levelManager lvlManager;


    private void Awake()
    {
        Transform cubeTrans = bc.GetComponent<Transform>();
        cubeCenter = cubeTrans.position;

        // Multiply by scale because it does affect the size of the collider
        cubeSize.x = cubeTrans.localScale.x * bc.size.x;
        cubeSize.y = cubeTrans.localScale.y * bc.size.y;
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            playerInside = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            playerInside = false;
        }

    }
   


    void Start()
    {

        if (boss == true)
        {
            DoSomething();
        }
        else
        {

            StartCoroutine(DoEveryFiveSeconds());
        }
    }

    IEnumerator DoEveryFiveSeconds()
    {
        while (true)
        {
            DoSomething();
            yield return new WaitForSeconds(Random.Range(1.0f, 4.0f));
            
        }
    }

    // happens every 0.5 seconds
     void DoSomething()
    {
        if (playerInside == false && lvlManager.toBossCounter >= 0)
        {
            

            GameObject go = Instantiate(prefab, GetRandomPosition(), Quaternion.identity);
            Color background = new Color(
    Random.Range(0f, 1f),
    Random.Range(0f, 1f),
    Random.Range(0f, 1f)
);

            Renderer rend = go.GetComponent<Renderer>();

            //Call SetColor using the shader property name "_Color" and setting the color to red
            rend.material.SetColor("_Color", background);
        }
    }




    private Vector2 GetRandomPosition()
    {
        // You can also take off half the bounds of the thing you want in the box, so it doesn't extend outside.
        // Right now, the center of the prefab could be right on the extents of the box
        Vector2 randomPosition = new Vector2(Random.Range(-cubeSize.x / 2, cubeSize.x / 2), Random.Range(-cubeSize.y / 2, cubeSize.y / 2));

        return cubeCenter + (randomPosition);
    }
}
