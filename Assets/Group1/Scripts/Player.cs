using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [SerializeField] private Game _game;
    [SerializeField] private Enemy[] _enemies;

    public event UnityAction AllEnemiesKilled;

    private float _distanceToKill = 0.2f;

    private void Update()
    {
        if (_enemies.Length != 0)
        {
            foreach (var enemy in _enemies)
            {
                if (Vector3.Distance(transform.position, enemy.transform.position) < _distanceToKill && enemy.gameObject.activeSelf)
                {
                    enemy.Die();                    
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
}
