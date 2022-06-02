using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FOVController : MonoBehaviour
{

  public TMP_InputField FOVInput;
  public Slider FOVSlider;

  // Start is called before the first frame update
  void Start()
    {
    FOVInput.onValueChanged.AddListener(delegate { changeValue(); });
    FOVSlider.onValueChanged.AddListener(delegate { changeValueSlider(); });
    FOVInput.text = "90";
  }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeValue()
    {
      FOVSlider.value = float.Parse(FOVInput.text);
    }

    public void changeValueSlider()
    {
      FOVInput.text = FOVSlider.value.ToString();
    }
}
