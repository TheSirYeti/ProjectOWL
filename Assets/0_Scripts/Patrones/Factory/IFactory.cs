using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI;
//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID, JUAN CRUZ CRISTÓFALO
public interface IFactory<T, P> {
    T Create(P parameter);
}

public interface IFactory<T> {
    T Create();
}


