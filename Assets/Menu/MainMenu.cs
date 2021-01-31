﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private int m_Idend = 2;
    public void PlayGame()
    {
        SceneManager.LoadScene("Lv_Game_Ego");
      //  soundBouton.PlayOneShot(soundBouton.clip);
        


    }

    public void Continue()
    {
        Cursor.visible = true;
       // soundBouton.PlayOneShot(soundBouton.clip);


    }
    public void Credit()
    {
        Cursor.visible = true;
        //soundBouton.PlayOneShot(soundBouton.clip);
        SceneManager.LoadScene("Credit");

    }


   
    public void QuitGame()
    {
        Cursor.visible = true;
        //soundBouton.PlayOneShot(soundBouton.clip);
        Application.Quit();
    }


    public void ReturnMenu()
    {
        Cursor.visible = true;
        //soundBouton.PlayOneShot(soundBouton.clip);
        SceneManager.LoadScene("MenuStart");

    }
}
