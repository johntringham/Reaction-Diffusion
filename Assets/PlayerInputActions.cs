// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""ActionMap"",
            ""id"": ""2225351b-75ee-4942-853e-faab5e5d0c68"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f90c6129-783c-4598-912b-cdd6fa95e192"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Midi1"",
                    ""type"": ""Value"",
                    ""id"": ""0834d87c-f14a-4ad6-babe-6b626be58d25"",
                    ""expectedControlType"": ""MidiValue"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Midi2"",
                    ""type"": ""Value"",
                    ""id"": ""91c6e867-4e86-40a4-8a9d-2f336a239775"",
                    ""expectedControlType"": ""MidiValue"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Midi3"",
                    ""type"": ""Value"",
                    ""id"": ""dfc8f7c1-fdee-4d51-8690-c6b69a095ac3"",
                    ""expectedControlType"": ""MidiValue"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Midi4"",
                    ""type"": ""Value"",
                    ""id"": ""5600962a-a0e0-4b45-a737-17baeacb2a56"",
                    ""expectedControlType"": ""MidiValue"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Midi5"",
                    ""type"": ""Value"",
                    ""id"": ""38cb150d-710e-4c77-b6ad-b91420adb137"",
                    ""expectedControlType"": ""MidiValue"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Midi6"",
                    ""type"": ""Value"",
                    ""id"": ""ce370de6-0791-49a2-b76e-5840b5464fa2"",
                    ""expectedControlType"": ""MidiValue"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Midi7"",
                    ""type"": ""Value"",
                    ""id"": ""923aa065-4288-4138-b1a7-c4d644dc0010"",
                    ""expectedControlType"": ""MidiValue"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Midi8"",
                    ""type"": ""Value"",
                    ""id"": ""363d3bf3-01be-48fc-9c61-5bbcd9c7d579"",
                    ""expectedControlType"": ""MidiValue"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""55490f01-df9c-421e-b2d3-0256b9474f27"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""97ed5faf-95eb-43ac-ab95-7f5b3bd20fa6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""068eb34c-80c4-4e97-b70e-413686ec1132"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a767d846-627a-4df3-a0ee-bf3e3b032a0c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""abab965c-74a1-4f48-bcb0-f231bc03360c"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""683c5963-6ea0-4c9d-8810-b270b4c9ad26"",
                    ""path"": ""<MidiDevice>/control001"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Midi1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4a9fe2f-b4bb-43fd-9f92-0ec716d67293"",
                    ""path"": ""<MidiDevice>/control002"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Midi2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a04e974a-713d-4852-a9e5-87554bc7bb55"",
                    ""path"": ""<MidiDevice>/control003"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Midi3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa6406a6-5ec1-4600-b6fb-7b94ba9420bb"",
                    ""path"": ""<MidiDevice>/control006"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Midi6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbafd91e-9dc5-4d7a-b99c-8122b462d98f"",
                    ""path"": ""<MidiDevice>/control001"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Midi4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9dccf6c6-c69c-4a4f-b8c6-8a601dd291c3"",
                    ""path"": ""<MidiDevice>/control005"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Midi5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""899b8149-941c-4152-87ae-372a889954d9"",
                    ""path"": ""<MidiDevice>/control008"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Midi8"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7627ed6c-9a79-4d25-b8ea-0a48ac9acb61"",
                    ""path"": ""<MidiDevice>/control007"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Midi7"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // ActionMap
        m_ActionMap = asset.FindActionMap("ActionMap", throwIfNotFound: true);
        m_ActionMap_Movement = m_ActionMap.FindAction("Movement", throwIfNotFound: true);
        m_ActionMap_Midi1 = m_ActionMap.FindAction("Midi1", throwIfNotFound: true);
        m_ActionMap_Midi2 = m_ActionMap.FindAction("Midi2", throwIfNotFound: true);
        m_ActionMap_Midi3 = m_ActionMap.FindAction("Midi3", throwIfNotFound: true);
        m_ActionMap_Midi4 = m_ActionMap.FindAction("Midi4", throwIfNotFound: true);
        m_ActionMap_Midi5 = m_ActionMap.FindAction("Midi5", throwIfNotFound: true);
        m_ActionMap_Midi6 = m_ActionMap.FindAction("Midi6", throwIfNotFound: true);
        m_ActionMap_Midi7 = m_ActionMap.FindAction("Midi7", throwIfNotFound: true);
        m_ActionMap_Midi8 = m_ActionMap.FindAction("Midi8", throwIfNotFound: true);
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

    // ActionMap
    private readonly InputActionMap m_ActionMap;
    private IActionMapActions m_ActionMapActionsCallbackInterface;
    private readonly InputAction m_ActionMap_Movement;
    private readonly InputAction m_ActionMap_Midi1;
    private readonly InputAction m_ActionMap_Midi2;
    private readonly InputAction m_ActionMap_Midi3;
    private readonly InputAction m_ActionMap_Midi4;
    private readonly InputAction m_ActionMap_Midi5;
    private readonly InputAction m_ActionMap_Midi6;
    private readonly InputAction m_ActionMap_Midi7;
    private readonly InputAction m_ActionMap_Midi8;
    public struct ActionMapActions
    {
        private @PlayerInputActions m_Wrapper;
        public ActionMapActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_ActionMap_Movement;
        public InputAction @Midi1 => m_Wrapper.m_ActionMap_Midi1;
        public InputAction @Midi2 => m_Wrapper.m_ActionMap_Midi2;
        public InputAction @Midi3 => m_Wrapper.m_ActionMap_Midi3;
        public InputAction @Midi4 => m_Wrapper.m_ActionMap_Midi4;
        public InputAction @Midi5 => m_Wrapper.m_ActionMap_Midi5;
        public InputAction @Midi6 => m_Wrapper.m_ActionMap_Midi6;
        public InputAction @Midi7 => m_Wrapper.m_ActionMap_Midi7;
        public InputAction @Midi8 => m_Wrapper.m_ActionMap_Midi8;
        public InputActionMap Get() { return m_Wrapper.m_ActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IActionMapActions instance)
        {
            if (m_Wrapper.m_ActionMapActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMovement;
                @Midi1.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMidi1;
                @Midi1.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMidi1;
                @Midi1.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMidi1;
                @Midi2.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMidi2;
                @Midi2.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMidi2;
                @Midi2.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMidi2;
                @Midi3.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMidi3;
                @Midi3.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMidi3;
                @Midi3.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMidi3;
                @Midi4.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMidi4;
                @Midi4.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMidi4;
                @Midi4.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMidi4;
                @Midi5.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMidi5;
                @Midi5.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMidi5;
                @Midi5.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMidi5;
                @Midi6.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMidi6;
                @Midi6.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMidi6;
                @Midi6.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMidi6;
                @Midi7.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMidi7;
                @Midi7.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMidi7;
                @Midi7.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMidi7;
                @Midi8.started -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMidi8;
                @Midi8.performed -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMidi8;
                @Midi8.canceled -= m_Wrapper.m_ActionMapActionsCallbackInterface.OnMidi8;
            }
            m_Wrapper.m_ActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Midi1.started += instance.OnMidi1;
                @Midi1.performed += instance.OnMidi1;
                @Midi1.canceled += instance.OnMidi1;
                @Midi2.started += instance.OnMidi2;
                @Midi2.performed += instance.OnMidi2;
                @Midi2.canceled += instance.OnMidi2;
                @Midi3.started += instance.OnMidi3;
                @Midi3.performed += instance.OnMidi3;
                @Midi3.canceled += instance.OnMidi3;
                @Midi4.started += instance.OnMidi4;
                @Midi4.performed += instance.OnMidi4;
                @Midi4.canceled += instance.OnMidi4;
                @Midi5.started += instance.OnMidi5;
                @Midi5.performed += instance.OnMidi5;
                @Midi5.canceled += instance.OnMidi5;
                @Midi6.started += instance.OnMidi6;
                @Midi6.performed += instance.OnMidi6;
                @Midi6.canceled += instance.OnMidi6;
                @Midi7.started += instance.OnMidi7;
                @Midi7.performed += instance.OnMidi7;
                @Midi7.canceled += instance.OnMidi7;
                @Midi8.started += instance.OnMidi8;
                @Midi8.performed += instance.OnMidi8;
                @Midi8.canceled += instance.OnMidi8;
            }
        }
    }
    public ActionMapActions @ActionMap => new ActionMapActions(this);
    public interface IActionMapActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnMidi1(InputAction.CallbackContext context);
        void OnMidi2(InputAction.CallbackContext context);
        void OnMidi3(InputAction.CallbackContext context);
        void OnMidi4(InputAction.CallbackContext context);
        void OnMidi5(InputAction.CallbackContext context);
        void OnMidi6(InputAction.CallbackContext context);
        void OnMidi7(InputAction.CallbackContext context);
        void OnMidi8(InputAction.CallbackContext context);
    }
}
