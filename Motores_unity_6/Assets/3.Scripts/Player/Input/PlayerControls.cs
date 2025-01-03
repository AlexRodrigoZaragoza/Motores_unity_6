//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.11.2
//     from Assets/3.Scripts/Player/Input/PlayerControls.inputactions
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

namespace FinalCharacterController
{
    public partial class @PlayerControls: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""PlayerLocomotionMap"",
            ""id"": ""f32d1427-4a1e-4c2e-80b3-82e881f96ea0"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a5b96e60-2771-4a72-a1fb-10ba14c07afc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""Value"",
                    ""id"": ""53709c01-6ec0-432b-ab37-0f14c23ab733"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""09dd1333-791a-4fb6-a11d-d5fbb77488bf"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""82463cb2-76d5-400a-87b8-7a46990fb952"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""8fc0549f-8011-4748-ae3d-870bd25fcfd8"",
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
                    ""id"": ""fbdccc52-c680-4ea9-8c79-3e5624d047ec"",
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
                    ""id"": ""10002f09-19ff-4a83-8a51-98b9376ef459"",
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
                    ""id"": ""c823d265-484f-4055-a4f8-9587ba4a8666"",
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
                    ""id"": ""f4e4f8ad-72c2-48c0-916c-aec0ff85898e"",
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
                    ""id"": ""f67c1bc1-cddc-47fb-9ffd-20464a253b02"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c504851-d16a-47e5-8f5b-b25665c75357"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f223d731-fb5d-42a0-9531-8e03779fcf91"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerActionMap"",
            ""id"": ""5afbe743-84d8-4e13-870d-edaa7f544c49"",
            ""actions"": [
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""b115df3d-0478-4768-a6a7-8030180c5e32"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""f56cb7ec-5731-4349-94ab-435a117fc92d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""54e89df9-e397-4783-a2b3-4764b3e648c0"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""186b7904-c68d-400a-982f-fda65d53f4f0"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // PlayerLocomotionMap
            m_PlayerLocomotionMap = asset.FindActionMap("PlayerLocomotionMap", throwIfNotFound: true);
            m_PlayerLocomotionMap_Move = m_PlayerLocomotionMap.FindAction("Move", throwIfNotFound: true);
            m_PlayerLocomotionMap_Camera = m_PlayerLocomotionMap.FindAction("Camera", throwIfNotFound: true);
            m_PlayerLocomotionMap_Sprint = m_PlayerLocomotionMap.FindAction("Sprint", throwIfNotFound: true);
            m_PlayerLocomotionMap_Jump = m_PlayerLocomotionMap.FindAction("Jump", throwIfNotFound: true);
            // PlayerActionMap
            m_PlayerActionMap = asset.FindActionMap("PlayerActionMap", throwIfNotFound: true);
            m_PlayerActionMap_Crouch = m_PlayerActionMap.FindAction("Crouch", throwIfNotFound: true);
            m_PlayerActionMap_Interact = m_PlayerActionMap.FindAction("Interact", throwIfNotFound: true);
        }

        ~@PlayerControls()
        {
            UnityEngine.Debug.Assert(!m_PlayerLocomotionMap.enabled, "This will cause a leak and performance issues, PlayerControls.PlayerLocomotionMap.Disable() has not been called.");
            UnityEngine.Debug.Assert(!m_PlayerActionMap.enabled, "This will cause a leak and performance issues, PlayerControls.PlayerActionMap.Disable() has not been called.");
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

        // PlayerLocomotionMap
        private readonly InputActionMap m_PlayerLocomotionMap;
        private List<IPlayerLocomotionMapActions> m_PlayerLocomotionMapActionsCallbackInterfaces = new List<IPlayerLocomotionMapActions>();
        private readonly InputAction m_PlayerLocomotionMap_Move;
        private readonly InputAction m_PlayerLocomotionMap_Camera;
        private readonly InputAction m_PlayerLocomotionMap_Sprint;
        private readonly InputAction m_PlayerLocomotionMap_Jump;
        public struct PlayerLocomotionMapActions
        {
            private @PlayerControls m_Wrapper;
            public PlayerLocomotionMapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_PlayerLocomotionMap_Move;
            public InputAction @Camera => m_Wrapper.m_PlayerLocomotionMap_Camera;
            public InputAction @Sprint => m_Wrapper.m_PlayerLocomotionMap_Sprint;
            public InputAction @Jump => m_Wrapper.m_PlayerLocomotionMap_Jump;
            public InputActionMap Get() { return m_Wrapper.m_PlayerLocomotionMap; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerLocomotionMapActions set) { return set.Get(); }
            public void AddCallbacks(IPlayerLocomotionMapActions instance)
            {
                if (instance == null || m_Wrapper.m_PlayerLocomotionMapActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_PlayerLocomotionMapActionsCallbackInterfaces.Add(instance);
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
                @Sprint.started += instance.OnSprint;
                @Sprint.performed += instance.OnSprint;
                @Sprint.canceled += instance.OnSprint;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }

            private void UnregisterCallbacks(IPlayerLocomotionMapActions instance)
            {
                @Move.started -= instance.OnMove;
                @Move.performed -= instance.OnMove;
                @Move.canceled -= instance.OnMove;
                @Camera.started -= instance.OnCamera;
                @Camera.performed -= instance.OnCamera;
                @Camera.canceled -= instance.OnCamera;
                @Sprint.started -= instance.OnSprint;
                @Sprint.performed -= instance.OnSprint;
                @Sprint.canceled -= instance.OnSprint;
                @Jump.started -= instance.OnJump;
                @Jump.performed -= instance.OnJump;
                @Jump.canceled -= instance.OnJump;
            }

            public void RemoveCallbacks(IPlayerLocomotionMapActions instance)
            {
                if (m_Wrapper.m_PlayerLocomotionMapActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IPlayerLocomotionMapActions instance)
            {
                foreach (var item in m_Wrapper.m_PlayerLocomotionMapActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_PlayerLocomotionMapActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public PlayerLocomotionMapActions @PlayerLocomotionMap => new PlayerLocomotionMapActions(this);

        // PlayerActionMap
        private readonly InputActionMap m_PlayerActionMap;
        private List<IPlayerActionMapActions> m_PlayerActionMapActionsCallbackInterfaces = new List<IPlayerActionMapActions>();
        private readonly InputAction m_PlayerActionMap_Crouch;
        private readonly InputAction m_PlayerActionMap_Interact;
        public struct PlayerActionMapActions
        {
            private @PlayerControls m_Wrapper;
            public PlayerActionMapActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Crouch => m_Wrapper.m_PlayerActionMap_Crouch;
            public InputAction @Interact => m_Wrapper.m_PlayerActionMap_Interact;
            public InputActionMap Get() { return m_Wrapper.m_PlayerActionMap; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActionMapActions set) { return set.Get(); }
            public void AddCallbacks(IPlayerActionMapActions instance)
            {
                if (instance == null || m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Add(instance);
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }

            private void UnregisterCallbacks(IPlayerActionMapActions instance)
            {
                @Crouch.started -= instance.OnCrouch;
                @Crouch.performed -= instance.OnCrouch;
                @Crouch.canceled -= instance.OnCrouch;
                @Interact.started -= instance.OnInteract;
                @Interact.performed -= instance.OnInteract;
                @Interact.canceled -= instance.OnInteract;
            }

            public void RemoveCallbacks(IPlayerActionMapActions instance)
            {
                if (m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(IPlayerActionMapActions instance)
            {
                foreach (var item in m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_PlayerActionMapActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public PlayerActionMapActions @PlayerActionMap => new PlayerActionMapActions(this);
        public interface IPlayerLocomotionMapActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnCamera(InputAction.CallbackContext context);
            void OnSprint(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
        }
        public interface IPlayerActionMapActions
        {
            void OnCrouch(InputAction.CallbackContext context);
            void OnInteract(InputAction.CallbackContext context);
        }
    }
}
