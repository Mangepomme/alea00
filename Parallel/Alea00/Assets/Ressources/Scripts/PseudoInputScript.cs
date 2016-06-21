using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PseudoInputScript : MonoBehaviour {

    public InputField pseudoInput;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        string currentpseudo = pseudoInput.text;
        if(currentpseudo != "")
        {
            PlayerPrefs.SetString("Pseudo", currentpseudo);
        }
        else
        {
            PlayerPrefs.SetString("Pseudo", "Pseudo");
        }
	}
}
