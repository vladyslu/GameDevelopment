using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

 public Rigidbody2D backTire;
   public Rigidbody2D frontTire;

    public LayerMask whatIsGround;
    public Transform groundCheck;
    public Collider2D mainCollider;
    public bool grounded;
    // public JointMotor2D backTire;
    //  public JointMotor2D frontTire;
    public GameObject EndGame;

    //  [SerializeField] KeyCode shootKeyCode;

    public float speed = 2f;
    private float movement;

    // Start is called before the first frame update
    void Start()
    {
        grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
     
           
    }



    private void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.GetComponent<Rigidbody2D>().MoveRotation(gameObject.GetComponent<Rigidbody2D>().rotation + (speed/20) * Time.fixedDeltaTime);
            // transform.Rotate(Vector3.forward * 70f * Time.deltaTime);
        }




        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.GetComponent<Rigidbody2D>().MoveRotation(gameObject.GetComponent<Rigidbody2D>().rotation + (speed/20) * -Time.fixedDeltaTime);
            //transform.Rotate(-Vector3.forward * 70f * Time.deltaTime);
        }


        Bounds colliderBounds = mainCollider.bounds;
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, 0.1f, 0);




        // Check if player is grounded
        //isGrounded = Physics2D.OverlapCircle(groundCheckPos, 0.23f, layerMask);
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsGround);


        if (grounded == true)
        {
            if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow))
            {
                // gameObject.GetComponent<Rigidbody2D>().AddForce(-transform.right * speed * Time.fixedDeltaTime);
                //frontTire.AddForce(-transform.right * speed * Time.fixedDeltaTime);
                backTire.AddForce(-transform.right * speed * Time.fixedDeltaTime);
                // backTire.velocity = new Vector2(-1 * speed, backTire.velocity.y);
                //  frontTire.velocity = new Vector2(-1 * speed, backTire.velocity.y);
                //transform.position += -Vector3.right * speed * Time.fixedDeltaTime;
                //backTire.AddTorque(speed);


                //  frontTire.AddForce(-transform.right * speed * Time.fixedDeltaTime);
                // backTire.jointSpeed(speed);
                // frontTire.jointSpeed = speed;
            }
            if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow))
            {
                // gameObject.GetComponent<Rigidbody2D>().AddForce(-transform.right * speed * Time.fixedDeltaTime);
                backTire.AddForce(transform.right * (speed / 2) * Time.fixedDeltaTime);
                //frontTire.AddForce(transform.right * (speed / 2) * Time.fixedDeltaTime);
                // backTire.jointSpeed(speed);
                // frontTire.jointSpeed = speed;
            }

        }


        if(transform.position.y <= -25.0f)
        {
            EndGame.SetActive(true);
            Time.timeScale = 0;
        }


    }

        void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;

        }
    }


    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;

        }
    }



}

