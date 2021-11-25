using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelMessage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI panelText;

    private void Start()
    {
        EventManager.Subscribe("OnEndGame", SetUIText);
        EventManager.Subscribe("OnBossDestroyed", SetUIText);
    }

    public void SetUIText(object[] parameters)
    {
        panelText.text = (string)parameters[0];
    }
}
