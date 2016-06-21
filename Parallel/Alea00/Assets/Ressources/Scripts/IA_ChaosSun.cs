using UnityEngine;
using System.Collections;

public class IA_ChaosSun : MonoBehaviour
{

    public string playerPlaneName;
    public GameObject Hunter;
    public GameObject Destroyer;

    public float timer1;
    public float timer2;

    GameObject player;

    public float cadenceHunter;
    public float cadenceDestroyer;

    // Use this for initialization
    void Start()
    {
        Debug.Log("chaos sun script added to : " + gameObject.name); //permet de tester que le script est bien chargé par unity
        timer1 = 0;
        timer2 = 0;
        //cadenceInter1 = 2.0f;
        //cadenceInter2 = 8.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int planetype = PlayerPrefs.GetInt("Plane");

        if (planetype == 0)
        {
            playerPlaneName = "Fighter(Clone)";
        }
        else if (planetype == 1)
        {
            playerPlaneName = "Sprinter(Clone)";
        }
        else if (planetype == 2)
        {
            playerPlaneName = "SmallConqueror(Clone)";
        }
        else if (planetype == 3)
        {
            playerPlaneName = "Conqueror(Clone)";
        }
        else
        {
            playerPlaneName = "Prototype(Clone)";
        }

        Vector3 planPosition = GameObject.Find(playerPlaneName).transform.position;

        transform.LookAt(planPosition);

        timer1++;
        timer2++;
    }

    void OnTriggerStay(Collider obj)
    {
        if(obj.tag != "Enemy")
        {
            GlobalSolo.pvleft--;
        }
    }
}
