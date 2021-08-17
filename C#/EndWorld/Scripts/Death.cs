using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public GameObject player;
    public int checkpoint;

    public GameObject checkpoint3;
    public GameObject checkpoint2;
    public GameObject checkpoint1;

    public PolygonCollider2D map2;
    public PolygonCollider2D map1;

    public AudioSource checkpointAudio;
    public AudioSource losingAudio;
    // Start is called before the first frame update
    void Start()
    {
        checkpoint = 0;
        player = GameObject.Find("Player");
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            losingAudio.Play();
            if (checkpoint == 0)
            {
                player.transform.position = new Vector3(4.5f, -2.62f, 0);
                player.transform.rotation = new Quaternion(0, 0, 0, 0);
            } else if (checkpoint == 3)
            {
                player.transform.position = checkpoint3.transform.position;
                player.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else if (checkpoint == 2)
            {
                player.transform.position = checkpoint2.transform.position;
                player.transform.rotation = new Quaternion(0, 0, 0, 0);
                map2.enabled = false;
                map1.enabled = true;
            }
            else if (checkpoint == 1)
            {
                player.transform.position = checkpoint1.transform.position;
                player.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "checkpoint3")
        {
            checkpointAudio.Play();
            checkpoint = 3;
        }
        if (col.gameObject.tag == "checkpoint2")
        {
            checkpointAudio.Play();
            checkpoint = 2;
        }
        if (col.gameObject.tag == "checkpoint1")
        {
            checkpointAudio.Play();
            checkpoint = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            if (checkpoint == 0)
            {
                player.transform.position = new Vector3(4.5f, -2.62f, 0);
                player.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else if (checkpoint == 3)
            {
                player.transform.position = checkpoint3.transform.position;
                player.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else if (checkpoint == 2)
            {
                player.transform.position = checkpoint2.transform.position;
                player.transform.rotation = new Quaternion(0, 0, 0, 0);
                map2.enabled = false;
                map1.enabled = true;
            }
            else if (checkpoint == 1)
            {
                player.transform.position = checkpoint1.transform.position;
                player.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }

    }
}
