using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelTextChanger : MonoBehaviour
{
    [SerializeField] string textFile;
    [SerializeField] public Text textChanging;
    

    private void Start()
    {
        EventManager.Subscribe("OnLangChanging", NewText);

        textChanging.text = LocalizationManager.Instance.GetText(textFile);        
    }

    private void NewText(object[] parameter)
    {
        textChanging.text = LocalizationManager.Instance.GetText(textFile);
    }
}
