using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Player;
    private Rigidbody2D rb;
    private Vector2 movement;

    public float speed = 3f;
    public levelManager manager;
     void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Player = GameObject.Find("Player").GetComponent<Transform>();
        manager = GameObject.Find("EventSystem").GetComponent<levelManager>();
    }

    void Update()
    {
        Vector3 direction = Player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;



    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
            if (ButtonControl.GodMode == false)
            {
                manager.playerHit();
            }
        }
    }




        void FixedUpdate()
    {
        moveCharacter(movement);
    }


    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));

    }


}
