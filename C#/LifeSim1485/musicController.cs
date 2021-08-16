using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicController : MonoBehaviour
{
    public AudioSource track1;
    public AudioSource track2;
    public AudioSource track3;

    public int selector;
    public int history = 0;


    public void Start()
    {
        selector = Random.Range(0, 3);

        if(selector == 0)
        {
            track1.Play();
            history = 1;
        }else if(selector == 1)
        {
            track2.Play();
            history = 2;
        }
        else if(selector == 2)
        {
            track3.Play();
            history = 3;
        }



    }

    public void Update()
    {
        if(track1.isPlaying == false && track2.isPlaying == false && track3.isPlaying == false)
        {
            selector = Random.Range(0, 3);

            if (selector == 0 && history != 1)
            {
                track1.Play();
                history = 1;
            }
            else if (selector == 1 && history != 2)
            {
                track2.Play();
                history = 2;
            }
            else if (selector == 2 && history != 3)
            {
                track3.Play();
                history = 3;
            }
        }
    }



}
