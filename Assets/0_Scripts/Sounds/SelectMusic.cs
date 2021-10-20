using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Modelos y Algoritmos 1 / Aplicacion de Motores 2 - JUAN PABLO RSHAID
public class SelectMusic : MonoBehaviour
{
    public MusicID musicID;

    private void Start()
    {
        if (!SoundManager.instance.isMusicPlaying(musicID))
        {
            SoundManager.instance.StopAllMusic();
            SoundManager.instance.PlayMusic(musicID, true);
        }
    }
}
