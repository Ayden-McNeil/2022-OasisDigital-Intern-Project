using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
      {
        animator.SetBool("isWalking", true);
      } 
        if (!Input.GetKey("w"))
      {
        animator.SetBool("isWalking", false);
      }

         if (Input.GetKey("s"))
      {
        animator.SetBool("isWalkingBackwards", true);
      } 
         if (!Input.GetKey("s"))
      {
        animator.SetBool("isWalkingBackwards", false);
      }

         if (Input.GetKey("d"))
      {
        animator.SetBool("isWalkingRight", true);
      } 
         if (!Input.GetKey("d"))
      {
        animator.SetBool("isWalkingRight", false);
      }

         if (Input.GetKey("a"))
      {
        animator.SetBool("isWalkingLeft", true);
      } 
         if (!Input.GetKey("a"))
      {
        animator.SetBool("isWalkingLeft", false);
      }
    }
}
