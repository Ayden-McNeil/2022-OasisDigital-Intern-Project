using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class POVSelector : MonoBehaviour
{

    [SerializeField] private Toggle firstToggle, thirdToggle;
    static public int pov;
    // Start is called before the first frame update
    ToggleGroup toggleGroup;
 
    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
        if(PlayerPrefs.GetInt("POVSelected", pov) == 3){
            thirdToggle.isOn = true;
        }else{
            firstToggle.isOn = true;
        }
    }
 
    public void POVSelection()
    {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        if(toggle.name.Equals("FirstPerson")){
            pov = 1;
        }else{
            pov = 3;
        }
        PlayerPrefs.SetInt("POVSelected", pov);
    }

   


}
