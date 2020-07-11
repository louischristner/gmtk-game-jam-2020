using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 20f;

    public KeyCode keyUp = KeyCode.Z;
    public KeyCode keyLeft = KeyCode.Q;
    public KeyCode keyRight = KeyCode.D;

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(0, 0);

        movement = MoveHorizontal(movement);
        transform.Translate(
            new Vector3(movement.x * moveSpeed * Time.fixedDeltaTime, 0, 0)
        );
    }

    Vector2 MoveHorizontal(Vector2 movement)
    {
        if (Input.GetKey(keyLeft)) {
            movement.x -= 1;
        }

        if (Input.GetKey(keyRight)) {
            movement.x += 1;
        }

        return movement;
    }
}
