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
        WaitForSeconds delay = new WaitForSeconds(_boostTime);

        _playerMovement.ChangeSpeed(_playerMovement.Speed + _speedOffset);
        Debug.Log(_playerMovement.Speed);
        yield return delay;
        _playerMovement.ChangeSpeed(_playerMovement.Speed - _speedOffset);
        Debug.Log(_playerMovement.Speed);

    }
}

