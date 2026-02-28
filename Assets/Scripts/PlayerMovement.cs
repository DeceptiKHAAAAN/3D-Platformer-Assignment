using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;
    [SerializeField] float gravity = 9.8f;
    [SerializeField] float jumpForce = 6;

    CharacterController playerController;
    Vector3 movementVector;
    Camera cam;
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        cam = Camera.main;
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 camForward  = cam.transform.forward;
        Vector3 camRight    = cam.transform.right;
        camForward.y        = 0;
        camRight.y          = 0;
        camForward          = camForward.normalized;
        camRight            = camRight.normalized;

        Vector3 forwardRelativeMovementVector   = v * camForward;
        Vector3 rightRelativeMovmentVector      = h * camRight;

        Vector3 inputVector = forwardRelativeMovementVector + rightRelativeMovmentVector;

        movementVector = new Vector3(inputVector.x * moveSpeed  ,
                                     movementVector.y           ,
                                     inputVector.z * moveSpeed  );

        movementVector += Vector3.down * gravity * Time.deltaTime;
        movementVector.y = Mathf.Clamp(movementVector.y, -14, 14);

        if (Input.GetButtonDown("Jump") && playerController.isGrounded)
            movementVector.y = jumpForce;

        playerController.Move(movementVector * Time.deltaTime);
    }
}