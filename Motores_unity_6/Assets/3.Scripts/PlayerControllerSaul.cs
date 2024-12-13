using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float bendSpeed = 2f;
    public float gravity = 9.81f;

    private CharacterController characterController;

    public float standingHeight = 2f;
    public float bendingHeight = 1f;
    private float verticalVelocity;
    private float currentSpeed;
    private bool isBending = false;
    private bool isRunning = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
    }

    void Update()
    {
        HandleMovement();
        HandleActions();
    }

    void HandleMovement()
    {
        float move = Input.GetAxis("Horizontal");
        if (move != 0 && !isRunning)
            GameManager.Instance.SetPlayerAction(GameManager.PlayerAction.Walking);

        else if(isRunning)
            GameManager.Instance.SetPlayerAction(GameManager.PlayerAction.Running);

        else 
            GameManager.Instance.SetPlayerAction(GameManager.PlayerAction.Idle);

        if (Input.GetKeyDown(KeyCode.LeftControl))
            ToggleBend();

        isRunning = Input.GetKey(KeyCode.LeftShift) && !isBending;
        
        if (isBending)
            currentSpeed = bendSpeed;
        else if (isRunning)
            currentSpeed = runSpeed;
        else
            currentSpeed = walkSpeed;

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveVector = (transform.right * moveX + transform.forward * moveZ) * currentSpeed;

        verticalVelocity -= gravity * Time.deltaTime;
        moveVector.y = verticalVelocity;

        characterController.Move(moveVector * Time.deltaTime);
    }

    void ToggleBend()
    {
        if (isBending)
        {
            characterController.height = standingHeight;
            isBending = false;
        }
        else
        {
            characterController.height = bendingHeight;
            isBending = true;
        }

        Vector3 center = characterController.center;
        center.y = characterController.height / 2f;
        characterController.center = center;
    }

    void HandleActions()
    {
        if (isBending)
            GameManager.Instance.SetPlayerAction(GameManager.PlayerAction.Bend);
        if (Input.GetKeyDown(KeyCode.E))
            GameManager.Instance.SetPlayerAction(GameManager.PlayerAction.Action);

    }
}