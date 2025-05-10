using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour{
    public Rigidbody2D rb;
    bool isFacingRight = true;
    public Animator animator;
    [Header("Movimento")]
    public float moveSpeed = 5f;
    float horizontalMovement;

    [Header("Pulo")]
    public float jumpPower = 10f;

    [Header("Gravidade")]
    public float baseGravity = 2;
    public float maxFallSpeed = 10f;
    public float fallSpeedMultiplier = 2f;

    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        rb.velocity = new Vector2(horizontalMovement * moveSpeed, rb.velocity.y);
        isGrounded();
        Gravity();
        Flip();


        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetFloat("magnitude", rb.velocity.magnitude);
    }

    public void Move(InputAction.CallbackContext context){
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context){
        if(isGrounded()){
            if(context.performed){
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                animator.SetTrigger("Jump");
            }
            else if(context.canceled){
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                animator.SetTrigger("Jump");
            }
        }
    }

    private void Gravity(){
        if(rb.velocity.y < 0){
            rb.gravityScale = baseGravity * fallSpeedMultiplier;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, -maxFallSpeed));
        }
        else{
            rb.gravityScale = baseGravity;
        }
    }

    private bool isGrounded(){
        if(Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer)){
            return true;
        }
        return false;
    }

    private void Flip(){
        if(isFacingRight && horizontalMovement < 0 || !isFacingRight && horizontalMovement > 0){
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(groundCheckPos.position, groundCheckSize);
    }
}
