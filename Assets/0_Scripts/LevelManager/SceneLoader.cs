using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public enum SceneID
    {
        MAINMENU,
        MAINLEVEL
    }

    public void LoadScene(SceneID scene)
    {
        SceneManager.LoadSceneAsync((int) scene);
    }
}
