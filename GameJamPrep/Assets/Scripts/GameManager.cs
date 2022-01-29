using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int questsCompleated = 0;

    public float endTimer;

    private GameObject player;

    public GameObject littleGirl;

    private bool doOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            //game manager is not destroyed when changing scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //destroys copies so that only one is in a scene at a time
            Destroy(gameObject);
        }
        player = GameObject.FindGameObjectWithTag("Player");

    }
    
    // Update is called once per frame
    void Update()
    {
        if (questsCompleated == 3 & doOnce == false)
        {
            littleGirl.SetActive(true);
            doOnce = true;
        }


        if (player)
        {
            if (questsCompleated == 4 & player.GetComponent<PlayerController>().enabled == true)
            {
                endTimer -= Time.deltaTime;

                if (endTimer <= 0)
                {
                    GameEnd();
                }

            }
        }
    }

    void GameEnd()
    {

        //Debug.Log("its over!");
        SceneManager.LoadScene("Ending");
        
    }
}
