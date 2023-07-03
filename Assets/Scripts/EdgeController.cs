using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeController : MonoBehaviour
{
    SessionManager _sessionManager;
    public int contador = 0;

    private void Awake() {
        _sessionManager = SessionManager.Instance;
        _sessionManager.contador.Resetear();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")|| other.CompareTag("Platform"))
        {
            _sessionManager.contador.Incrementar();
            Debug.Log(_sessionManager.contador.contador);
            Destroy(other.gameObject);
        }
    }
}
