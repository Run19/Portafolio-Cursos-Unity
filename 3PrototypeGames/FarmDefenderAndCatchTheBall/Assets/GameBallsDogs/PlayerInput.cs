// GENERATED AUTOMATICALLY FROM 'Assets/GameBallsDogs/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Dog"",
            ""id"": ""1201389d-9fae-46fd-ae46-519655e7ff90"",
            ""actions"": [
                {
                    ""name"": ""GoDog"",
                    ""type"": ""Button"",
                    ""id"": ""ee44c3af-4118-4c7a-bd18-a840634ed368"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""db93e0f8-16d7-4ae1-b97e-6189c0b00324"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Dog"",
                    ""action"": ""GoDog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Dog"",
            ""bindingGroup"": ""Dog"",
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
        // Dog
        m_Dog = asset.FindActionMap("Dog", throwIfNotFound: true);
        m_Dog_GoDog = m_Dog.FindAction("GoDog", throwIfNotFound: true);
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

    // Dog
    private readonly InputActionMap m_Dog;
    private IDogActions m_DogActionsCallbackInterface;
    private readonly InputAction m_Dog_GoDog;
    public struct DogActions
    {
        private @PlayerInput m_Wrapper;
        public DogActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @GoDog => m_Wrapper.m_Dog_GoDog;
        public InputActionMap Get() { return m_Wrapper.m_Dog; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DogActions set) { return set.Get(); }
        public void SetCallbacks(IDogActions instance)
        {
            if (m_Wrapper.m_DogActionsCallbackInterface != null)
            {
                @GoDog.started -= m_Wrapper.m_DogActionsCallbackInterface.OnGoDog;
                @GoDog.performed -= m_Wrapper.m_DogActionsCallbackInterface.OnGoDog;
                @GoDog.canceled -= m_Wrapper.m_DogActionsCallbackInterface.OnGoDog;
            }
            m_Wrapper.m_DogActionsCallbackInterface = instance;
            if (instance != null)
            {
                @GoDog.started += instance.OnGoDog;
                @GoDog.performed += instance.OnGoDog;
                @GoDog.canceled += instance.OnGoDog;
            }
        }
    }
    public DogActions @Dog => new DogActions(this);
    private int m_DogSchemeIndex = -1;
    public InputControlScheme DogScheme
    {
        get
        {
            if (m_DogSchemeIndex == -1) m_DogSchemeIndex = asset.FindControlSchemeIndex("Dog");
            return asset.controlSchemes[m_DogSchemeIndex];
        }
    }
    public interface IDogActions
    {
        void OnGoDog(InputAction.CallbackContext context);
    }
}
