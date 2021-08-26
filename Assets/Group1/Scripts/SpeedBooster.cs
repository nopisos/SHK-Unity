using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private float _boostTime;
    [SerializeField] private float _speedOffset;

    private void OnEnable()
    {
        _enemy.Dead += Boost;
    }

    private void OnDisable()
    {
        _enemy.Dead -= Boost;
    }

    private void Boost()
    {
        StartCoroutine(StartBoost());
    }

    private IEnumerator StartBoost()
    {
        _playerMovement.Speed += _speedOffset;
        yield return new WaitForSeconds(_boostTime);
        _playerMovement.Speed -= _speedOffset;
    }
}

