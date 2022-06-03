using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneVarPassover : MonoBehaviour
{
    public static int fov;
    public static float sens;

    public void getValues()
    {
        fov = FOVController.FOVVar;
        sens = mouseSensControl.sensVar;
    }
}
