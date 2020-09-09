// GENERATED AUTOMATICALLY FROM 'Assets/_Scripts/BallonMove.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @BallonMove : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @BallonMove()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""BallonMove"",
    ""maps"": [
        {
            ""name"": ""Keybpard"",
            ""id"": ""aa0b3346-ed5d-4873-bcb2-ab236189817c"",
            ""actions"": [
                {
                    ""name"": ""Fly"",
                    ""type"": ""Button"",
                    ""id"": ""1d7e110f-28f0-447b-9fb6-94644767eb63"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reestart"",
                    ""type"": ""Button"",
                    ""id"": ""7e52d4d0-5a7c-4f65-a8a1-6e30c7f867e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""80433f10-66c9-4246-a573-ada15b9cda5e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""Fly"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f19edf4-7ab9-49f6-8cae-6cbd6b93562e"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""Reestart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""New control scheme"",
            ""bindingGroup"": ""New control scheme"",
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
        // Keybpard
        m_Keybpard = asset.FindActionMap("Keybpard", throwIfNotFound: true);
        m_Keybpard_Fly = m_Keybpard.FindAction("Fly", throwIfNotFound: true);
        m_Keybpard_Reestart = m_Keybpard.FindAction("Reestart", throwIfNotFound: true);
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

    // Keybpard
    private readonly InputActionMap m_Keybpard;
    private IKeybpardActions m_KeybpardActionsCallbackInterface;
    private readonly InputAction m_Keybpard_Fly;
    private readonly InputAction m_Keybpard_Reestart;
    public struct KeybpardActions
    {
        private @BallonMove m_Wrapper;
        public KeybpardActions(@BallonMove wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fly => m_Wrapper.m_Keybpard_Fly;
        public InputAction @Reestart => m_Wrapper.m_Keybpard_Reestart;
        public InputActionMap Get() { return m_Wrapper.m_Keybpard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeybpardActions set) { return set.Get(); }
        public void SetCallbacks(IKeybpardActions instance)
        {
            if (m_Wrapper.m_KeybpardActionsCallbackInterface != null)
            {
                @Fly.started -= m_Wrapper.m_KeybpardActionsCallbackInterface.OnFly;
                @Fly.performed -= m_Wrapper.m_KeybpardActionsCallbackInterface.OnFly;
                @Fly.canceled -= m_Wrapper.m_KeybpardActionsCallbackInterface.OnFly;
                @Reestart.started -= m_Wrapper.m_KeybpardActionsCallbackInterface.OnReestart;
                @Reestart.performed -= m_Wrapper.m_KeybpardActionsCallbackInterface.OnReestart;
                @Reestart.canceled -= m_Wrapper.m_KeybpardActionsCallbackInterface.OnReestart;
            }
            m_Wrapper.m_KeybpardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fly.started += instance.OnFly;
                @Fly.performed += instance.OnFly;
                @Fly.canceled += instance.OnFly;
                @Reestart.started += instance.OnReestart;
                @Reestart.performed += instance.OnReestart;
                @Reestart.canceled += instance.OnReestart;
            }
        }
    }
    public KeybpardActions @Keybpard => new KeybpardActions(this);
    private int m_NewcontrolschemeSchemeIndex = -1;
    public InputControlScheme NewcontrolschemeScheme
    {
        get
        {
            if (m_NewcontrolschemeSchemeIndex == -1) m_NewcontrolschemeSchemeIndex = asset.FindControlSchemeIndex("New control scheme");
            return asset.controlSchemes[m_NewcontrolschemeSchemeIndex];
        }
    }
    public interface IKeybpardActions
    {
        void OnFly(InputAction.CallbackContext context);
        void OnReestart(InputAction.CallbackContext context);
    }
}
