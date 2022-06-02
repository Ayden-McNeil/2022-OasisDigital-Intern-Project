using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneVarPassover : MonoBehaviour
{
  public int fov;
  public float sens;
  public GameObject thisgameObject;

  void Start()
  {
    DontDestroyOnLoad(thisgameObject);
  }

  public void getValues()
  {
    fov = FOVController.FOVVar;
    sens = mouseSensControl.sensVar;
    Debug.Log(fov + "   " + sens); 
  }
}
