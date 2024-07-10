//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""193a7c13-f1f9-4db4-925f-f3d6e535422f"",
            ""actions"": [
                {
                    ""name"": ""TokenPlacement"",
                    ""type"": ""Button"",
                    ""id"": ""93155b9a-f870-496f-8e8c-0c661e3451ed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NextColumn"",
                    ""type"": ""Button"",
                    ""id"": ""38a1c961-2e1b-4ded-8fb4-316670e15013"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PrevColumn"",
                    ""type"": ""Button"",
                    ""id"": ""ea4faea9-e19f-42d7-b71b-bfeb7d18ec4d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""e12d3d1f-72c5-4fd7-a26a-6fcf7bed28ee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Undo"",
                    ""type"": ""Button"",
                    ""id"": ""e7e83214-588f-4bf3-9992-9c48abb519be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Testing"",
                    ""type"": ""Button"",
                    ""id"": ""f3294475-a5a0-4dcb-9d8f-4ef7a10b4832"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3c2da1f0-6f86-42a1-a819-f3e47e1f45e6"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TokenPlacement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""714fc870-413e-4ab3-8030-647d44959ce2"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextColumn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45a731f4-4597-4400-8e99-b7c614ba42c5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrevColumn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07417e48-b1b7-4cf6-b465-82ed0897b2ad"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9e994c2-eb27-4911-a6c3-b7fec155a519"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Testing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1173f21-0853-4037-8b38-eb45f42bb961"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Undo"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_TokenPlacement = m_Player.FindAction("TokenPlacement", throwIfNotFound: true);
        m_Player_NextColumn = m_Player.FindAction("NextColumn", throwIfNotFound: true);
        m_Player_PrevColumn = m_Player.FindAction("PrevColumn", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
        m_Player_Undo = m_Player.FindAction("Undo", throwIfNotFound: true);
        m_Player_Testing = m_Player.FindAction("Testing", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_TokenPlacement;
    private readonly InputAction m_Player_NextColumn;
    private readonly InputAction m_Player_PrevColumn;
    private readonly InputAction m_Player_Pause;
    private readonly InputAction m_Player_Undo;
    private readonly InputAction m_Player_Testing;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @TokenPlacement => m_Wrapper.m_Player_TokenPlacement;
        public InputAction @NextColumn => m_Wrapper.m_Player_NextColumn;
        public InputAction @PrevColumn => m_Wrapper.m_Player_PrevColumn;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputAction @Undo => m_Wrapper.m_Player_Undo;
        public InputAction @Testing => m_Wrapper.m_Player_Testing;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @TokenPlacement.started += instance.OnTokenPlacement;
            @TokenPlacement.performed += instance.OnTokenPlacement;
            @TokenPlacement.canceled += instance.OnTokenPlacement;
            @NextColumn.started += instance.OnNextColumn;
            @NextColumn.performed += instance.OnNextColumn;
            @NextColumn.canceled += instance.OnNextColumn;
            @PrevColumn.started += instance.OnPrevColumn;
            @PrevColumn.performed += instance.OnPrevColumn;
            @PrevColumn.canceled += instance.OnPrevColumn;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
            @Undo.started += instance.OnUndo;
            @Undo.performed += instance.OnUndo;
            @Undo.canceled += instance.OnUndo;
            @Testing.started += instance.OnTesting;
            @Testing.performed += instance.OnTesting;
            @Testing.canceled += instance.OnTesting;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @TokenPlacement.started -= instance.OnTokenPlacement;
            @TokenPlacement.performed -= instance.OnTokenPlacement;
            @TokenPlacement.canceled -= instance.OnTokenPlacement;
            @NextColumn.started -= instance.OnNextColumn;
            @NextColumn.performed -= instance.OnNextColumn;
            @NextColumn.canceled -= instance.OnNextColumn;
            @PrevColumn.started -= instance.OnPrevColumn;
            @PrevColumn.performed -= instance.OnPrevColumn;
            @PrevColumn.canceled -= instance.OnPrevColumn;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
            @Undo.started -= instance.OnUndo;
            @Undo.performed -= instance.OnUndo;
            @Undo.canceled -= instance.OnUndo;
            @Testing.started -= instance.OnTesting;
            @Testing.performed -= instance.OnTesting;
            @Testing.canceled -= instance.OnTesting;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnTokenPlacement(InputAction.CallbackContext context);
        void OnNextColumn(InputAction.CallbackContext context);
        void OnPrevColumn(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnUndo(InputAction.CallbackContext context);
        void OnTesting(InputAction.CallbackContext context);
    }
}
