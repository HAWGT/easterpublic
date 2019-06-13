using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenRatio : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Camera.main.aspect = 1080f / 1920f;
    }

}
