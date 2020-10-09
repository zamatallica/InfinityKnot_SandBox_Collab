using Bolt;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MovePlatform : MonoBehaviour
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

    //bool loop = false;
    float maxY = 10f;
    float minY = 0.25f;
    bool goingUp = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (PlatformActive)
            {
                Debug.Log("Loop stopped!");
                PlatformActive = false;
            }
            else
            {
                Debug.Log("Loop started!");
                PlatformActive = true;
            }
        }

        float factor = 2f;
        if (PlatformActive)
        {
            //could also try: transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
            Vector3 pos = transform.position;
            if (goingUp)
            {
                pos.y += factor * Time.deltaTime; 
                
                if (pos.y >= maxY)
                {
                    goingUp = false;
                }
            }
            else
            {
                pos.y -= factor * Time.deltaTime;
                //Debug.Log($"y:{pos.y}, DeltaTime:{Time.deltaTime}");

                if (pos.y <= minY)
                {
                    goingUp = true;
                }
            }
            
            transform.position = pos;

            //transform.position
            //transform.Translate()
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collission Entered!!");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collission Exit!!");
    }

    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log("Collission Stay...");
    }
}
