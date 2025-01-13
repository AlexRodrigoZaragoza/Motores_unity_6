using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace FinalCharacterController
{
    [DefaultExecutionOrder(-1)]
    public class PlayerController : MonoBehaviour
    {
        #region Variables
        [Header("Components")]
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Camera _playerCamera;

        [Header("Base Movement")]
        public float runAcceleration = 0.25f;
        public float runSpeed = 4f;
        public float sprintAcceleration = 0.5f;
        public float sprintSpeed = 7f;
        public float drag = 20f;
        public float movingThreshold = 0.01f;
        public float gravity = 25f;
        public float jumpSpeed = 1.0f;

        bool misco;

        [Header("Camera Settings")]
        public float lookSenseH = 0.1f;
        public float lookSenseV = 0.1f;
        public float lookLimitv = 89f;




        private float stamineValue = 10;
        public Image barraEstamina;

        private PlayerLocomotionInput _playerLocomotionInput;
        private PlayerState _playerState;
        private Vector2 _cameraRotation = Vector2.zero;
        private Vector2 _playerTargetRotation = Vector2.zero;

        Vector3 movementDirection;

        GameManager gameManager;

        private float _verticalVelocity = 0f;
        #endregion

        #region Startup
        private void Awake()
        {
            _playerLocomotionInput = GetComponent<PlayerLocomotionInput>();
            _playerState = GetComponent<PlayerState>();
            Time.timeScale = 1f;
            gameManager = FindFirstObjectByType<GameManager>();

            gameManager.canmoveCamera = true;
        }

        #endregion

        #region Update Logic
        private void Update()
        {
            UpdateMovementState();
            HandleVerticalMovement();
            HandleLateralMovement();



            barraEstamina.fillAmount = stamineValue / 10f;

//            Debug.Log(_characterController.velocity.y);
//            Debug.Log(_playerState.InGroudedState());
        }

        private void UpdateMovementState()
        {

            bool isMovementInput = _playerLocomotionInput.MovementInput != Vector2.zero;
            bool isMovingLaterally = IsMovingLaterally();
            bool isSprinting = _playerLocomotionInput.SprintToggleOn && isMovingLaterally;
            bool isGrounded = IsGrounded();

            if (isSprinting)
            {
                if (stamineValue <= 0)
                {
                    StamineReloading();
                    sprintSpeed = 4f;
                }
                else
                {
                    StamineGoingDown();
                    sprintSpeed = 7f;
                }
            }
            else
            {
                if (stamineValue < 10)
                {
                    StamineReloading();
                }
                else
                {
                    stamineValue = 10;
                }
            }

            PlayerMovementState lateralState = isSprinting ? PlayerMovementState.Running :
                isMovingLaterally || isMovementInput ? PlayerMovementState.Walking : PlayerMovementState.Idling;

            _playerState.SetPlayerMovementState(lateralState);

            if (!isGrounded && _characterController.velocity.y > 0f)
            {
                _playerState.SetPlayerMovementState(PlayerMovementState.Jumping);

            }
            else if (!isGrounded && _characterController.velocity.y <= 0f)
            {
                _playerState.SetPlayerMovementState(PlayerMovementState.Falling);
            }


        }

        private void HandleVerticalMovement()
        {
            bool isGrounded = _playerState.InGroudedState();

            if (isGrounded && _verticalVelocity <= 0)
            {
                _verticalVelocity = 0;
            }
            _verticalVelocity -= gravity * Time.deltaTime;

            if (_playerLocomotionInput.JumpPressed && isGrounded)
            {
                _verticalVelocity += Mathf.Sqrt(jumpSpeed * gravity * 3);
            }


        }

        private void StamineGoingDown()
        {
            stamineValue -= Time.deltaTime * 3f;
        }

        private void StamineReloading()
        {
            stamineValue += Time.deltaTime * 0.5f;
        }

        private void HandleLateralMovement()
        {
            if (gameManager.canmoveCamera)
            {
                bool isSprinting = _playerState.CurrentPlayerMovementState == PlayerMovementState.Running;
                bool isGrounded = _playerState.InGroudedState();

                float lateralAcceleration = isSprinting ? sprintAcceleration : runAcceleration;
                float clampLateralMagnitude = isSprinting ? sprintSpeed : runSpeed;



                Vector3 cameraForwardXZ = new Vector3(_playerCamera.transform.forward.x, 0f, _playerCamera.transform.forward.z).normalized;
                Vector3 cameraRightXZ = new Vector3(_playerCamera.transform.right.x, 0f, _playerCamera.transform.right.z).normalized;
                movementDirection = cameraRightXZ * _playerLocomotionInput.MovementInput.x + cameraForwardXZ * _playerLocomotionInput.MovementInput.y;



                Vector3 movementDelta = movementDirection * lateralAcceleration;
                Vector3 newVelocity = _characterController.velocity + movementDelta;

                // Add drag to player
                Vector3 currentDrag = newVelocity.normalized * drag * Time.deltaTime;
                newVelocity = (newVelocity.magnitude > drag * Time.deltaTime) ? newVelocity - currentDrag : Vector3.zero;
                newVelocity = Vector3.ClampMagnitude(newVelocity, clampLateralMagnitude);
                newVelocity.y = _verticalVelocity;
                // Move character (Unity suggests only calling this once per tick)
                _characterController.Move(newVelocity * Time.deltaTime);
            }

        }
        #endregion

        #region Late Update Logic
        private void LateUpdate()
        {
            if (gameManager.canmoveCamera)
            {
                _cameraRotation.x += lookSenseH * _playerLocomotionInput.LookInput.x;
                _cameraRotation.y = Mathf.Clamp(_cameraRotation.y - lookSenseV * _playerLocomotionInput.LookInput.y, -lookLimitv, lookLimitv);

                _playerTargetRotation.x += transform.eulerAngles.x + lookSenseH * _playerLocomotionInput.LookInput.x;
                transform.rotation = Quaternion.Euler(0f, _playerTargetRotation.x, 0f);

                _playerCamera.transform.rotation = Quaternion.Euler(_cameraRotation.y, _cameraRotation.x, 0f);
            }

        }
        #endregion

        #region State Checks
        private bool IsMovingLaterally()
        {
            Vector3 lateralVelocity = new Vector3(_characterController.velocity.x, 0f, _characterController.velocity.z);

            return lateralVelocity.magnitude > movingThreshold;

        }

        private bool IsGrounded()
        {
            return _characterController.isGrounded;
        }
        #endregion

    }
}
