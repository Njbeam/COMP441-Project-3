﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private int lives = 5;
    public MSMScript myMSM;
    public Transform target;
    public float speed = .01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lives == 0)
        {
            Destroy(gameObject);
            myMSM.enemyCounterLevel1--;
        }


        //enemy ai to chase player
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        if(Vector3.Distance(transform.position, target.position) > 1f)
        {
            transform.Translate(new Vector3((speed * Time.deltaTime)/1.25f, 0, 0));
        }
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            lives -= 1;
        }
    }
}
