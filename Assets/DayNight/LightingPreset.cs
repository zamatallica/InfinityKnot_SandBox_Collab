using UnityEngine;

/*
 * Alejandro Escobedo 10/04/2020 Added Cloud Lightning Integration with [BFW]SimpleDynamicClods Asset
 */

[System.Serializable]
[CreateAssetMenu(fileName = "Lighting Preset", menuName = "Scriptables/Lighting Preset", order = 1)]
public class LightingPreset : ScriptableObject
{
    public Gradient AmbientColor;
    public Gradient DirectionalColor;
    public Gradient FogColor;
    public Gradient LowClouds;
    public Gradient HighClouds;
}