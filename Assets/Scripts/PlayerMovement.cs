using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;
    [SerializeField] float gravity = 9.8f;
    [SerializeField] float jumpForce = 6;

    [SerializeField] Animator animator;

    CharacterController playerController;
    Vector3 movementVector;
    Camera cam;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerController = GetComponent<CharacterController>();
        cam = Camera.main;
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // ---------- Relative Camera Movement ----------

        Vector3 camForward  = cam.transform.forward;
        Vector3 camRight    = cam.transform.right;
        camForward.y        = 0;
        camRight.y          = 0;
        camForward          = camForward.normalized;
        camRight            = camRight.normalized;
        
        Vector3 forwardRelativeMovementVector   = v * camForward;
        Vector3 rightRelativeMovmentVector      = h * camRight;

        // ---------- Relative Camera Movement ----------

        Vector3 inputVector = forwardRelativeMovementVector + rightRelativeMovmentVector;

        animator.transform.forward = inputVector;

        movementVector = new Vector3(inputVector.x * moveSpeed  ,
                                     movementVector.y           ,
                                     inputVector.z * moveSpeed  );

        movementVector += Vector3.down * gravity * Time.deltaTime;
        movementVector.y = Mathf.Clamp(movementVector.y, -14, 14);

        if (Input.GetButtonDown("Jump") && playerController.isGrounded)
        {
            movementVector.y = jumpForce;
            animator.SetBool("isJumping", true);
        }
        else if (playerController.isGrounded)
        {
            animator.SetBool("isJumping", false);
        }

        if (h != 0 || v != 0)
            animator.SetBool("isRunning", true);
        else
            animator.SetBool("isRunning", false);

            playerController.Move(movementVector * Time.deltaTime);
    }
}