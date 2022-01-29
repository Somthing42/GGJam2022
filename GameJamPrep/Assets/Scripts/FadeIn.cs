using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Color fadeInColor;

    public float fadeInTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fadeInTimer -= Time.deltaTime;

        if (fadeInTimer <= 0)
        {
            fadeInColor.a -= (Time.deltaTime/10);
        }

       

       gameObject.GetComponent<Image>().color = fadeInColor;
    }
}
