using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    public PlayerMove playerMove;
    public GameObject Gameover;
    public int hitpoint = 0;

     void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            hitpoint++;
            playerMove.lives = playerMove.lives - 1;
            playerMove.size = playerMove.size - 0.2f;            

            if(playerMove.size < 0.4)
            {
                FindObjectOfType<GameManager>().LostGame();
            }
            else if(playerMove.lives <= 0)
            {
                FindObjectOfType<GameManager>().LostGame();
            }

            FindObjectOfType<AudioManager>().Play("Collided");
        }

    }



     void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Collider>().name == "SilverCoin(Clone)")
        {
            playerMove.points = playerMove.points + 10;
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("Coins");
        }
        else if (collision.GetComponent<Collider>().name == "GoldCoin(Clone)")
        {
            playerMove.points = playerMove.points + 5;
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("Coins");
        }
        else if (collision.GetComponent<Collider>().name == "BronzeCoin(Clone)")
        {
            playerMove.points = playerMove.points + 1;
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("Coins");

        }
        //playerMove.points = playerMove.points + 1;
    }








}
