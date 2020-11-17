using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorAleko : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Z)) 
        
        {
            anim.SetBool("Walk", true);
        }

        if (Input.GetKeyUp(KeyCode.Z)) 
        
        {
            anim.SetBool("Walk", false);
        }

        if (Input.GetKeyDown(KeyCode.Q))

        {
            anim.SetBool("Walk", true);
        }

        if (Input.GetKeyUp(KeyCode.Q))

        {
            anim.SetBool("Walk", false);
        }

        if (Input.GetKeyDown(KeyCode.S))

        {
            anim.SetBool("Walk", true);
        }

        if (Input.GetKeyUp(KeyCode.S))

        {
            anim.SetBool("Walk", false);
        }

        if (Input.GetKeyDown(KeyCode.D))

        {
            anim.SetBool("Walk", true);
        }

        if (Input.GetKeyUp(KeyCode.D))

        {
            anim.SetBool("Walk", false);
        }





        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetBool("Run", true);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("Run", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Attack", true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("Attack", false);
        }
    }
}
