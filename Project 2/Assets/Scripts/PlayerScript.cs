using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rbody;
    private static int maxSpeed = 4;
    float x, y = 0;
    Vector3 characterScale;
    float characterScaleX;
    public GameObject bullet;
    Animator playerAnimator;
    public bool isDead = false;

    public bool isLookingRight = false;
    public bool isLookingLeft = false;

   
 

    // Start is called before the first frame update
    void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();
        characterScale = transform.localScale;
        characterScaleX = characterScale.x;
        playerAnimator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        x = maxSpeed * Input.GetAxis("Horizontal");
        if (!isDead)
        {
            if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.A)))
            {
                rbody.velocity = new Vector2(x, 0);
            }

        //x axis, key up, stop movement
       
            if ((Input.GetKeyUp(KeyCode.D)) || (Input.GetKeyUp(KeyCode.A)))
            {
                rbody.velocity = new Vector2(0, 0);
            }

            //y axis, key down, movement
            y = maxSpeed * Input.GetAxis("Vertical");
            if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S)))
            {
                rbody.velocity = new Vector2(0, y);
            }

            //y axis, key up, stop movement
            if ((Input.GetKeyUp(KeyCode.W)) || (Input.GetKeyUp(KeyCode.S)))
            {
                rbody.velocity = new Vector2(0, 0);
            }

            //vertical axis movement
            if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.A)))
            {
                rbody.velocity = new Vector2(x, y);
            }

            // Flip the Character
            if (Input.GetAxis("Horizontal") < 0)
            {
                isLookingLeft = true;
                characterScale.x = -characterScaleX;
                isLookingRight = false;
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                isLookingRight = true;
                characterScale.x = characterScaleX;
                isLookingLeft = false;
            }
        }
       
        //change animations
        transform.localScale = characterScale;

        if(rbody.velocity.magnitude > 0 || rbody.velocity.magnitude < 0)
        {
            playerAnimator.SetBool("isMoving", true);
            playerAnimator.SetBool("isIdle", false);
        }
        else
        {
            playerAnimator.SetBool("isIdle", true);
            playerAnimator.SetBool("isMoving", false);
        }
        if (isDead)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            playerAnimator.SetBool("isDead", true);
            rbody.mass = 1000;
        }

       
    }
    //enter portal mechanics
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Portal1")
        {
            StartCoroutine("enterPortal");
        }
        if (collision.gameObject.tag == "Portal2")
        {
            StartCoroutine("endGame");
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //list of enemies that can kill the player
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss1" || collision.gameObject.tag == "Boss2" || collision.gameObject.tag == "eyeSpawn")
        {
            isDead = true;
        }
    }



    IEnumerator enterPortal()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Stage2");
    }

    IEnumerator endGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Text2Scene");
    }


}
