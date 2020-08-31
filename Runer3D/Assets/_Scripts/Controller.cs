// GENERATED AUTOMATICALLY FROM 'Assets/_Scripts/Controller.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controller : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controller()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controller"",
    ""maps"": [
        {
            ""name"": ""Keyboard"",
            ""id"": ""47965c43-0b7d-4392-9c5f-cf0eae91261c"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""b3009e58-89bd-489a-932f-c2312d895219"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Faster"",
                    ""type"": ""Button"",
                    ""id"": ""815dec44-964b-4dd7-ab0a-139df6635aae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ReestartGame"",
                    ""type"": ""Button"",
                    ""id"": ""34f0dcf3-45fa-4104-be1d-ce6f6a85618f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ce390b94-6a45-4be2-b529-f6da5a9413e2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""99a65bba-23d3-452f-80f4-998994c6b4af"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Faster"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a4917d7-1b04-4927-84ff-da6eea6c3a3b"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""ReestartGame"",
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
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_Jump = m_Keyboard.FindAction("Jump", throwIfNotFound: true);
        m_Keyboard_Faster = m_Keyboard.FindAction("Faster", throwIfNotFound: true);
        m_Keyboard_ReestartGame = m_Keyboard.FindAction("ReestartGame", throwIfNotFound: true);
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
    private readonly InputAction m_Keyboard_Jump;
    private readonly InputAction m_Keyboard_Faster;
    private readonly InputAction m_Keyboard_ReestartGame;
    public struct KeyboardActions
    {
        private @Controller m_Wrapper;
        public KeyboardActions(@Controller wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Keyboard_Jump;
        public InputAction @Faster => m_Wrapper.m_Keyboard_Faster;
        public InputAction @ReestartGame => m_Wrapper.m_Keyboard_ReestartGame;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnJump;
                @Faster.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnFaster;
                @Faster.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnFaster;
                @Faster.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnFaster;
                @ReestartGame.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnReestartGame;
                @ReestartGame.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnReestartGame;
                @ReestartGame.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnReestartGame;
            }
            m_Wrapper.m_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Faster.started += instance.OnFaster;
                @Faster.performed += instance.OnFaster;
                @Faster.canceled += instance.OnFaster;
                @ReestartGame.started += instance.OnReestartGame;
                @ReestartGame.performed += instance.OnReestartGame;
                @ReestartGame.canceled += instance.OnReestartGame;
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
        void OnJump(InputAction.CallbackContext context);
        void OnFaster(InputAction.CallbackContext context);
        void OnReestartGame(InputAction.CallbackContext context);
    }
}
