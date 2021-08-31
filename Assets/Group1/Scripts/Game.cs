using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject EndScreen;
    
    private void OnEnable()
    {
        _player.AllEnemiesKilled += End;
    }

    private void OnDisable()
    {
        _player.AllEnemiesKilled -= End;
    }

    private void End()
    {
        EndScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
