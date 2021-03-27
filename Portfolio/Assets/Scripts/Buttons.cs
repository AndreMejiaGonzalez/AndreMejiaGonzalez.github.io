using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField]
    private string url;

    public void openLink()
    {
        Application.OpenURL(url);
    }
}
