using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public event UnityAction Dead;

    public void Die()
    {
        Dead?.Invoke();
        gameObject.SetActive(false);
    }
}
