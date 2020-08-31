// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/CarController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CarController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CarController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CarController"",
    ""maps"": [
        {
            ""name"": ""CarMove"",
            ""id"": ""0f199aff-b41e-496a-9f29-1aca55527536"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""8ce8bc1f-fe01-438a-826a-013e203acf32"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""bf28023f-fad3-4eb4-be34-cc6c4b3a0e00"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a1f1f044-4aac-4990-bef3-e9358e0e377c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7303f73e-b53a-419e-9092-d066b9680c3c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e8297b60-c0a5-487c-993a-6cfe92eb19c6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""544c4bd9-4500-4d00-9685-bfc833cecb0e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""New control scheme"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Gamepad>{Player1}"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // CarMove
        m_CarMove = asset.FindActionMap("CarMove", throwIfNotFound: true);
        m_CarMove_Move = m_CarMove.FindAction("Move", throwIfNotFound: true);
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

    // CarMove
    private readonly InputActionMap m_CarMove;
    private ICarMoveActions m_CarMoveActionsCallbackInterface;
    private readonly InputAction m_CarMove_Move;
    public struct CarMoveActions
    {
        private @CarController m_Wrapper;
        public CarMoveActions(@CarController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_CarMove_Move;
        public InputActionMap Get() { return m_Wrapper.m_CarMove; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CarMoveActions set) { return set.Get(); }
        public void SetCallbacks(ICarMoveActions instance)
        {
            if (m_Wrapper.m_CarMoveActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CarMoveActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CarMoveActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CarMoveActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_CarMoveActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public CarMoveActions @CarMove => new CarMoveActions(this);
    private int m_NewcontrolschemeSchemeIndex = -1;
    public InputControlScheme NewcontrolschemeScheme
    {
        get
        {
            if (m_NewcontrolschemeSchemeIndex == -1) m_NewcontrolschemeSchemeIndex = asset.FindControlSchemeIndex("New control scheme");
            return asset.controlSchemes[m_NewcontrolschemeSchemeIndex];
        }
    }
    public interface ICarMoveActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
