using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstacles : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Transform playerTransform;
    public TileManager tileManager;
    public int lastPrefabID;
    public float spawnZ = -100.0f;
    public int amountOfObstacles;
    public float nextObstacleDistance;
    public float safeZone;
    public List<GameObject> activeObstacles;

    // Start is called before the first frame update
    void Start()
    {
        nextObstacleDistance = 11f;
        spawnZ = -1.0f;
        safeZone = 70f;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeObstacles = new List<GameObject>();
       
        amountOfObstacles = 20;
        Debug.Log("started " + amountOfObstacles);
        for (int i = 0; i < amountOfObstacles; i++)
        {
            
            SpawnObstacle();
        }
       

    }

    // Update is called once per frame
    void Update()
    {


        if (playerTransform.position.z - safeZone > (spawnZ - amountOfObstacles * nextObstacleDistance))
        {
            SpawnObstacle();

            DeleteObstacle();


        }
    }


    public void SpawnObstacle()
    {
        
        GameObject go = Instantiate(obstaclePrefabs[RandomPrefabID()]) as GameObject;
        go.transform.SetParent(transform);
        if(go.tag == "Coin")
        {
            float randomY = Random.Range(-57f, 57f);
            go.transform.position = Vector3.forward * spawnZ;
            float randomX = Random.Range(-57f, 57f);
            go.transform.position = new Vector3(randomX, go.transform.position.y + 1f, go.transform.position.z + randomY);
        }
        else
        {
            float randomY = Random.Range(-57f, 57f);
            go.transform.position = Vector3.forward * spawnZ;
            float randomX = Random.Range(-57f, 57f);
            go.transform.position = new Vector3(randomX, go.transform.position.y, go.transform.position.z + randomY);
        }
        
        spawnZ += nextObstacleDistance;
        activeObstacles.Add(go);

    }


    public void DeleteObstacle()
    {
        Destroy(activeObstacles[0]);
        activeObstacles.RemoveAt(0);
    }


    public int RandomPrefabID()
    {
        if (obstaclePrefabs.Length <= 1)
        {
            return 0;
        }
        else
        {
            int randomID = lastPrefabID;
            while (randomID == lastPrefabID)
            {
                randomID = Random.Range(0, obstaclePrefabs.Length);
            }
            lastPrefabID = randomID;
            return randomID;
        }

    }


}
