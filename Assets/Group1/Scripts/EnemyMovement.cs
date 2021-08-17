using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 Target;
    private int _radius = 4;
    private int _speed = 2;

    private void Start()
    {
        SetTarget(_radius);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target, _speed * Time.deltaTime);
        if (transform.position == Target)
            SetTarget(_radius);
    }

    private void SetTarget(int radius)
    {
        Target = Random.insideUnitCircle * radius;
    }
}
