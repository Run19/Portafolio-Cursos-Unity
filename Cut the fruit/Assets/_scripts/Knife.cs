// GENERATED AUTOMATICALLY FROM 'Assets/_scripts/Knife.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Knife : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }

    public @Knife()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Knife"",
    ""maps"": [
        {
            ""name"": ""Keyboard"",
            ""id"": ""fa458e5b-4f0c-4da5-a44a-9cf4f4e79d8e"",
            ""actions"": [
                {
                    ""name"": ""Cut"",
                    ""type"": ""Button"",
                    ""id"": ""e34450a9-6669-49be-9e9b-c0e2c743c799"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8dba04e6-3600-4b34-bdb2-4a29349d06ec"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Cut"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        }
    ]
}");
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_Cut = m_Keyboard.FindAction("Cut", throwIfNotFound: true);
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

    // Keyboard
    private readonly InputActionMap m_Keyboard;
    private IKeyboardActions m_KeyboardActionsCallbackInterface;
    private readonly InputAction m_Keyboard_Cut;

    public struct KeyboardActions
    {
        private @Knife m_Wrapper;

        public KeyboardActions(@Knife wrapper)
        {
            m_Wrapper = wrapper;
        }

        public InputAction @Cut => m_Wrapper.m_Keyboard_Cut;

        public InputActionMap Get()
        {
            return m_Wrapper.m_Keyboard;
        }

        public void Enable()
        {
            Get().Enable();
        }

        public void Disable()
        {
            Get().Disable();
        }

        public bool enabled => Get().enabled;

        public static implicit operator InputActionMap(KeyboardActions set)
        {
            return set.Get();
        }

        public void SetCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterface != null)
            {
                @Cut.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnCut;
                @Cut.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnCut;
                @Cut.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnCut;
            }

            m_Wrapper.m_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Cut.started += instance.OnCut;
                @Cut.performed += instance.OnCut;
                @Cut.canceled += instance.OnCut;
            }
        }
    }

    public KeyboardActions @Keyboard => new KeyboardActions(this);
    private int m_KeyboardSchemeIndex = -1;

    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }

    public interface IKeyboardActions
    {
        void OnCut(InputAction.CallbackContext context);
    }
}