using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {
#pragma warning disable 649

    [SerializeField] Movement movement;
    [SerializeField] MouseLook mouseLook;
    

    PlayerOne controls;
    PlayerOne.GroundMovementActions groundMovement;

    Vector2 horizontalInput;
    Vector2 mouseInput;
    Animator animator;

    [SerializeField]Locker locker;
   
   

   

    private void Awake ()
    {
        controls = new PlayerOne();
        groundMovement = controls.GroundMovement;
        animator = GetComponentInChildren<Animator>();
        // groundMovement.[action].performed += context => do something
        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

        groundMovement.Jump.performed += _ => movement.OnJumpPressed();

        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();
        groundMovement.Interact.performed +=_ => locker.Interact();


    }

    private void Update ()
    {
        //animator.SetFloat("WalkX", horizontalInput.x);
        //animator.SetFloat("WalkY", horizontalInput .y);
        movement.ReceiveInput(horizontalInput);
        mouseLook.ReceiveInput(mouseInput);
       {
        
       }
    }

    private void OnEnable ()
    {
        controls.Enable();
    }

    private void OnDestroy ()
    {
        controls.Disable();
    }
    


}