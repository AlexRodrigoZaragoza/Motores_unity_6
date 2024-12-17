using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace FinalCharacterController
{
    [DefaultExecutionOrder(-2)]
    public class PlayerInputAction : MonoBehaviour, PlayerControls.IPlayerActionMapActions
    {
        #region ClassVariables

        public bool CrouchPressed {  get; private set; }
        public bool InteractPressed { get; private set; }

        private PlayerLocomotionInput _playerLocomotionInput;

        #endregion

        #region Startup

        void Awake()
        {
            _playerLocomotionInput = GetComponent<PlayerLocomotionInput>();
        }
        private void OnEnable()
        {
            if (PlayerInputManager.Instance?.PlayerControls == null)
            {
                Debug.LogError("Player controls is not initialized");
                return;
            }

            PlayerInputManager.Instance.PlayerControls.PlayerActionMap.Enable();
            PlayerInputManager.Instance.PlayerControls.PlayerActionMap.SetCallbacks(this);
        }

        private void OnDisable()
        {
            if (PlayerInputManager.Instance?.PlayerControls == null)
            {
                Debug.LogError("player controls is not initialized");
                return;
            }

            PlayerInputManager.Instance.PlayerControls.PlayerActionMap.Enable();
            PlayerInputManager.Instance.PlayerControls.PlayerActionMap.RemoveCallbacks(this);
        }

        #endregion

        #region Update

        private void LateUpdate()
        {
            CrouchPressed = false;
            InteractPressed = false;
        }
        #endregion

        #region InputCallBacks
        public void OnCrouch(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;

            CrouchPressed = true;
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;
            
            InteractPressed = true;
        }

        #endregion
    }



}



