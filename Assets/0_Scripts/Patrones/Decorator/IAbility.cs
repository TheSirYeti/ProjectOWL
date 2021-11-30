using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbility
{
    void OnSlideDown();

    IAbility GetNext();

    void SetNext(IAbility ability);
}
