using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
