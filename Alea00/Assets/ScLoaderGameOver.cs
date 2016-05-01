using UnityEngine;
using System.Collections;

public class ScLoaderGameOver : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void exit()
    {
        Application.Quit();
    }

    public void reload_game()
    {
        string game = PlayerPrefs.GetString("Level");
        if(game == "race")
        {
            Application.LoadLevel("RaceMode");
        }
        if(game == "fight")
        {
            Application.LoadLevel("SoloGame");
        }
        
    }

    public void load_menu()
    {
        Application.LoadLevel("MainMenu");
    }
}
