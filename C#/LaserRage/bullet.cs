using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bullet : MonoBehaviour
{
    public GameObject boom;
    public Text scoreText;
    
    levelManager lvls;

    private void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        lvls = GameObject.Find("EventSystem").GetComponent<levelManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "spiderBoss")
        {
            collision.gameObject.GetComponent<enemyHealthManager>().health = collision.gameObject.GetComponent<enemyHealthManager>().health - 1;
            if(collision.gameObject.GetComponent<enemyHealthManager>().health <= 0)
            {
                lvls.points = lvls.points + 10000;
                scoreText.text = lvls.points + " POINTS";
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "spider")
        {
            lvls.toBossCounter--;
            lvls.points = lvls.points + 1000;
            scoreText.text = lvls.points + " POINTS";
            Destroy(collision.gameObject);
        }




        GameObject effect = Instantiate(boom, transform.position, Quaternion.identity);
        Destroy(effect, 0.3f);
        Destroy(gameObject);

       

    }


}
