using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FinalCharacterController
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private float LocomotionBlendSpeed = 0.02f;

        private PlayerLocomotionInput _playerLocomotionInput;
        private PlayerState _playerState;
        private PlayerController _playerController;
        private PlayerInputAction _playerInputAction;

        //Locomotion

        private static int inputXHash = Animator.StringToHash("inputX");
        private static int inputYHash = Animator.StringToHash("inputY");
        private static int inputMagnitudeHash = Animator.StringToHash("inputMagnitude");

        //Actions

        private static int isCrouchingHash = Animator.StringToHash("Crouch");
        private static int isInteractingHash = Animator.StringToHash("Interact");

        private Vector3 _currentBlendInput = Vector3.zero;

        private void Awake()
        {
            _playerLocomotionInput = GetComponent<PlayerLocomotionInput>();
            _playerState = GetComponent<PlayerState>();
            _playerInputAction = GetComponent<PlayerInputAction>();
        }

        private void Update()
        {
            UpdateAnimationState();
        }

        void UpdateAnimationState()
        {
            bool isSprinting = _playerState.CurrentPlayerMovementState == PlayerMovementState.Running;

            Vector2 inputTarget = isSprinting ? _playerLocomotionInput.MovementInput * 1.5f : _playerLocomotionInput.MovementInput;
            _currentBlendInput = Vector3.Lerp(_currentBlendInput, inputTarget, LocomotionBlendSpeed * Time.deltaTime);


            _animator.SetBool(isInteractingHash, _playerInputAction.InteractPressed);
            _animator.SetBool(isCrouchingHash, _playerInputAction.CrouchPressed);


            _animator.SetFloat(inputXHash, _currentBlendInput.x);
            _animator.SetFloat(inputYHash, _currentBlendInput.y);
            _animator.SetFloat(inputMagnitudeHash, _currentBlendInput.magnitude);
        }

    }
}

