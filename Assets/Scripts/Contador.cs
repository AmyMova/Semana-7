using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Contador
{
    public int contador { get; private set; }

    public void Incrementar() {
        contador++;
    }

    public void Resetear() {
        contador = 0;
    }
}
