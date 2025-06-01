using Paulos.Projectiles;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject orderArea;

    [SerializeField]
    private Transform characterVisual;

    [SerializeField]
    private PlayerWeapon playerWeapon;

    [SerializeField]
    private GameEventListener sideCameraActivated;


    [SerializeField]
    private InputActionAsset inputActions;

    [SerializeField]
    private InputActionReference movement;

    [SerializeField]
    private InputActionReference space;


    public float speed = 1f;
    public bool isSideCameraActive = false;

    CharacterController characterController;

    private Vector3 movementDirection;
    private bool isWalking=false;
    private bool isSpaced=false;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        //inputActions.Enable();
        movement.action.started += MovementStarted;
        movement.action.performed += MovementPerformed;
        movement.action.canceled += MovementCanceled;
        
        space.action.started += SpaceStarted;
        space.action.performed += SpacePerformed;
        space.action.canceled += SpaceCanceled; 
    }

    private void OnDisable()
    {
        movement.action.started -= MovementStarted;
        movement.action.performed -= MovementPerformed;
        movement.action.canceled -= MovementCanceled;

        space.action.started-= SpaceStarted;
        space.action.performed -= SpacePerformed;
        space.action.canceled -= SpaceCanceled;
        inputActions.Disable();
    }

    private void Update()
    {
        if (isWalking == true)
        {
            characterController.Move(movementDirection*Time.deltaTime*speed);
            characterVisual.LookAt(movementDirection+transform.position, Vector3.up);
        }
        
        if(isSpaced == true)
        {
            if(isSideCameraActive == false)
            {
                if(orderArea.activeInHierarchy == false)
                {
                    orderArea.transform.position = transform.position+Vector3.down;
                    orderArea.SetActive(true);
                }
               
            }
            else
            {
                playerWeapon.Shoot();
            }
            
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

        if (isSideCameraActive == false)
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

    private void SpaceStarted(InputAction.CallbackContext context)
    {
        Debugger.Log(context, Debugger.PriorityLevel.Medium);

        isSpaced = true;
    }

    private void SpacePerformed(InputAction.CallbackContext context)
    {
        Debugger.Log(context, Debugger.PriorityLevel.Medium);
    }

    private void SpaceCanceled(InputAction.CallbackContext context)
    {
        Debugger.Log(context, Debugger.PriorityLevel.Medium);

        isSpaced = false;
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
