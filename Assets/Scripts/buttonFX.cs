using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonFX : MonoBehaviour
{
  public AudioSource myFX;
  public AudioClip buttonHover;
  public AudioClip buttonPressed;

  public void hoverSound()
  {
    myFX.PlayOneShot(buttonHover);
  }

  public void pressSound()
  {
    myFX.PlayOneShot(buttonPressed);
  }
}
