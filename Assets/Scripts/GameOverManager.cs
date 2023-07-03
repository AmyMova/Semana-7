using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI actual;

    [SerializeField]
    TextMeshProUGUI record;

    SessionManager _sessionManager;

    void Awake() {
        _sessionManager = SessionManager.Instance;
    }

    void Start() {
        int actualPuntaje = _sessionManager.contador.contador;
        int logro = PlayerPrefs.GetInt("Logros", 0);

        if(actualPuntaje > logro) {
            PlayerPrefs.SetInt("Logros", actualPuntaje);
        }

        actual.text = actualPuntaje.ToString();
        record.text = logro.ToString();
    }
}
