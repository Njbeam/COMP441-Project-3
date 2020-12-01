using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TSMScript : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject textButton;
    public GameObject playAgainButton;
    public GameObject quitButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ability to quit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        //open new text fields
        if (Input.GetMouseButtonUp(0) && GameObject.FindGameObjectWithTag("Text1") != null) 
        {
            StartCoroutine("enableText2");
        }
        if (Input.GetMouseButtonUp(0) && GameObject.FindGameObjectWithTag("Text2") != null)
        {
            StartCoroutine("enableText3");
        }
        if (Input.GetMouseButtonUp(0) && GameObject.FindGameObjectWithTag("Text3") != null)
        {
            StartCoroutine("enableButton");
        }
    }

    public void startGame()
    {
        SceneManager.LoadScene("Stage1");
    }

    IEnumerator enableText2()
    {
        yield return new WaitForSeconds(.1f);
        text2.SetActive(true);
        text1.SetActive(false);
        
    }
    IEnumerator enableText3()
    {
        yield return new WaitForSeconds(.1f);
        text3.SetActive(true);
        text2.SetActive(false);
    }
    IEnumerator enableButton()
    {
        yield return new WaitForSeconds(.1f);
        textButton.SetActive(true);
        text3.SetActive(false);
    }

    public void playAgain()
    {
        SceneManager.LoadScene("LoadingScene");
    }
    public void quitGame()
    {
        Application.Quit();
    }
   
}
