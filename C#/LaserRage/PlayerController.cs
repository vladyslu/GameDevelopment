using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public GameObject aim;
    public bool player2;

    //float aimDir = 90f;
    Vector2 movement;
    int aimDir = -45;

    // Update is called once per frame
    void Update()
    {

        if (player2 && ButtonControl.Player2)
        {
            movement.x = Input.GetAxisRaw("Horizontal2");
            movement.y = Input.GetAxisRaw("Vertical2");


            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

            if ((Input.GetAxis("AimHorizontal") >= 0.7 && Input.GetAxis("AimVertical") <= -0.7))
            {
                // Debug.Log("gamepad up right");
                aimDir = -45;
                aim.transform.eulerAngles = new Vector3(aim.transform.eulerAngles.x, aim.transform.eulerAngles.y, aimDir);

            }
            else if (Input.GetAxis("AimHorizontal") >= 0.7)
            {
                //Debug.Log("gamepad right");
                aimDir = -90;
            }
            else if (Input.GetAxis("AimVertical") <= -0.7)
            {
                // Debug.Log("gamepad up ");
                aimDir = 0;
            }

            if ((Input.GetAxis("AimHorizontal") >= 0.7 && Input.GetAxis("AimVertical") >= 0.7))
            {
                aimDir = -135;
                aim.transform.eulerAngles = new Vector3(aim.transform.eulerAngles.x, aim.transform.eulerAngles.y, aimDir);
            }
            else if (Input.GetAxis("AimVertical") >= 0.7)
            {
                aimDir = -180;
            }

            if ((Input.GetAxis("AimHorizontal") <= -0.7 && Input.GetAxis("AimVertical") >= 0.7))
            {
                aimDir = -225;
                aim.transform.eulerAngles = new Vector3(aim.transform.eulerAngles.x, aim.transform.eulerAngles.y, aimDir);
            }
            else if ((Input.GetAxis("AimHorizontal") <= -0.7))
            {
                aimDir = -270;
            }


            if ((Input.GetAxis("AimHorizontal") <= -0.7 && Input.GetAxis("AimVertical") <= -0.7))
            {
                aimDir = -315;
                aim.transform.eulerAngles = new Vector3(aim.transform.eulerAngles.x, aim.transform.eulerAngles.y, aimDir);
            }


        }
        else if(!player2 && ButtonControl.Player2 == true)
        {
            movement.x = Input.GetAxisRaw("Horizontal1");
            movement.y = Input.GetAxisRaw("Vertical1");


            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

            if ((Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)))
            {
                // Debug.Log("gamepad up right");
                aimDir = -45;
                aim.transform.eulerAngles = new Vector3(aim.transform.eulerAngles.x, aim.transform.eulerAngles.y, aimDir);

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                //Debug.Log("gamepad right");
                aimDir = -90;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                // Debug.Log("gamepad up ");
                aimDir = 0;
            }

            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
            {
                aimDir = -135;
                aim.transform.eulerAngles = new Vector3(aim.transform.eulerAngles.x, aim.transform.eulerAngles.y, aimDir);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                aimDir = -180;
            }

            if ((Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow)))
            {
                aimDir = -225;
                aim.transform.eulerAngles = new Vector3(aim.transform.eulerAngles.x, aim.transform.eulerAngles.y, aimDir);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                aimDir = -270;
            }


            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
            {
                aimDir = -315;
                aim.transform.eulerAngles = new Vector3(aim.transform.eulerAngles.x, aim.transform.eulerAngles.y, aimDir);
            }

        }
        else if(ButtonControl.Player2 == false)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");


            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

            if ((Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)) || (Input.GetAxis("AimHorizontal") >= 0.7 && Input.GetAxis("AimVertical") <= -0.7))
            {
                // Debug.Log("gamepad up right");
                aimDir = -45;
                aim.transform.eulerAngles = new Vector3(aim.transform.eulerAngles.x, aim.transform.eulerAngles.y, aimDir);

            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("AimHorizontal") >= 0.7)
            {
                //Debug.Log("gamepad right");
                aimDir = -90;
            }
            else if (Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("AimVertical") <= -0.7)
            {
                // Debug.Log("gamepad up ");
                aimDir = 0;
            }

            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow) || (Input.GetAxis("AimHorizontal") >= 0.7 && Input.GetAxis("AimVertical") >= 0.7))
            {
                aimDir = -135;
                aim.transform.eulerAngles = new Vector3(aim.transform.eulerAngles.x, aim.transform.eulerAngles.y, aimDir);
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("AimVertical") >= 0.7)
            {
                aimDir = -180;
            }

            if ((Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow)) || (Input.GetAxis("AimHorizontal") <= -0.7 && Input.GetAxis("AimVertical") >= 0.7))
            {
                aimDir = -225;
                aim.transform.eulerAngles = new Vector3(aim.transform.eulerAngles.x, aim.transform.eulerAngles.y, aimDir);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || (Input.GetAxis("AimHorizontal") <= -0.7))
            {
                aimDir = -270;
            }


            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow) || (Input.GetAxis("AimHorizontal") <= -0.7 && Input.GetAxis("AimVertical") <= -0.7))
            {
                aimDir = -315;
                aim.transform.eulerAngles = new Vector3(aim.transform.eulerAngles.x, aim.transform.eulerAngles.y, aimDir);
            }
        }

        aim.transform.eulerAngles = new Vector3(aim.transform.eulerAngles.x, aim.transform.eulerAngles.y, aimDir);


        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

     void FixedUpdate()
    {
       

        





    }
}
