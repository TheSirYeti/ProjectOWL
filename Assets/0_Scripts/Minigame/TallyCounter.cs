using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TallyCounter : MonoBehaviour
{
    public int counter;
    public TextMeshProUGUI text;

    private void Start()
    {
        EventManager.Subscribe("OnGoodTargetHit", AddTally);
        EventManager.Subscribe("OnBadTargetHit", OnTallyOver);
    }

    void AddTally(object[] parameters)
    {
        counter++;
        text.text = "TALLY: " + counter;
    }

    void OnTallyOver(object[] parameters)
    {
        if (!PlayerPrefs.HasKey("HighestTally") || PlayerPrefs.GetInt("HighestTally") < counter)
        {
            PlayerPrefs.SetInt("HighestTally", counter);
            text.text = "TALLY: " + counter + " - NEW HIGH SCORE!";
        }
    }

}
