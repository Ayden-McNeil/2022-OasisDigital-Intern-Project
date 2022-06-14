using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumMachinePosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        sensVar = sceneVarPassover.sens;
        fovVar = sceneVarPassover.fov;
        povVar = sceneVarPassover.pov;
        if (povVar == 3) {
            transform.position = (0.440d, 0.65d, 1.8d);
        } else {
            transform.position = (0.44d, 0.26d, 1.8d);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
