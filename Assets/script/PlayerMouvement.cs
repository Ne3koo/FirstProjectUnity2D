using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public bool isJumping;
    public bool isGrounded;

    public Transform GroundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public CapsuleCollider2D CapsuleCollider2D;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;

    public static PlayerMouvement instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plusieurs instances de PlayerMouvement dans la scène");
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, collisionLayers);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", rb.velocity.x);
        MovePlayer(horizontalMovement);

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Collision sol & saut

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
    }

    //Mouvement droite/gauche
    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    //mouvement flip
    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

     private void OnDrawGizmos()
     {
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(GroundCheck.position, groundCheckRadius);
    }
}
