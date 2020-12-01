using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Script : MonoBehaviour
{
    public MSMScript myMSM;
    public Transform target;
    public float speed = .95f;
    public int BossLives = 50;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //moving
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        if (Vector3.Distance(transform.position, target.position) > 1f)
        {
            transform.Translate(new Vector3((speed * Time.deltaTime) / 1.25f, 0, 0));
        }

        if (BossLives == 0)
        {
            Destroy(gameObject);
            myMSM.GetComponent<MSMScript>().Boss1Cleared = true;
        }
       
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
           BossLives -= 1;
        }
    }
}
