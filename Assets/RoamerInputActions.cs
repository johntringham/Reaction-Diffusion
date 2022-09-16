// GENERATED AUTOMATICALLY FROM 'Assets/RoamerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @RoamerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @RoamerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""RoamerInputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerControls"",
            ""id"": ""6c4a8a49-ce74-4485-95ea-d026349fb886"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""30e4a1a4-96fe-4baf-af9e-adf74690fc20"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ad120b2a-5949-4618-b24d-39052d69309f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Next Weapon"",
                    ""type"": ""Button"",
                    ""id"": ""f4dc2fa5-c085-4bac-86c5-a266d6128454"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Previous Weapon"",
                    ""type"": ""Button"",
                    ""id"": ""cfe5bba8-9322-452c-85f2-279337eb0509"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""7cbdbd3b-b8f5-408b-b026-fe9377def958"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grab"",
                    ""type"": ""Button"",
                    ""id"": ""ed49be52-b9d8-436e-bfba-a6e313214517"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Torch"",
                    ""type"": ""Button"",
                    ""id"": ""03dac13c-458f-4199-94d2-648a28f74935"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3a95d6b3-a4aa-48c0-b97f-ddd8460e5572"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""5474dd2f-8ab6-44b0-aeae-05f5b656ed5a"",
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
                    ""id"": ""f8af94b9-3b9b-416c-994a-532c6859a95d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2ff10ec8-43d0-45e0-8b1d-2347153bf620"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cd83523f-6e7b-4916-9dcb-e9d4b67f3048"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7ab0d76f-64cd-4616-8379-598c94e497fd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c9224db9-fe50-4858-be3c-32165d5727e7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55c6e3b6-f801-4591-b896-74fe9c7c02d6"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Next Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37e02948-cd2f-4382-80c1-225d37e65ded"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Previous Weapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88ab4e2e-7bc2-4a7b-8d66-4625c3ffc0a0"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8fab072-fb55-456e-aa79-5a3e680574f8"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3584fec5-500a-4955-bbb4-81a8e31169a4"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53623055-7d7d-45b4-bc48-e6128c984fc8"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Torch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerControls
        m_PlayerControls = asset.FindActionMap("PlayerControls", throwIfNotFound: true);
        m_PlayerControls_Move = m_PlayerControls.FindAction("Move", throwIfNotFound: true);
        m_PlayerControls_Shoot = m_PlayerControls.FindAction("Shoot", throwIfNotFound: true);
        m_PlayerControls_NextWeapon = m_PlayerControls.FindAction("Next Weapon", throwIfNotFound: true);
        m_PlayerControls_PreviousWeapon = m_PlayerControls.FindAction("Previous Weapon", throwIfNotFound: true);
        m_PlayerControls_Run = m_PlayerControls.FindAction("Run", throwIfNotFound: true);
        m_PlayerControls_Grab = m_PlayerControls.FindAction("Grab", throwIfNotFound: true);
        m_PlayerControls_Torch = m_PlayerControls.FindAction("Torch", throwIfNotFound: true);
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

    // PlayerControls
    private readonly InputActionMap m_PlayerControls;
    private IPlayerControlsActions m_PlayerControlsActionsCallbackInterface;
    private readonly InputAction m_PlayerControls_Move;
    private readonly InputAction m_PlayerControls_Shoot;
    private readonly InputAction m_PlayerControls_NextWeapon;
    private readonly InputAction m_PlayerControls_PreviousWeapon;
    private readonly InputAction m_PlayerControls_Run;
    private readonly InputAction m_PlayerControls_Grab;
    private readonly InputAction m_PlayerControls_Torch;
    public struct PlayerControlsActions
    {
        private @RoamerInputActions m_Wrapper;
        public PlayerControlsActions(@RoamerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerControls_Move;
        public InputAction @Shoot => m_Wrapper.m_PlayerControls_Shoot;
        public InputAction @NextWeapon => m_Wrapper.m_PlayerControls_NextWeapon;
        public InputAction @PreviousWeapon => m_Wrapper.m_PlayerControls_PreviousWeapon;
        public InputAction @Run => m_Wrapper.m_PlayerControls_Run;
        public InputAction @Grab => m_Wrapper.m_PlayerControls_Grab;
        public InputAction @Torch => m_Wrapper.m_PlayerControls_Torch;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControlsActions instance)
        {
            if (m_Wrapper.m_PlayerControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnMove;
                @Shoot.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnShoot;
                @NextWeapon.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnNextWeapon;
                @NextWeapon.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnNextWeapon;
                @NextWeapon.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnNextWeapon;
                @PreviousWeapon.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPreviousWeapon;
                @PreviousWeapon.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPreviousWeapon;
                @PreviousWeapon.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnPreviousWeapon;
                @Run.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnRun;
                @Grab.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnGrab;
                @Grab.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnGrab;
                @Grab.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnGrab;
                @Torch.started -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnTorch;
                @Torch.performed -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnTorch;
                @Torch.canceled -= m_Wrapper.m_PlayerControlsActionsCallbackInterface.OnTorch;
            }
            m_Wrapper.m_PlayerControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @NextWeapon.started += instance.OnNextWeapon;
                @NextWeapon.performed += instance.OnNextWeapon;
                @NextWeapon.canceled += instance.OnNextWeapon;
                @PreviousWeapon.started += instance.OnPreviousWeapon;
                @PreviousWeapon.performed += instance.OnPreviousWeapon;
                @PreviousWeapon.canceled += instance.OnPreviousWeapon;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Grab.started += instance.OnGrab;
                @Grab.performed += instance.OnGrab;
                @Grab.canceled += instance.OnGrab;
                @Torch.started += instance.OnTorch;
                @Torch.performed += instance.OnTorch;
                @Torch.canceled += instance.OnTorch;
            }
        }
    }
    public PlayerControlsActions @PlayerControls => new PlayerControlsActions(this);
    public interface IPlayerControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnNextWeapon(InputAction.CallbackContext context);
        void OnPreviousWeapon(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnGrab(InputAction.CallbackContext context);
        void OnTorch(InputAction.CallbackContext context);
    }
}
