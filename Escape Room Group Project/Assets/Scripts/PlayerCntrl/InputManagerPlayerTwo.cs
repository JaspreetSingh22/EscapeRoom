using UnityEngine;
using System.Collections;

public class InputManagerPlayerTwo : MonoBehaviour {
#pragma warning disable 649

    [SerializeField] Movement movement;
    [SerializeField] MouseLook mouseLook;
    

    PlayerTwo controls;
    PlayerTwo.GroundMovementActions groundMovement;

    Vector2 horizontalInput;
    Vector2 mouseInput;

   

    private void Awake ()
    {
        controls = new PlayerTwo();
        groundMovement = controls.GroundMovement;

        // groundMovement.[action].performed += context => do something
        groundMovement.HorizontalMovement.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();

        groundMovement.Jump.performed += _ => movement.OnJumpPressed();

        groundMovement.MouseX.performed += ctx => mouseInput.x = ctx.ReadValue<float>();
        groundMovement.MouseY.performed += ctx => mouseInput.y = ctx.ReadValue<float>();


    }

    private void Update ()
    {
        movement.ReceiveInput(horizontalInput);
        mouseLook.ReceiveInput(mouseInput);
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