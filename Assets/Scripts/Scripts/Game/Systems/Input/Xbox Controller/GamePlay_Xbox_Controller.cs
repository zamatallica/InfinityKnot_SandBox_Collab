// GENERATED AUTOMATICALLY FROM 'Assets/Input/Xbox Controller/GamePlay_Xbox_Controller.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GamePlay_Xbox_Controller : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GamePlay_Xbox_Controller()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GamePlay_Xbox_Controller"",
    ""maps"": [
        {
            ""name"": ""GamePlay_Xbox_Contoller"",
            ""id"": ""40194887-bc41-4fbb-b58f-f6204586bb00"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""1995f86e-4452-48ec-9c0e-a1017690cd12"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LookCamera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""da7e254b-b383-4c3e-a306-a2d0c71ec171"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a5df06c6-b697-43d5-801c-3e1f9167970a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c0e0a32c-b85c-4093-be8f-33d781c45866"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07fe0ec5-e4dd-41a9-91fc-e45efefb7dab"",
                    ""path"": ""<XInputController>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e50abec5-a7e0-41d3-bea5-405c5132cb74"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GamePlay_Xbox_Contoller
        m_GamePlay_Xbox_Contoller = asset.FindActionMap("GamePlay_Xbox_Contoller", throwIfNotFound: true);
        m_GamePlay_Xbox_Contoller_Move = m_GamePlay_Xbox_Contoller.FindAction("Move", throwIfNotFound: true);
        m_GamePlay_Xbox_Contoller_LookCamera = m_GamePlay_Xbox_Contoller.FindAction("LookCamera", throwIfNotFound: true);
        m_GamePlay_Xbox_Contoller_Jump = m_GamePlay_Xbox_Contoller.FindAction("Jump", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // GamePlay_Xbox_Contoller
    private readonly InputActionMap m_GamePlay_Xbox_Contoller;
    private IGamePlay_Xbox_ContollerActions m_GamePlay_Xbox_ContollerActionsCallbackInterface;
    private readonly InputAction m_GamePlay_Xbox_Contoller_Move;
    private readonly InputAction m_GamePlay_Xbox_Contoller_LookCamera;
    private readonly InputAction m_GamePlay_Xbox_Contoller_Jump;
    public struct GamePlay_Xbox_ContollerActions
    {
        private @GamePlay_Xbox_Controller m_Wrapper;
        public GamePlay_Xbox_ContollerActions(@GamePlay_Xbox_Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_GamePlay_Xbox_Contoller_Move;
        public InputAction @LookCamera => m_Wrapper.m_GamePlay_Xbox_Contoller_LookCamera;
        public InputAction @Jump => m_Wrapper.m_GamePlay_Xbox_Contoller_Jump;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay_Xbox_Contoller; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlay_Xbox_ContollerActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlay_Xbox_ContollerActions instance)
        {
            if (m_Wrapper.m_GamePlay_Xbox_ContollerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GamePlay_Xbox_ContollerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GamePlay_Xbox_ContollerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GamePlay_Xbox_ContollerActionsCallbackInterface.OnMove;
                @LookCamera.started -= m_Wrapper.m_GamePlay_Xbox_ContollerActionsCallbackInterface.OnLookCamera;
                @LookCamera.performed -= m_Wrapper.m_GamePlay_Xbox_ContollerActionsCallbackInterface.OnLookCamera;
                @LookCamera.canceled -= m_Wrapper.m_GamePlay_Xbox_ContollerActionsCallbackInterface.OnLookCamera;
                @Jump.started -= m_Wrapper.m_GamePlay_Xbox_ContollerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GamePlay_Xbox_ContollerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GamePlay_Xbox_ContollerActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_GamePlay_Xbox_ContollerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @LookCamera.started += instance.OnLookCamera;
                @LookCamera.performed += instance.OnLookCamera;
                @LookCamera.canceled += instance.OnLookCamera;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public GamePlay_Xbox_ContollerActions @GamePlay_Xbox_Contoller => new GamePlay_Xbox_ContollerActions(this);
    public interface IGamePlay_Xbox_ContollerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLookCamera(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
}
