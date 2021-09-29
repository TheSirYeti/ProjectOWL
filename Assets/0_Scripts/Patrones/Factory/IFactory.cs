using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI;

public interface IFactory<T, P> {
    T Create(P parameter);
}

public interface IFactory<T> {
    T Create();
}


