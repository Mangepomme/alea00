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
    public void setnull()
    {
        PlayerPrefs.SetString("End", "Null");
    }


    public void load_menu()
    {
        setnull();
        Application.LoadLevel("MainMenu");
    }

    public void load_end()
    {        
        Application.LoadLevel("End");
    }

    public void load_solo()
    {
        setnull();
        int lvl = PlayerPrefs.GetInt("Level");
        if(lvl == 1 || lvl == 2)
        {
            Application.LoadLevel("Sologame");
        }
        else if (lvl == 3 || lvl == 4)
        {
            Application.LoadLevel("Sologame2");
        }
        else
        {
            Application.LoadLevel("Sologame3");
        }
    }

    public void load_1()
    {
        setnull();
        PlayerPrefs.SetInt("Level", 1);
        Application.LoadLevel("Sologame");
    }

    public void load_2()
    {
        setnull();
        PlayerPrefs.SetInt("Level", 2);
        Application.LoadLevel("Sologame");
    }

    public void load_3()
    {
        setnull();
        PlayerPrefs.SetInt("Level", 3);
        Application.LoadLevel("Sologame2");
    }

    public void load_4()
    {
        setnull();
        PlayerPrefs.SetInt("Level", 4);
        Application.LoadLevel("Sologame2");
    }

    public void load_5()
    {
        setnull();
        PlayerPrefs.SetInt("Level", 5);
        Application.LoadLevel("Sologame3");
    }

    public void load_mvs()
    {
        setnull();
        Application.LoadLevel("MultiGame");
    }

    public void load_mr()
    {
        setnull();
        Application.LoadLevel("MultiRace");
    }

    public void load_next()
    {
        setnull();
        int x = PlayerPrefs.GetInt("Level");
        x++;
        if(x > 5)
        {
            Application.LoadLevel("MainMenu");
        }
        else
        {
            if(x == 2)
            {
                load_2();
            }
            if (x == 3)
            {
                load_3();
            }
            if (x == 4)
            {
                load_4();
            }
            if (x == 5)
            {
                load_5();
            }
        }
    }
}
