using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
           GetComponent<Animator>().Play("Recoil");

        }else if(Input.GetButtonUp("Fire1")){
            GetComponent<Animator>().Play("OrginalState");
        }
    }

}
