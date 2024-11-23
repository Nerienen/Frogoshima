using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float crouchHeight = 0.5f;
    [SerializeField] private float lookSpeed = 3f;
    [SerializeField] private float gravityForce = 9.81f;

    private CharacterController controller;
    private float originalHeight;
    private Transform cameraTransform;
    private Vector3 currentVelocity = Vector3.zero;
    private bool isCrouching = false;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        originalHeight = controller.height;
        cameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        // Move the character
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * vertical + transform.right * horizontal;
        moveDirection = moveDirection.normalized * moveSpeed;

        // Apply gravity
        currentVelocity.y -= gravityForce * Time.deltaTime;

        // Combine move direction and gravity
        moveDirection += currentVelocity;

        // Move the character
        controller.Move(moveDirection * Time.deltaTime);

        // Jump
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            currentVelocity.y = jumpForce;
        }

        // Crouch
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (isCrouching)
            {
                controller.height = originalHeight;
                isCrouching = false;
            }
            else
            {
                controller.height = crouchHeight;
                isCrouching = true;
            }
        }

        // Rotate the camera
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        Vector3 currentRotation = cameraTransform.localRotation.eulerAngles;
        float newRotationX = currentRotation.x - mouseY;
        float newRotationY = currentRotation.y + mouseX;

        cameraTransform.localRotation = Quaternion.Euler(newRotationX, newRotationY, currentRotation.z);
    }
}
