using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{   
    public AudioSource backgroundMusic;

    void Start()
    {
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {   
            if (backgroundMusic != null)
            {
                backgroundMusic.Stop(); 
            }
            PlayerPrefs.DeleteAll(); 

            SceneManager.LoadScene(0);     

        }

       if (backgroundMusic != null && !backgroundMusic.isPlaying)
       {
           backgroundMusic.Play();
       }

    }


}