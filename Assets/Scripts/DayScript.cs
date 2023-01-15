using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Experimental.Rendering.Universal;

public class DayScript : MonoBehaviour
{
    public float DayTime;
    public Light2D lt;
    public Light2D GlobalLight;

    [SerializeField]
    private GameControler gameControler;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -3f)
        {
            transform.Translate(6, 0, 0);
            if (gameControler.isDay)
            { // is night
                gameControler.isDay = false;
                GlobalLight.color = new Color(93/255f,103/255f,232/255f);
                lt.intensity = 0.2f;
            }
            else 
            { // is day
                gameControler.isDay = true;
                GlobalLight.color = new Color(225/255f, 242/255f, 145 / 255f);
                lt.intensity = 0.5f;
            }

        }
        else
        {   //dayTime/10000
            transform.Translate(-DayTime / 10000, 0, 0);
        }
    }
}
