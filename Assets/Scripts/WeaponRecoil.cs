using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    //public Vector3 recoilPostion;
    //public Vector3 recoilRotation;
    //Vector3 orginalPostion;
    //Vector3 orginalRotation;
    // Start is called before the first frame update
    
    void Start()
    {
        //orginalPostion = transform.position;
        //orginalRotation = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
           GetComponent<Animator>().Play("Recoil");
            //transform.localEulerAngles += recoilRotation;

        }else if(Input.GetButtonUp("Fire1")){
            GetComponent<Animator>().Play("OrginalState");
            //transform.position = orginalPostion;
            //transform.localEulerAngles = orginalRotation;
        }
    }

}
