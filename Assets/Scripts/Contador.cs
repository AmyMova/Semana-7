using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contador : MonoBehaviour
{
    public int contador { get; private set; }

    public void Incrementar() {
        contador++;
    }

    public void Resetear() {
        contador = 0;
    }
}
