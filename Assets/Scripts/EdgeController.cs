using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeController : MonoBehaviour
{
    GameManager _gameManager;
    public int contador = 0;

    private void Start()
    {
        _gameManager=FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Platform"))
        {
            _gameManager.IncreaseEnemiesKilled();
            Destroy(other.gameObject);
        }
    }
}
