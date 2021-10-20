using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IValueRecorder
{
    void AddValue(object[] parameters);
    
    void SaveValue(object[] parameters);
}
