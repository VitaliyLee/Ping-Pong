using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSound : MonoBehaviour
{
    public void ToggleAllSound()
    {
        if (AudioListener.volume == 1) AudioListener.volume = 0;
        else AudioListener.volume = 1;
    }
}
