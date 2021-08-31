using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;

    private void Update()
    {
        float horizontalOffset = Input.GetAxis("Horizontal");
        float verticalOffset = Input.GetAxis("Vertical");
        Vector3 moveDirection = Vector3.right * horizontalOffset + Vector3.up * verticalOffset;
        MoveTo(moveDirection * Speed * Time.deltaTime);
    }

    private void MoveTo(Vector3 position)
    {
        transform.Translate(position);
    }
}
