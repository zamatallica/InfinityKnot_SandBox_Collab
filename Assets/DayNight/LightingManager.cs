/*
 *   Alejandro Escobedo 10/04/2020  Added Cloud Light  coloring, must be used with [BFW]SimpleDynamicClouds Asset in order to work. By Using LowClow / highCloud Material Asset
 * 
 */


using Ludiq;
using UnityEngine;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //Scene References
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightingPreset Preset;
    public Material HighClouds;
    public Material LowClouds;

    //Variables
    [SerializeField, Range(0, 24)] private float TimeOfDay;


    private void Update()
    {
        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            //(Replace with a reference to the game time)
            TimeOfDay += Time.deltaTime*.2f;
            TimeOfDay %= 24; //Modulus to ensure always between 0-24
            UpdateLighting(TimeOfDay / 24f);
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
        }
    }


    private void UpdateLighting(float timePercent)
    {
        //Set ambient and fog
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        //set the Particle Clouds color (Low and High clouds)
        // var matHighClouds = HighClouds.GetComponent<Material>();
        HighClouds.SetColor("_CloudColor", Preset.HighClouds.Evaluate(timePercent));
        LowClouds.SetColor("_CloudColor", Preset.LowClouds.Evaluate(timePercent));
        //Debug.Log(matColor.ToString());



        //Debug.Log(Preset.FogColor.Evaluate(timePercent).ToString());


        //If the directional light is set then rotate and set it's color, I actually rarely use the rotation because it casts tall shadows unless you clamp the value
        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePercent);

            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }

    }

    //Try to find a directional light to use if we haven't set one
    private void OnValidate()
    {
        if (DirectionalLight != null)
            return;

        //Search for lighting tab sun
        if (RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        //Search scene for light that fits criteria (directional)
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights)
            {
                if (light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }
}