using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
       

        Vector3 moveDirection = new Vector3(horizontalInput, 0f).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
