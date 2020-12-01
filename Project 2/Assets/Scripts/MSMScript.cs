using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MSMScript : MonoBehaviour
{

    public GameObject bullet;
    private static int maxSpeed = 12;
    public int enemyCounterLevel1 = 8;
    public GameObject lvl1Door;
    public GameObject enemy;
    public GameObject portal1;
    public GameObject portal2;

    int chanceToSpawn;
    int chanceToSpawnBoss;

    public bool cleared = false;
    public bool Boss1Cleared = false;
    public bool Boss2Cleared = false;
    public GameObject eyeSpawn;
    public GameObject boss2;
    public GameObject player;

    public string sceneName;
    Scene currentScene;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (!cleared)
        {
            //spawn basic enemy
            chanceToSpawn = Random.Range(0, 100);
            if (chanceToSpawn == 0)
            {
                spawnEnemy();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            //shoot gun
            spawnBullet();
        }
        if (enemyCounterLevel1 == 0)
        {
            Destroy(lvl1Door);
            cleared = true;
        }
        if (Boss1Cleared)
        {
            portal1.SetActive(true);
        }
        if (Boss2Cleared)
        {
            portal2.SetActive(true);
            GameObject[] eyes;
            eyes = GameObject.FindGameObjectsWithTag("eyeSpawn");
            foreach (GameObject eye in eyes)
            {
                Destroy(eye);
            }
        }
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        chanceToSpawnBoss = Random.Range(0, 100);

        if (currentScene.name == "Stage2" && chanceToSpawnBoss == 0 && GameObject.FindGameObjectWithTag("Boss2") != null)
        {
            if (player.GetComponent<PlayerScript>().isDead == false)
            {
                //spawn boss2 enemies
                Instantiate(eyeSpawn, new Vector2(-5f, 37.9f), Quaternion.identity);
                Instantiate(eyeSpawn, new Vector2(6f, 37.8f), Quaternion.identity);
            }
        }
        if (player.GetComponent<PlayerScript>().isDead == true)
        {
            //play animation
            StartCoroutine("isDead");
        }

        //shoot gun
        void spawnBullet()
        {
            if (player.GetComponent<PlayerScript>().isDead == false)
            {
                if (player.GetComponent<PlayerScript>().isLookingRight)
                {
                    Instantiate(bullet, new Vector2(player.transform.position.x + 0.52f, player.transform.position.y - 0.35f), Quaternion.identity);
                }
                if (player.GetComponent<PlayerScript>().isLookingLeft)
                {
                    Instantiate(bullet, new Vector2(player.transform.position.x - 0.52f, player.transform.position.y - 0.35f), Quaternion.identity);
                }
            }

        }

        void spawnEnemy()
        {
            //spawn zombies
            if (player.GetComponent<PlayerScript>().isDead == false)
            {
                Instantiate(enemy, new Vector3(0, 6.5f, 0), Quaternion.identity);
                Instantiate(enemy, new Vector3(0, -6.5f, 0), Quaternion.identity);

            }
        }
    }

    IEnumerator isDead()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("LoadingScene");
    }
}

