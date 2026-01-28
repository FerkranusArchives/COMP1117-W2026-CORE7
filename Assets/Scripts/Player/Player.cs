using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerInputHandler),typeof(Rigidbody2D))]
public class Player : Character
{
   
     

    [SerializeField] public Slider healthBar;

    [Header("Movement Settings")]
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;

    // Components
    
    
    private Rigidbody2D rBody; // Used to apply force
    private PlayerInputHandler input; // Readsinput
    private bool isGrounded; // Holds result of ground check operation

    protected override void Awake()
    {
        base.Awake();
        // Initialize
        
        rBody = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();
       // stats = new PlayerStats(initialSpeed, initialHealth);
    }

    private void Update()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        // Debug.Log(isGrounded); // Removed due to flooding
        anim.SetFloat("xVelocity", Mathf.Abs(rBody.linearVelocity.x));

        anim.SetBool("IsGrounded", isGrounded);
        anim.SetFloat("yVelocity", rBody.linearVelocity.y);

        // Sprite flipping
        if(input.MoveInput.x != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(input.MoveInput.x), 1, 1);
        }
    }
    void FixedUpdate()
    {
        HealthBarControl();
        if (IsDead)
        {
            return;
        }
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement()
    {
        float horizontalVelocity = input.MoveInput.x * MoveSpeed;
        rBody.linearVelocity = new Vector2(horizontalVelocity, rBody.linearVelocity.y);
    }

    private void HealthBarControl()
    {
        healthBar.value = CurrentHealth;
        if (healthBar.value <= 0) { healthBar.image.color = Color.clear; }
        else if (healthBar.value <= 50 && healthBar.value > 0)
        {
            healthBar.image.color = Color.red;
        }
    }

    private void HandleJump()
    {
        if (input.JumpTriggered && isGrounded)
        {
            ApplyJumpForce();
        }
        
    }

    private void ApplyJumpForce()
    {
        // Reset vertical velocity to ensure consistent jump height
        rBody.linearVelocity = new Vector2(rBody.linearVelocity.x, 0);

        rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
