using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkinSelector : MonoBehaviour
{
    public List<Button> equipButtons;

    public void CheckStatus()
    {
        SkinManager.instance.CheckSkinStatus();
        int i = 0;
        foreach (bool status in SkinManager.instance.skinStatus)
        {
            if (status)
            {
                equipButtons[i].enabled = true;
            }
            else
            {
                equipButtons[i].enabled = false;
            }

            i++;
        }
    }

    public void SelectSkin(int id)
    {
        SkinManager.instance.currentSkin = id;
    }
}
