using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPixel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int SetWidth = Screen.width;
        int SetHeight = Screen.height;

        Screen.SetResolution(SetWidth * (SetWidth / SetHeight), SetHeight * (SetWidth / SetHeight), true);
    }
}
