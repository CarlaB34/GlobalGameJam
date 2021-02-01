using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_MenuPause : MonoBehaviour
{
    [SerializeField]
    GameObject MenuPause;


    private void Start()
    {
        MenuPause.SetActive(false);
       // Cursor.visible = false;
    }

    public void OnResume()
    {
        Time.timeScale = 1;
        MenuPause.SetActive(false);
       // Cursor.visible = false;

    }

    public void OnPause()
    {

        Time.timeScale = 0;
        MenuPause.SetActive(true);
        Cursor.visible = true;

    }


    public void ReturnMenu()
    {
        SceneManager.LoadScene("MenuStart");

    }

    public void Quit()
    {
        Application.Quit();

    }
}
