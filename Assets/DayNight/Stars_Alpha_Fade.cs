/*
 * Alejandro Escobedo v1.0.0   10/3/2020 1.00 Alpha Fades Gradient color in Color Over Time Component for a Particle System
 */

using UnityEngine;
using Bolt;


public class Stars_Alpha_Fade : MonoBehaviour
{

    public ParticleSystem ps;
    float t_24TimeODay;
    float gradientValues;

    void Update()
    {


        // ps = GetComponent<ParticleSystem>();

        GameObject VarComponent = GameObject.Find("SkyBox Controller");
        t_24TimeODay = (float)Variables.Object(VarComponent).Get("_24TimeOday");
        //gradientValues =  Mathf.Lerp(0,255,(2-(Mathf.Clamp(t_24TimeODay, 3, 5)%3))/2);  //*** 0 to 255 RGB Values
        //gradientValues =  (2-(Mathf.Clamp(t_24TimeODay, 3, 5)%3))/2;  //**** 0 t0 1 Alpha key Values

        gradientValues = 1-(Mathf.Clamp(t_24TimeODay, 4, 6) % 4)/ 2;  //**** 0 t0 1 Alpha key Values

       // Debug.Log(gradientValues.ToString());
        if (gradientValues == 0)
        {
            gradientValues = 1 - (2 - (Mathf.Clamp(t_24TimeODay, 17, 19) % 17)) / 2;  //**** 1 to 0 Alpha key Values
        }

         


        var col = ps.colorOverLifetime;
        col.enabled = true;

        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(Color.white, 0.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(gradientValues, gradientValues), new GradientAlphaKey(0.0f, 0.0f) });

        col.color = grad;
    }
}