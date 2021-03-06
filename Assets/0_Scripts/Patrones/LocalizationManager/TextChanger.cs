using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN CRUZ CRISTÓFALO

public class TextChanger : MonoBehaviour
{
    [SerializeField] string textFile;
    [SerializeField] public TextMeshProUGUI textChanging;
    [SerializeField] public TextMeshProUGUI textChanging2;

    private void Start()
    {
        textChanging2.SetText(LocalizationManager.Instance.GetText(textFile));
        textChanging.SetText(LocalizationManager.Instance.GetText(textFile));

        EventManager.Subscribe("OnLangChanging", NewText);
    }

    private void NewText(object[] parameter)
    {
        textChanging2.SetText(LocalizationManager.Instance.GetText(textFile));
        textChanging.SetText(LocalizationManager.Instance.GetText(textFile));
    }
}
