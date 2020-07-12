using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask m_WhatIsGround;  // A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;   // A position marking where to check if the player is grounded.

    [Range(0f, 2f)] public float airControl;

    public float moveSpeed = 5f;
    public float jumpForce = 500f;

    public KeyCode keyUp = KeyCode.UpArrow;
    public KeyCode keyLeft = KeyCode.LeftArrow;
    public KeyCode keyRight = KeyCode.RightArrow;

    public Animator animator;

    Vector2 movement;
    bool canJump = true;
    bool isFacingRight = true;

    KeyCode savedKeyUp;
    KeyCode savedKeyLeft;
    KeyCode savedKeyRight;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        savedKeyUp = keyUp;
        savedKeyLeft = keyLeft;
        savedKeyRight = keyRight;
    }

    void Update()
    {
        animator.SetBool("IsJumping", false);

        Move();
        Jump();

        // check if player is on collision with ground / can jump

        bool prevJump = canJump;
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, 0.2f, m_WhatIsGround);

        canJump = false;
		for (int i = 0; i < colliders.Length; i++) {
			if (colliders[i].gameObject != gameObject) {
				canJump = true;
			}
		}

        animator.SetBool("IsFalling", rb.velocity.y < -0.1);
    }

    void Jump()
    {
        if (Input.GetKeyDown(keyUp)) {
            if (canJump) {
                rb.AddForce(new Vector2((jumpForce / 3) * movement.x, jumpForce));
                animator.SetBool("IsJumping", true);
                canJump = false;
            }
        }
    }

    void Move()
    {
        movement = new Vector2(0, 0);

        if (Input.GetKey(keyLeft)) {
            movement.x -= 1;
            if (isFacingRight) {
                Flip();
            }
        }

        if (Input.GetKey(keyRight)) {
            movement.x += 1;
            if (!isFacingRight) {
                Flip();
            }
        }

        animator.SetBool("IsMoving",
            (movement.x != 0) ? true : false
        );

        if (!canJump) {
            movement.x = movement.x * airControl;
        }

        transform.Translate(
            new Vector3(movement.x * moveSpeed * Time.deltaTime, 0, 0)
        );
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void UpdateKeyMapping()
    {
        int index = 0;
        KeyCode up, left, right;
        List<KeyCode> everyKeys = new List<KeyCode> {keyUp, keyLeft, keyRight};

        do {
            index = Random.Range(0, everyKeys.Count);
            up = everyKeys[index];
        } while (up == keyUp);
        everyKeys.Remove(everyKeys[index]);

        index = Random.Range(0, everyKeys.Count);
        left = everyKeys[index];
        everyKeys.Remove(everyKeys[index]);

        index = Random.Range(0, everyKeys.Count);
        right = everyKeys[index];
        everyKeys.Remove(everyKeys[index]);

        keyUp = up;
        keyLeft = left;
        keyRight = right;
    }

    public void ResetKeyMapping()
    {
        keyUp = savedKeyUp;
        keyLeft = savedKeyLeft;
        keyRight = savedKeyRight;
    }
}
