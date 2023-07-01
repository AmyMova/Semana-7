using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeController : MonoBehaviour
{
    SessionManager sessionManager;

    private void Awake() {
        sessionManager = SessionManager.Instance;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")|| other.CompareTag("Platform"))
        {
            sessionManager.contador.Incrementar();
            Destroy(other.gameObject);
        }
    }
}
