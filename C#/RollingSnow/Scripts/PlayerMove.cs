using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerMove : MonoBehaviour
{
    //player rigidbody
    public Rigidbody rigidBody;

    public new CameraFollow camera;
    public Text SizeText;
    public Text pointsWin;
    


    public GameObject winScreen;

    public float sidewaysForce = 500f;
    public float forwardForce = 4000f;
    public float size;
    float speed;
    public int lives;
    public float oldSize;
    public int points;

    //Managers
    private AudioManager theAudioManager;
    private GameManager theGameManager;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        points = 0;
           sidewaysForce = 2000f;
        forwardForce = 3800f;
        size = 0.5f;
        //speed = 0.1f;
        lives = 3;
        oldSize = size;
    }

    // Update is called once per frame
    //push the object
    void FixedUpdate()
    {
        var prevPosition = new Vector3(0, 0, 0);
        rigidBody.AddForce(0, -40, ((size * 40) + forwardForce * Time.deltaTime));
        size = size + 0.0035f;
        

        Vector3 vec = new Vector3(size, size, size);
        float instantaneousSpeed = Vector3.Distance(transform.position, prevPosition);
         speed = instantaneousSpeed / Time.deltaTime;


        transform.localScale = vec;


        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("r"))
        {
            restart();
        }

    }
    public void Update()
    {
        
        
        camera.offset = new Vector3(camera.offset.x, size + 2, (-size * 2) - 10);
         
        SizeText.text = "Size is " + ((Mathf.Round(size * 100)) / 100.0)  + "\nSpeed: " + ((Mathf.Round(rigidBody.velocity.magnitude * 100)) / 100.0) + "\nLives: " + ((Mathf.Round(lives * 100)) / 100.0) + "\nPoints: " + points;
        pointsWin.text = "You collected " + points + " points.";
        Vector3 vec = new Vector3(size, size, size);





        transform.localScale = vec;
        if (size >= oldSize + 0.5)
        {
            oldSize = size;
            lives++;
            lives++;
        }else if (size >= 5f)
        {
            FindObjectOfType<GameManager>().WonGame();
        }

        ChangeThemeMusic();
    }


    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ChangeThemeMusic()
    {
        if (size < 3f && size > 0f)
        {
            FindObjectOfType<GameManager>().SlowThemeSet();
        }
        if (size >= 4f)
        {
            FindObjectOfType<GameManager>().VeryFastThemeSet();
        }
    }

}
