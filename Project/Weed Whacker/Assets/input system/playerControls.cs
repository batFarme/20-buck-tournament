//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/input system/playerControls.inputactions
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

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""playerControls"",
    ""maps"": [
        {
            ""name"": ""standing"",
            ""id"": ""13229736-cbac-4942-bd45-4320bd5188fa"",
            ""actions"": [
                {
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""03b0d1bb-740d-4cdd-86a0-7b8171505e4c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""attack"",
                    ""type"": ""Button"",
                    ""id"": ""9935d0f5-c488-4b12-b5e0-b16ed15bd5d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""d3aa368d-f75c-464c-85e4-d1f92e1a6127"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c6ae75d6-0e30-4481-9456-7fb10a843bb0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""94393ef3-c2cf-4ae7-8679-d1aa0f09f255"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7320d2ab-b0aa-4be9-9ade-c3d46e233940"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4d381589-5fa9-40f3-b9c1-6f888ea8a3ff"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""arcade stick"",
                    ""id"": ""3371e72b-1c25-4181-b6ad-703cd08088c8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b634eec4-610f-4b44-896f-b37c809d42f5"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""arcade stick;Debug"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""17a1a623-4a1c-402d-965a-c033a0966a77"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""arcade stick;Debug"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""41139c01-0209-43c4-9070-b54f8b91eed8"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""arcade stick;Debug"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c27bc63a-1bdb-4828-a4ae-d19053a33ea3"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""arcade stick;Debug"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""dpad"",
                    ""id"": ""cf59a257-5903-4d05-b917-68085eb6f53c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c56435cd-f312-46ff-b0df-0b9f118db45f"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""25d3a138-eefc-43fc-8033-0a7bbf66edad"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""db60dc28-0f12-4a36-96a0-3abb164666d1"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9694c4cf-56f6-47c6-b355-0814595f9fc5"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""arcade stick hardware"",
                    ""id"": ""ca1c3a5b-a9d4-4c14-adee-4dddce47bddf"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ab034de1-806f-44d4-9193-d33b43b41fdb"",
                    ""path"": ""<HID::Microntek              USB Joystick          >/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1e64359d-3570-42f9-b436-fa973062958b"",
                    ""path"": ""<HID::Microntek              USB Joystick          >/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a4d3a78b-388c-4806-9f2d-f033b750f256"",
                    ""path"": ""<HID::Microntek              USB Joystick          >/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8e828232-fc43-4638-a6f4-549661166816"",
                    ""path"": ""<HID::Microntek              USB Joystick          >/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug"",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3918828e-a1df-40d1-881f-7c5e12e2ac83"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug"",
                    ""action"": ""attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4479f281-f557-4c7e-a338-3456d7ceb645"",
                    ""path"": ""<HID::Microntek              USB Joystick          >/button12"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""arcade stick;Debug"",
                    ""action"": ""attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""decc1fe9-7269-4300-bf54-9c465a12b37a"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug"",
                    ""action"": ""attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b91075a-0528-4325-acfc-245bb3fcd169"",
                    ""path"": ""<Joystick>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""arcade stick;Debug"",
                    ""action"": ""attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""feee65b1-07ab-48fe-9353-fe3fafe8ea58"",
                    ""path"": ""<HID::Microntek              USB Joystick          >/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""arcade stick;Debug"",
                    ""action"": ""attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""toJoin"",
            ""id"": ""089b36a6-7596-4864-b9eb-9d42ab3291f8"",
            ""actions"": [
                {
                    ""name"": ""join game"",
                    ""type"": ""Button"",
                    ""id"": ""3ad4a94f-e350-4841-b434-3aeac68bed67"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2f4bde58-0e55-4a34-bdad-3511466b158a"",
                    ""path"": ""<HID::Microntek              USB Joystick          >/button12"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""arcade stick"",
                    ""action"": ""join game"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f08f928-f78e-40db-9637-eeffdb22c1df"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug"",
                    ""action"": ""join game"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""822bf30e-821b-45b0-8aad-8e308cc2d9c9"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Debug"",
                    ""action"": ""join game"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""arcade stick"",
            ""bindingGroup"": ""arcade stick"",
            ""devices"": [
                {
                    ""devicePath"": ""<Joystick>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Debug"",
            ""bindingGroup"": ""Debug"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<HID::Microntek              USB Joystick          >"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // standing
        m_standing = asset.FindActionMap("standing", throwIfNotFound: true);
        m_standing_move = m_standing.FindAction("move", throwIfNotFound: true);
        m_standing_attack = m_standing.FindAction("attack", throwIfNotFound: true);
        // toJoin
        m_toJoin = asset.FindActionMap("toJoin", throwIfNotFound: true);
        m_toJoin_joingame = m_toJoin.FindAction("join game", throwIfNotFound: true);
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

    // standing
    private readonly InputActionMap m_standing;
    private List<IStandingActions> m_StandingActionsCallbackInterfaces = new List<IStandingActions>();
    private readonly InputAction m_standing_move;
    private readonly InputAction m_standing_attack;
    public struct StandingActions
    {
        private @PlayerControls m_Wrapper;
        public StandingActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @move => m_Wrapper.m_standing_move;
        public InputAction @attack => m_Wrapper.m_standing_attack;
        public InputActionMap Get() { return m_Wrapper.m_standing; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StandingActions set) { return set.Get(); }
        public void AddCallbacks(IStandingActions instance)
        {
            if (instance == null || m_Wrapper.m_StandingActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_StandingActionsCallbackInterfaces.Add(instance);
            @move.started += instance.OnMove;
            @move.performed += instance.OnMove;
            @move.canceled += instance.OnMove;
            @attack.started += instance.OnAttack;
            @attack.performed += instance.OnAttack;
            @attack.canceled += instance.OnAttack;
        }

        private void UnregisterCallbacks(IStandingActions instance)
        {
            @move.started -= instance.OnMove;
            @move.performed -= instance.OnMove;
            @move.canceled -= instance.OnMove;
            @attack.started -= instance.OnAttack;
            @attack.performed -= instance.OnAttack;
            @attack.canceled -= instance.OnAttack;
        }

        public void RemoveCallbacks(IStandingActions instance)
        {
            if (m_Wrapper.m_StandingActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IStandingActions instance)
        {
            foreach (var item in m_Wrapper.m_StandingActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_StandingActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public StandingActions @standing => new StandingActions(this);

    // toJoin
    private readonly InputActionMap m_toJoin;
    private List<IToJoinActions> m_ToJoinActionsCallbackInterfaces = new List<IToJoinActions>();
    private readonly InputAction m_toJoin_joingame;
    public struct ToJoinActions
    {
        private @PlayerControls m_Wrapper;
        public ToJoinActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @joingame => m_Wrapper.m_toJoin_joingame;
        public InputActionMap Get() { return m_Wrapper.m_toJoin; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ToJoinActions set) { return set.Get(); }
        public void AddCallbacks(IToJoinActions instance)
        {
            if (instance == null || m_Wrapper.m_ToJoinActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_ToJoinActionsCallbackInterfaces.Add(instance);
            @joingame.started += instance.OnJoingame;
            @joingame.performed += instance.OnJoingame;
            @joingame.canceled += instance.OnJoingame;
        }

        private void UnregisterCallbacks(IToJoinActions instance)
        {
            @joingame.started -= instance.OnJoingame;
            @joingame.performed -= instance.OnJoingame;
            @joingame.canceled -= instance.OnJoingame;
        }

        public void RemoveCallbacks(IToJoinActions instance)
        {
            if (m_Wrapper.m_ToJoinActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IToJoinActions instance)
        {
            foreach (var item in m_Wrapper.m_ToJoinActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_ToJoinActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public ToJoinActions @toJoin => new ToJoinActions(this);
    private int m_arcadestickSchemeIndex = -1;
    public InputControlScheme arcadestickScheme
    {
        get
        {
            if (m_arcadestickSchemeIndex == -1) m_arcadestickSchemeIndex = asset.FindControlSchemeIndex("arcade stick");
            return asset.controlSchemes[m_arcadestickSchemeIndex];
        }
    }
    private int m_DebugSchemeIndex = -1;
    public InputControlScheme DebugScheme
    {
        get
        {
            if (m_DebugSchemeIndex == -1) m_DebugSchemeIndex = asset.FindControlSchemeIndex("Debug");
            return asset.controlSchemes[m_DebugSchemeIndex];
        }
    }
    public interface IStandingActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
    }
    public interface IToJoinActions
    {
        void OnJoingame(InputAction.CallbackContext context);
    }
}
