using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;
    bool crouch = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Use Debug.Log to keep track of key input and if it functions
        //Example: Debug.Log(Input.GetButtonDown("Jump"));

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        Debug.Log(Input.GetButtonDown("Crouch"));
        
        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;

        } else if(!Input.GetButtonDown("Crouch"))
        {
            crouch = false;
        }

    }

    public void onCrouching(bool IsCrouching)
    {
        animator.SetBool("IsCrouching", IsCrouching);
    }
    public void OnLanding()
    {
        animator.SetBool("IsJumping",false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

        jump = false;

        //crouch = false;
    }
}
