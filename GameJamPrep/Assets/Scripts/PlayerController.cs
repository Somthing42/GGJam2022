using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //the camera
    [SerializeField] Transform playerCamera = null;
    //the speed of the mouse/camera
    [SerializeField] float mouseSpeed = 3.5f;
    //speed of the player
    [SerializeField] float walkSpeed = 6.0f;
    [SerializeField] float gravity = -13.0f;
    [SerializeField][Range(0.0f,0.5f)] float moveSmoothTime = 0.3f;
    [SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;

    //cursor is locked to the screen
    [SerializeField] bool lockCursor = true;
    //holds the camera's x rotation
    float cameraPitch = 0.0f;
    float velocityY = 0.0f;
    CharacterController controller = null;

    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        updateMouseLook();
        updateMovement();
    }

    void updateMouseLook()
    {
        //gets the movement from the mouse
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        //moves camera up and down
        cameraPitch -= currentMouseDelta.y * mouseSpeed;

        //clamps up/down movement to not spin upside down
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        //moves the player camera left and right
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSpeed);

    }

    void updateMovement()
    {
        //gets the axis for diretional mevement
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //normalizes the input direction so diaginal movement remains consistant to vertical and horizontal
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if (controller.isGrounded)
        {
            velocityY = 0.0f;
        }
        velocityY += gravity * Time.deltaTime;   


        //set velocity of player movement
        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed +Vector3.up * velocityY;

        controller.Move(velocity * Time.deltaTime);

    }
}
