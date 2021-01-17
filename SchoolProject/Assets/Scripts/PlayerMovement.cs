using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float movementSpeed;
    public float jumpForce = 5f;
    public Transform feet;
    public LayerMask groundLayers;

    float movementX;

    private bool left, right;

    void Start() {
        right = true;
    }

    // Update is called once per frame
    void Update()
    {
        // get the x movement value from left and right button input
        movementX = Input.GetAxisRaw("Horizontal");

        if (movementX < 0) {
            turnLeft();
        } else if (movementX > 0) {
            turnRight();
        }

        // if space is clicked and player is on the ground then jump
        if (Input.GetButtonDown("Jump") && isGrounded()) {
            Jump();
        }
    }

    void FixedUpdate() {
        /*
        * create a new Vector2
        * movementX = -1 or 0 or 1, depends on which button is clicked
        * multiply it with movementSpeed
        * y velocity stays the same
        */
        Vector2 movement = new Vector2(movementX * movementSpeed, rb.velocity.y);

        rb.velocity = movement;
    }

    void Jump() {
        /*
        * when you jump x velocity stays the same
        * and add jumpForce velocity onto Player to jump
        */
        Vector2 movement = new Vector2(rb.velocity.x, jumpForce);

        rb.velocity = movement;
    }

    public bool isGrounded() {
        // checks if the player is on the ground
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers);

        if (groundCheck != null) {
            return true;
        }

        return false;
    }

    public void turnLeft() {
        if (left) {
            return;
        }
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        left = true;
        right = false;
    }

    public void turnRight() {
        if (right) {
            return;
        }
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        left = false;
        right = true;
    }
}
