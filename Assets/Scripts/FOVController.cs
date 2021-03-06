using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FOVController : MonoBehaviour
{
    public TMP_InputField FOVInput;
    public Slider FOVSlider;
    public static int FOVVar = 90;

    void Awake()
    {
        FOVInput.onValueChanged.AddListener(delegate { changeValue(); });
        FOVSlider.onValueChanged.AddListener(delegate { changeValueSlider(); });
        FOVInput.text = FOVVar.ToString();
    }

    public void changeValue()
    {
        FOVSlider.value = float.Parse(FOVInput.text);
        FOVVar = (int)FOVSlider.value;
    }

    public void changeValueSlider()
    {
        FOVInput.text = FOVSlider.value.ToString();
        FOVVar = int.Parse(FOVInput.text);;
    }
}
