using Bolt;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPad : MonoBehaviour
{

    bool PlatformActive
    {
        get
        {
            return (bool)Variables.ActiveScene.Get("PlatformActive");
        }
        set
        {
            Variables.ActiveScene.Set("PlatformActive", value);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool active = false;

    private void OnTriggerEnter(Collider other)
    {
        PlatformActive = true;
        Debug.Log("Trigger enter");
    }

    private void OnTriggerStay(Collider other)
    {
        PlatformActive = true;
        Debug.Log($"Trigger stay, platformActive={PlatformActive}");
        

    }


    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exit");
        PlatformActive = false;
    }
}
