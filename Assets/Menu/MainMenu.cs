using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    GameObject Credit_Canvas;
    [SerializeField]
    GameObject Menu_Canvas;


    private int m_Idend = 2;


    public void PlayGame()
    {
        SceneManager.LoadScene("Lv_Game_Ego");
       // Cursor.visible = false;



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
        Credit_Canvas.SetActive(true);
        Menu_Canvas.SetActive(false);
        //soundBouton.PlayOneShot(soundBouton.clip);
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

    private void Start()
    {
        Credit_Canvas.SetActive(false);
        Menu_Canvas.SetActive(true);

    }

    public void Return()
    {
        Credit_Canvas.SetActive(false);
        Menu_Canvas.SetActive(true);
    }


}
