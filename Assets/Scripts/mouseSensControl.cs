using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class mouseSensControl : MonoBehaviour
{

  public TMP_InputField sensInput;
  public Slider senSlider;
  public static float sensVar = 2;
    // Start is called before the first frame update
    void Start()
    {
    sensInput.onValueChanged.AddListener(delegate { changeValue(); });
    senSlider.onValueChanged.AddListener(delegate { changeValueSlider(); });
    sensInput.text = "2";
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void changeValue()
  {
    senSlider.value = float.Parse(sensInput.text);
    sensVar = senSlider.value;
  }

  public void changeValueSlider()
  {
    sensInput.text = senSlider.value.ToString();
    sensVar = float.Parse(sensInput.text);
  }
}
