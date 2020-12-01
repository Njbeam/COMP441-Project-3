using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    private int lives = 3;
 
    public Transform target;
    public float speed = .02f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 0)
        {
            Destroy(gameObject);
           
        }
        //target player
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        if (Vector3.Distance(transform.position, target.position) > 1f)
        {
            transform.Translate(new Vector3((speed * Time.deltaTime) / 1.25f, 0, 0));
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //live counter
        if(collision.gameObject.tag == "Bullet")
        {
            lives--;
        }
    }
}
