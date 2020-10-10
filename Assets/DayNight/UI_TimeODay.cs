using Bolt;
using Ludiq;
using MiscUtil.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TimeODay : MonoBehaviour
{
    public Text UI_Text;
    public float t_24TimeODay;
    public GameObject VarComponent;
    public string myHrs;
    public string myMinutes;

    // Start is called before the first frame update
    void Start()
    {
         myHrs = "00";
    }

    // Update is called once per frame
    void Update()
    {
        VarComponent = GameObject.Find("SkyBox Controller");
        t_24TimeODay = (float) Variables.Object(VarComponent).Get("_24TimeOday");

        if (t_24TimeODay >= 10.0f)
        {
             myHrs = Mathf.FloorToInt(t_24TimeODay).ToString();

        }
        else
        {
            myHrs = "0" + Mathf.FloorToInt(t_24TimeODay).ToString();
          
        }

        if (Mathf.FloorToInt(Mathf.Repeat(t_24TimeODay, 1) * 60) >= 10f)
        {
            myMinutes = Mathf.FloorToInt(Mathf.Repeat(t_24TimeODay, 1) * 60).ToString();
        }
        else
        {
            myMinutes = "0" + Mathf.FloorToInt(Mathf.Repeat(t_24TimeODay, 1) * 60).ToString();
        }


        if (t_24TimeODay >= 12.0f)
        {
            UI_Text.text = "Time of day: " + myHrs + ":" + myMinutes + " PM";
        }
        else 
        {
            UI_Text.text = "Time of day: " + myHrs + ":" + myMinutes + " AM";
        }

       

    }
}
