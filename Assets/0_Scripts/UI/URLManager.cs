using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URLManager : MonoBehaviour
{
    [SerializeField] List<string> urls;

    public void OpenURL(int id)
    {
        Application.OpenURL(urls[id]);
    }
}
