using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = target.position;

        newPosition.z = -10;
        transform.position = newPosition;
    }
}
