using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;

    public Transform playerTransform;
    public float spawnZ = -100.0f;
    public float tileLength = 100f;

    public int tilesOnScreen = 10;
    public List<GameObject> activeTiles;
    public float safeZone = 300f;
    public int lastPrefabID = 0;


    // Start is called before the first frame update
    void Start()
    {
        tilesOnScreen = 10;
        safeZone = 300f;
        lastPrefabID = 0;
        tileLength = 100f;
        spawnZ = -100.0f;

        activeTiles = new List<GameObject>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < tilesOnScreen; i++)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - safeZone > (spawnZ - tilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }



    public void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }




    //spawning a tile
    public void SpawnTile(int _index = -1)
    {
        GameObject go = Instantiate(tilePrefabs[RandomPrefabID()]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        go.transform.position = new Vector3(go.transform.position.x, go.transform.position.y -0.5f, go.transform.position.z);
        spawnZ += tileLength;
        activeTiles.Add(go);
    }



    public int RandomPrefabID()
    {
        if(tilePrefabs.Length <= 1)
        {
            return 0;
        }
        else
        {
            int randomID = lastPrefabID;
            while (randomID == lastPrefabID)
            {
                randomID = Random.Range(0, tilePrefabs.Length);
            }
            lastPrefabID = randomID;
            return randomID;
        }
        
    }


}
