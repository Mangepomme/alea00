using UnityEngine;
using System.Collections;

public class levelmanager : MonoBehaviour {

    public Transform main_menu, options_menu;

    public void Loadplaysolo()
    {
        Application.LoadLevel("SoloGame");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Optionsmenu(bool clicked)
    {
        if (clicked)
        {
            options_menu.gameObject.SetActive(true);
            main_menu.gameObject.SetActive(false);
        }
        else
        {
            options_menu.gameObject.SetActive(false);
            main_menu.gameObject.SetActive(true);
        }
    }
}
