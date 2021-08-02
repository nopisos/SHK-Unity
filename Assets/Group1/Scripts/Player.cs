using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private bool _timer = true;
    [SerializeField] private float _time = 2;
    [SerializeField] private Enemy[] _enemies;

    public event UnityAction AllEnemiesKilled;

    private float _distanceToKill = 0.2f;

    private void Update()
    {
        if (_timer)
        {
            _time -= Time.deltaTime;

            if(_time <= 0)
            {
                _timer = false;
                _playerMovement.ChangeSpeed(_playerMovement.Speed/2);
            }
        }

        if (_enemies.Length != 0)
        {
            foreach (var enemy in _enemies)
            {
                if (Vector3.Distance(transform.position, enemy.transform.position) < _distanceToKill)
                {
                    enemy.gameObject.SetActive(false);
                }
            }
        }        

        if (IsAllEnemyKilled())
        {
            AllEnemiesKilled.Invoke();            
        }
    }

    private bool IsAllEnemyKilled()
    {
        int killedQuantity = 0;

        foreach (var enemy in _enemies)
        {
            if (!enemy.gameObject.activeSelf)
                killedQuantity += 1;
        }

        return killedQuantity == _enemies.Length;
    } 

    public void IncreaseSpeed()
    {       
        _playerMovement.ChangeSpeed(_playerMovement.Speed * 2);
        _timer = true;
        _time = 2;
    }
}
