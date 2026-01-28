using UnityEngine;
using UnityEngine.InputSystem;

// Read input from input system
public class PlayerInputHandler : MonoBehaviour
{
    private Vector2 moveInput; // L and R
    private bool jumpTriggered = false; // Jumping?

    // Public properties to read input values
    public Vector2 MoveInput
    {
        // Read only
        get { return moveInput; }
    }

    public bool JumpTriggered
    {
        // Read only
        get { return jumpTriggered; }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // Save input to the field
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context) 
    {
        if (context.started) // Started to push
        {
            jumpTriggered = true;
        }
        else if (context.canceled) // Let go
        {
            jumpTriggered = false;
        }
    }
}
