using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneVarPassover : MonoBehaviour
{
    public static int pov;
    public static int fov;
    public static float sens;
    public static float volume = 0f;

    public void getValues()
    {
        fov = FOVController.FOVVar;
        sens = mouseSensControl.sensVar;
        pov = POVSelector.pov;
        volume = soundController.volume;
    }
}
