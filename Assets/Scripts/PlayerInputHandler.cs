using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField]
    private GameEventListener sideCameraActivated;


    [SerializeField]
    private InputActionAsset inputActions;

    [SerializeField]
    private InputActionReference movement;

    [SerializeField]
    private InputActionReference space;


    public float speed = 1f;
    public bool sideCameraActive = false;

    CharacterController characterController;

    private Vector3 movementDirection;
    private bool isWalking=false;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        inputActions.Enable();
        movement.action.started += MovementStarted;
        movement.action.performed += MovementPerformed;
        movement.action.canceled += MovementCanceled;

        space.action.performed += SpacePerformed;
    }

    private void OnDisable()
    {
        movement.action.started -= MovementStarted;
        movement.action.performed -= MovementPerformed;
        movement.action.canceled -= MovementCanceled;

        space.action.performed -= SpacePerformed;
        inputActions.Disable();
    }

    private void Update()
    {
        if (isWalking == true)
        {
            characterController.Move(movementDirection*Time.deltaTime*speed);
        }
        
    }


    private void MovementStarted(InputAction.CallbackContext context)
    {
        Debugger.Log(context, Debugger.PriorityLevel.Low);

        ApplyMovementConditions(context);

    }

    private void MovementPerformed(InputAction.CallbackContext context)
    {
        Debugger.Log(context, Debugger.PriorityLevel.Low);

        ApplyMovementConditions(context);

    }

    private void ApplyMovementConditions(InputAction.CallbackContext context)
    {
        var result = context.ReadValue<Vector2>();
        result.Normalize();

        isWalking = true;

        if (sideCameraActive == false)
        {
           
            movementDirection = result.AsXZ();
        }
        else
        {
            float clampedMovement = result.x;
            movementDirection = transform.forward * clampedMovement;
        }
    }

    private void MovementCanceled(InputAction.CallbackContext context)
    {
        Debugger.Log(context, Debugger.PriorityLevel.Low);

        isWalking = false;

    }


    private void SpacePerformed(InputAction.CallbackContext context)
    {
        sideCameraActivated.OnEventTriggered();
    }

    public void SideCameraActivated()
    {
        sideCameraActive = true;
    }

    public void SideCameraDEActivated()
    {
        sideCameraActive = false;
    }



}
