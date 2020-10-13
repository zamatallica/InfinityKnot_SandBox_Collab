using Bolt;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem.Controls;

public class Bolt_Xbox_Cont_Interface : MonoBehaviour
{
    GamePlay_Xbox_Controller control;

    public Vector2 RightStick;
    public Vector2 leftAnalog;
    public Dictionary<string, bool> onButtonHold = new Dictionary<string, bool>();
    public Dictionary<string, bool> onButtonDown = new Dictionary<string, bool>();
    public Dictionary<string, bool> onButtonUp = new Dictionary<string, bool>();

    private void Awake()
    {
        control = new GamePlay_Xbox_Controller();
    }

    private void OnEnable()
    {
        control.Enable();
    }

    private void OnDisable()
    {
        control.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
          foreach (var item in control.GamePlay_Xbox_Contoller.Get().actions)
        {
            onButtonHold.Add(item.name, false);
            onButtonDown.Add(item.name, false);
            onButtonUp.Add(item.name, false);
 
            item.performed += delegate { onButtonHold[item.name] = true; };
            item.canceled  += delegate { onButtonHold[item.name] = false; };
            item.canceled  += delegate { onButtonUp[item.name]   = true; };
        }
    }

    // Update is called once per frame
    void Update()
    {
        leftAnalog = control.GamePlay_Xbox_Contoller.Move.ReadValue<Vector2>();
        RightStick = control.GamePlay_Xbox_Contoller.LookCamera.ReadValue<Vector2>();

        foreach (var item in control.GamePlay_Xbox_Contoller.Get().actions)
        {
            onButtonDown[item.name] = item.triggered;
        }
    }

    private void LateUpdate()
    {
        foreach (var item in control.GamePlay_Xbox_Contoller.Get().actions)
        {
            onButtonUp[item.name] = false;
        }
    }
}
