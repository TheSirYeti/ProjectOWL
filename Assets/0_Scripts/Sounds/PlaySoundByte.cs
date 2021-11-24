using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundByte : MonoBehaviour
{
    public SoundID soundID;

    public void PlayByte()
    {
        SoundManager.instance.PlaySound(soundID);
    }
}
