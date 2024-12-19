using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FinalCharacterController
{
    public class PlayerState : MonoBehaviour
    {


        [field: SerializeField] public PlayerMovementState CurrentPlayerMovementState { get; private set; } = PlayerMovementState.Idling;

        public void SetPlayerMovementState(PlayerMovementState playerMovementState)
        {
            CurrentPlayerMovementState = playerMovementState;
        }

        public bool InGroudedState()
        {
            return CurrentPlayerMovementState == PlayerMovementState.Idling ||
                   CurrentPlayerMovementState == PlayerMovementState.Walking ||
                   CurrentPlayerMovementState == PlayerMovementState.Running;

        }

    }

    public enum PlayerMovementState
    {
        Idling = 0,
        Walking = 1,
        Running = 2,
        Crouch = 3,
        Crouching = 4,
        Dead = 5,
        Jumping = 6,
        Falling = 7,

    }
}

