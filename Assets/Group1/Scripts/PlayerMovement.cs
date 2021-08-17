using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    public float Speed => _speed;

    private void Update()
    {
        float horizontalOffset = Input.GetAxis("Horizontal");
        float verticalOffset = Input.GetAxis("Vertical");

        MoveTo(Vector3.right * horizontalOffset * _speed * Time.deltaTime);
        MoveTo(Vector3.up * verticalOffset * _speed * Time.deltaTime);
    }

    private void MoveTo(Vector3 position)
    {
        transform.Translate(position);
    }

    public void ChangeSpeed(float speed)
    {
        _speed = speed;
    }
}
