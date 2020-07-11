using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 500f;

    public KeyCode keyUp = KeyCode.Z;
    public KeyCode keyLeft = KeyCode.Q;
    public KeyCode keyRight = KeyCode.D;

    public Animator animator;

    bool canJump = true;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (rb.velocity.y == 0) {
            canJump = true;
        } else {
            canJump = false;
        }

        Move();
        Jump();
    }

    void Jump()
    {
        if (Input.GetKeyDown(keyUp)) {
            if (canJump) {
                rb.AddForce(new Vector2(0, jumpForce));
            }
        }
    }

    void Move()
    {
        Vector2 movement = new Vector2(0, 0);

        movement.x = Input.GetKey(keyLeft) ? movement.x - 1 : movement.x;
        movement.x = Input.GetKey(keyRight) ? movement.x + 1 : movement.x;

        animator.SetBool("IsMoving", (movement.x != 0) ? true : false);

        transform.Translate(
            new Vector3(movement.x * moveSpeed * Time.fixedDeltaTime, 0, 0)
        );
    }

    public void UpdateKeyMapping()
    {
        KeyCode up, left, right;

        List<KeyCode> everyKeys = new List<KeyCode> {keyUp, keyLeft, keyRight};

        int index = Random.Range(0, everyKeys.Count);
        up = everyKeys[index];
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
}
