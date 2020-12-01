using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    bool hasSpawnedBoss = false;
    bool canPressLever = false;
    public GameObject boss1;
    public GameObject lockedDoor;
    
    public Camera myCamera;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        //spawnn boss
        if (canPressLever && hasSpawnedBoss == false)
        {
            boss1.SetActive(true);
            lockedDoor.SetActive(true);
            hasSpawnedBoss = true;
            Destroy(gameObject);
            myCamera.orthographicSize = 10;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            canPressLever = true;
        }
    }
}
