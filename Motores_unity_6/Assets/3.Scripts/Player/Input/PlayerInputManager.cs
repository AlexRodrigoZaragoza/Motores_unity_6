using FinalCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FinalCharacterController
{
    [DefaultExecutionOrder(-3)]
    public class PlayerInputManager : MonoBehaviour
    {
        public static PlayerInputManager Instance;
        public PlayerControls PlayerControls { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void OnEnable()
        {
            if (PlayerControls == null)
            {
                PlayerControls = new PlayerControls();
                PlayerControls?.Enable();
            }

        }

        private void OnDisable()
        {
            if (PlayerControls != null)
                PlayerControls.Disable();
        }
    }
}
