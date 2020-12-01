using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Script : MonoBehaviour
{
    public MSMScript myMSM;
    public Transform target;
    
    public int Boss2Lives = 150;

    public Sprite B2Stage1, B2Stage2, B2Stage3;

    SpriteRenderer mySR;
    Animator B2Animator;



    // Start is called before the first frame update
    void Start()
    {
        B2Animator = GetComponent<Animator>();
        mySR = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //moving
        //transform.LookAt(target.position);
        //transform.Rotate(new Vector3(0, -90, 0), Space.Self);

      

        if (Boss2Lives == 0)
        {
            Destroy(gameObject);
            
            myMSM.GetComponent<MSMScript>().Boss2Cleared = true;
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Boss2Lives -= 1;
        }
    }

  

}
