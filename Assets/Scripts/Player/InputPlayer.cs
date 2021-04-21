// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputPlayer.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputPlayer : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputPlayer()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputPlayer"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""87987f31-add6-4a09-b415-ed76b5391ca7"",
            ""actions"": [
                {
                    ""name"": ""MovementLeftRight"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3fc05b21-10cb-42c5-ac0e-cc5cc952e075"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5ef2a5f9-ed7c-4a52-be27-4995c789c5de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0a3c4116-7c5a-4fe6-a6b7-b3e88f349c4a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Melee"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4a721fa7-2bec-4eb5-95bd-351ee503c75a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""923db5a3-3b0b-4b30-b3f6-3d1a6253eb91"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementLeftRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0a6e13fc-8d23-44b0-a3a4-b84259ad17bf"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerScheme"",
                    ""action"": ""MovementLeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f5478a52-7fca-4ab2-95a5-21413c97c254"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerScheme"",
                    ""action"": ""MovementLeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""cb6db547-c1ab-4b2f-83c8-d5cf3ccb673e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementLeftRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c6c2d37e-b5f2-431a-ae8b-206c3e665e39"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerScheme"",
                    ""action"": ""MovementLeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a723dcb5-e165-42a6-ba4c-a331327a705d"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerScheme"",
                    ""action"": ""MovementLeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""16d26cde-6cde-43b2-9406-79cd2a2defd5"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerScheme"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14be6d62-9b48-4bf0-bfbe-5adebcbf8790"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerScheme"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""969fd704-6218-454b-817f-73151ff163dd"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerScheme"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bab870b-a719-4b53-bf15-62edc4117fc9"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerScheme"",
                    ""action"": ""Melee"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PlayerScheme"",
            ""bindingGroup"": ""PlayerScheme"",
            ""devices"": []
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_MovementLeftRight = m_Player.FindAction("MovementLeftRight", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Shoot = m_Player.FindAction("Shoot", throwIfNotFound: true);
        m_Player_Melee = m_Player.FindAction("Melee", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_MovementLeftRight;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Shoot;
    private readonly InputAction m_Player_Melee;
    public struct PlayerActions
    {
        private @InputPlayer m_Wrapper;
        public PlayerActions(@InputPlayer wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementLeftRight => m_Wrapper.m_Player_MovementLeftRight;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Shoot => m_Wrapper.m_Player_Shoot;
        public InputAction @Melee => m_Wrapper.m_Player_Melee;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @MovementLeftRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementLeftRight;
                @MovementLeftRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementLeftRight;
                @MovementLeftRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementLeftRight;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Shoot.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShoot;
                @Melee.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMelee;
                @Melee.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMelee;
                @Melee.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMelee;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MovementLeftRight.started += instance.OnMovementLeftRight;
                @MovementLeftRight.performed += instance.OnMovementLeftRight;
                @MovementLeftRight.canceled += instance.OnMovementLeftRight;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Melee.started += instance.OnMelee;
                @Melee.performed += instance.OnMelee;
                @Melee.canceled += instance.OnMelee;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_PlayerSchemeSchemeIndex = -1;
    public InputControlScheme PlayerSchemeScheme
    {
        get
        {
            if (m_PlayerSchemeSchemeIndex == -1) m_PlayerSchemeSchemeIndex = asset.FindControlSchemeIndex("PlayerScheme");
            return asset.controlSchemes[m_PlayerSchemeSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovementLeftRight(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnMelee(InputAction.CallbackContext context);
    }
}
