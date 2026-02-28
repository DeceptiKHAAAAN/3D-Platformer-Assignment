using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1;
    [SerializeField] float gravity = 9.8f;
    [SerializeField] float jumpForce = 6;

    CharacterController playerController;
    Vector3 movementVector;
    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 inputVector = new Vector3(h, 0, v);

        movementVector = new Vector3(inputVector.x * moveSpeed  ,
                                     movementVector.y           ,
                                     inputVector.z * moveSpeed  );

        movementVector += Vector3.down * gravity * Time.deltaTime;

        movementVector.y = Mathf.Clamp(movementVector.y, -14, 14);

        if (Input.GetButtonDown("Jump"))
            movementVector.y = jumpForce;

        playerController.Move(movementVector * Time.deltaTime);
    }
}