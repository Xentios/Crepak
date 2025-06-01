using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandlerNonClick : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset inputActions;

    [SerializeField]
    private InputActionReference movement;

    public LayerMask groundLayer;
    private bool isSideCameraActive;
    private bool isWalking;
    private bool isSpaced;
    [SerializeField]
    private Transform characterVisual;
    private CharacterController characterController;
    [SerializeField]
    private float speed = 1f;
    private Vector3 movementDirection;
    private Vector2 mousePosition;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Start()
    {
        movementDirection = Vector3.zero;
        mousePosition = Vector2.zero;
    }

    private void OnEnable()
    {
        //inputActions.Enable();
        movement.action.started += MovementStarted;
        movement.action.performed += MovementPerformed;
        movement.action.canceled += MovementCanceled;


    }



    private void OnDisable()
    {
        movement.action.started -= MovementStarted;
        movement.action.performed -= MovementPerformed;
        movement.action.canceled -= MovementCanceled;


        // inputActions.Disable();
    }
    private void MovementCanceled(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    private void MovementPerformed(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
    }
    private void MovementStarted(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    private void Update()
    {
        if (isSideCameraActive == false)
        {

            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000f, groundLayer))
            {
                movementDirection = hit.point - transform.position;
                movementDirection.y = 0;
            }

        }
        else
        {
            if (mousePosition.x < Screen.width / 2f)
            {
                movementDirection = Vector3.left * 5f;
            }
            else
            {
                movementDirection = Vector3.right * 5f;
            }
        }

        characterController.Move(movementDirection * Time.deltaTime * speed);
        characterVisual.LookAt(movementDirection + transform.position, Vector3.up);


    }


    public void SideCameraActivated()
    {
        isSideCameraActive = true;
    }

    public void SideCameraDEActivated()
    {
        isSideCameraActive = false;
    }


}
