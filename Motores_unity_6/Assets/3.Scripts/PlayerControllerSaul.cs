using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float bendSpeed = 2f;
    public float gravity = 9.81f;

    public float mouseSensitivity = 2000f;
    private float xRotation = 0f;

    private CharacterController characterController;
    public Transform cameraTransform;

    public float standingHeight;
    public float bendingHeight;
    private float verticalVelocity;
    private float currentSpeed;
    private bool isBending = false;
    private bool isRunning = false;

    void Start() {
        characterController = GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
        standingHeight = characterController.height;
        bendingHeight = standingHeight / 2;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update() {
        HandleMovement();
        HandleActions();
        HandleLook();
    }

    void HandleMovement() {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if ((moveX != 0 || moveZ != 0) && !isRunning && !isBending)
            GameManager.Instance.SetPlayerAction(GameManager.PlayerAction.Walking);
        else if ((moveX != 0 || moveZ != 0) && isRunning)
            GameManager.Instance.SetPlayerAction(GameManager.PlayerAction.Running);
        else if (!isBending)
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

        Vector3 moveVector = (transform.right * moveX + transform.forward * moveZ) * currentSpeed;

        verticalVelocity -= gravity * Time.deltaTime;
        moveVector.y = verticalVelocity;

        characterController.Move(moveVector * Time.deltaTime);
    }

    void ToggleBend() {
        if (isBending) {
            characterController.height = standingHeight;
            isBending = false;
            cameraTransform.localPosition = new Vector3(cameraTransform.localPosition.x, standingHeight / 2f, cameraTransform.localPosition.z);
        }
        else {
            characterController.height = bendingHeight;
            isBending = true;
            cameraTransform.localPosition = new Vector3(cameraTransform.localPosition.x, bendingHeight / 2f, cameraTransform.localPosition.z);
        }

        Vector3 center = characterController.center;
        center.y = characterController.height / 2f;
        characterController.center = center;

        if (isBending)
            GameManager.Instance.SetPlayerAction(GameManager.PlayerAction.Bend);
    }

    void HandleActions() {
        if (Input.GetKeyDown(KeyCode.E))
            GameManager.Instance.SetPlayerAction(GameManager.PlayerAction.Action);
    }

    void HandleLook() {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }
}
