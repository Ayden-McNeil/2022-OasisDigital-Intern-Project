using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class POVSelector : MonoBehaviour
{

    static public int pov;
    // Start is called before the first frame update
    ToggleGroup toggleGroup;
 
    void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();
    }
 
    public void POVSelection()
    {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        if(toggle.name.Equals("FirstPerson")){
            pov = 1;
            Debug.Log(toggle.name);
        }else{
            pov = 3;
            Debug.Log(toggle.name);
        }
    }

   


}
