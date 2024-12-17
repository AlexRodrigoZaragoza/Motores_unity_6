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

    }

    public enum PlayerMovementState
    {
        Idling = 0,
        Walking = 1,
        Running = 2,
        Crouch = 3,
        Crouching = 4,
        Dead = 5,

    }
}

