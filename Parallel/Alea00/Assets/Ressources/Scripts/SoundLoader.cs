using UnityEngine;
using System.Collections;

public class SoundLoader : MonoBehaviour {

    private int lvl;
    private string end;
    private AudioSource audio;
    public AudioSource lostcloud;
    public AudioSource callharm;
    public AudioSource dragon;
    public AudioSource victory;
    public AudioSource sadness;

    // Use this for initialization
    void Awake ()
    {
        lvl = PlayerPrefs.GetInt("Level");
        end = PlayerPrefs.GetString("End");
        audio = GetComponent<AudioSource>();
	}

    void Update()
    {
        if ((lvl == 1 || lvl == 3) && end=="Null")
        {
            callharm.Stop();
            dragon.Stop();
            victory.Stop();
            sadness.Stop();
        }
        else if ((lvl == 2 || lvl == 4) && end == "Null")
        {
            lostcloud.Stop();
            dragon.Stop();
            victory.Stop();
            sadness.Stop();
        }
        else if ((lvl == 5) && end == "Null")
        {
            lostcloud.Stop();
            callharm.Stop();
            victory.Stop();
            sadness.Stop();
        }
        else if (end == "Win")
        {
            lostcloud.Stop();
            callharm.Stop();
            dragon.Stop();
            sadness.Stop();
        }
        else if (end == "Lose")
        {
            lostcloud.Stop();
            callharm.Stop();
            dragon.Stop();
            victory.Stop();
        }
    }
}
