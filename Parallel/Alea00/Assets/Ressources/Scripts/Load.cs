using UnityEngine;
using System.Collections;

public class Load : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void quit()
    {
        Application.Quit();
    }

    public void load_menu()
    {
        Application.LoadLevel("MainMenu");
    }

    public void load_end()
    {
        Application.LoadLevel("End");
    }

    public void load_solo()
    {
        Application.LoadLevel("Sologame");
    }

    public void load_1()
    {
        PlayerPrefs.SetInt("Level", 1);
        Application.LoadLevel("Sologame");
    }

    public void load_2()
    {
        PlayerPrefs.SetInt("Level", 2);
        Application.LoadLevel("Sologame");
    }

    public void load_3()
    {
        PlayerPrefs.SetInt("Level", 3);
        Application.LoadLevel("Sologame");
    }

    public void load_4()
    {
        PlayerPrefs.SetInt("Level", 4);
        Application.LoadLevel("Sologame");
    }

    public void load_5()
    {
        PlayerPrefs.SetInt("Level", 5);
        Application.LoadLevel("Sologame");
    }

    public void load_next()
    {
        int x = PlayerPrefs.GetInt("Level");
        x++;
        if(x > 5)
        {
            Application.LoadLevel("MainMenu");
        }
        else
        {
            PlayerPrefs.SetInt("Level", x);
            Application.LoadLevel("Sologame");
        }
    }
}
