using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonFX : MonoBehaviour
{
  public AudioSource myFX;
  public AudioClip buttonHover;
  public AudioClip buttonPressed;

  public void PlayHover()
  {
    myFX.PlayOneShot(buttonHover);
  }

  public void PlayDown()
  {
    myFX.PlayOneShot(buttonPressed);
  }
}
