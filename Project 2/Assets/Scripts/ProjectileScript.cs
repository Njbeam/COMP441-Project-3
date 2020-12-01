using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ProjectileScript : MonoBehaviour
{
    Rigidbody2D rbody;
    public GameObject bulletPrefab;
    public GameObject player;
    private int maxSpeed = 2;
    MSMScript myMSM;
    public bool isShot = false;
    private void Start()
    {
        rbody = gameObject.GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (isShot == false && Input.GetMouseButtonUp(0)) //activate gun
        {
            fireBullet();
            isShot = true;
        }
        
    }
    public void fireBullet() //shoot gun
    {
        Vector2 myPosn = transform.position;
        Vector2 mousePosn = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float x = maxSpeed * (mousePosn.x - transform.position.x);
        float y = maxSpeed * (mousePosn.y - transform.position.y);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);

        Vector2 baseVel = maxSpeed * (mousePosn - myPosn).normalized;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}