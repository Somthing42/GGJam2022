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

    public GameObject cutToBlack;

    public GameObject[] stateOneObjects;
    public GameObject[] stateTwoObjects;
    public GameObject[] stateThreeObjects;
    public GameObject[] stateFourObjects;

    private int musicCounter = 0;

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

        if (Input.GetKeyDown("escape"))
        {
            Application.Quit();
        }

        if (questsCompleated == 3 & doOnce == false)
        {
            littleGirl.SetActive(true);
            doOnce = true;
        }

        //stops calling when game ends
        if (endTimer >= 0)
        {
            GameStates();
        }
        
        //if player exists
        if (player)
        {
            //if 4 quests are completed and the player controller is active
            if (questsCompleated == 4 & player.GetComponent<PlayerController>().enabled == true)
            {
                endTimer -= Time.deltaTime;

                if (musicCounter == 0)
                {
                    SoundManager.Instance.PlayMusic(SoundManager.Instance.music[1]);
                    musicCounter += 1;
                }
                
              SoundManager.Instance.MusicSource.volume += (Time.deltaTime/2);

                //cut to black
                if (endTimer <= 5)
                {
                    cutToBlack.SetActive(true);
                    SoundManager.Instance.MusicSource.Stop();
                }

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

    void GameStates()
    {

        if (questsCompleated == 1)
        {
            //activate state one objects
            foreach (GameObject obj in stateOneObjects)
            {
                obj.SetActive(true);
            }
        }
        if (questsCompleated == 2)
        {
            //activate state two objects
            foreach (GameObject obj in stateTwoObjects)
            {
                obj.SetActive(true);
            }
        }
        if (questsCompleated == 3)
        {
            //activate state three objects
            foreach (GameObject obj in stateThreeObjects)
            {
                obj.SetActive(true);
            }
        }
        if (questsCompleated == 4)
        {
            //activate state four objects
            foreach (GameObject obj in stateFourObjects)
            {
                obj.SetActive(true);
            }
        }
    }

}
