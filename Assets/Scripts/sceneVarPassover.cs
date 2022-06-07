using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneVarPassover : MonoBehaviour
{
    public static int fov;
    public static float sens;
    public static float volume;

    public void getValues()
    {
        fov = FOVController.FOVVar;
        sens = mouseSensControl.sensVar;
        volume = SoundController.volume;
    }
}
