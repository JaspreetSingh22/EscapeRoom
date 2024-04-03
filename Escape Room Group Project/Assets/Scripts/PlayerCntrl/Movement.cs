using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour {
#pragma warning disable 649

    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 11f;
    Vector2 horizontalInput;

    [SerializeField] float jumpHeight = 3.5f;
    bool jump;

    [SerializeField] float gravity = -30f; // -9.81
    Vector3 verticalVelocity = Vector3.zero;
    [SerializeField] LayerMask groundMask;
    bool isGrounded;

    private void Update ()
    {
        isGrounded = Physics.CheckSphere(transform.position, 0.005f, groundMask);
        if (isGrounded) {
            verticalVelocity.y = 0;
        }

        Vector3 horizontalVelocity = (transform.right * horizontalInput.x + transform.forward * horizontalInput.y) * speed;
        if(controller.enabled == true)
        {
             controller.Move(horizontalVelocity * Time.deltaTime);
        }
        

        // Jump: v = sqrt(-2 * jumpHeight * gravity)
        if (jump) {
            if (isGrounded) {
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            }
            jump = false;
        }

        verticalVelocity.y += gravity * Time.deltaTime;
        if(controller.enabled == true)
        {
             controller.Move(verticalVelocity * Time.deltaTime);
        }
        
    }

    public void ReceiveInput (Vector2 _horizontalInput)
    {
        horizontalInput = _horizontalInput;
    }

    public void OnJumpPressed ()
    {
        jump = true;
    }
    // void OnDrawGizmosSelected()
    // {
    //       Gizmos.DrawSphere(transform.position, 0.005f);
    // }

}