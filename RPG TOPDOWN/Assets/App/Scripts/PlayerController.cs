using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector2 movement;
    public float speed;

    // Animation
    Animator animator;
    bool IsFacingLeft;
    bool IsFacingRight;
    bool IsFacingUp;
    bool IsFacingDown = true;

    void Awake() 
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        Aniamion_Function();
    }

    void FixedUpdate() 
    {
        Move();
    }

    void Move()
    {
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
    }

#region Animation_Function
    void Aniamion_Function()
    {
        Horizontal_Animation_Function();
        Vertical_Animation_Function();
    }

    #region Horizontal_Animation
    void Horizontal_Animation_Function()
    {
        // The movement fo the left and right
        animator.SetFloat("Horizontal", movement.x);


        // The idle of the left and right check
        if (movement.x <= -0.01)
        {
            // Left&Right
            IsFacingLeft = true;
            IsFacingRight = false;
            // Down&Up
            // IsFacingDown = true;
            // IsFacingUp = false;
        }
        else if (movement.x >= 0.01)
        {
            // Left&Right
            IsFacingLeft = false;
            IsFacingRight = true;
            // Down&Up
            // IsFacingDown = false;
            // IsFacingUp = true;
        }


        // The idle of left and right
        // left
        if (movement.x == 0 && IsFacingLeft == true)
        {
            animator.SetBool("IsLeftSide", true);
        }
        else
        {
            animator.SetBool("IsLeftSide", false);
        }
        // Right
        if (movement.x == 0 && IsFacingRight == true)
        {
            animator.SetBool("IsRightSide", true);
        }
        else
        {
            animator.SetBool("IsRightSide", false);
        }
    }
    #endregion

    #region Vertical_Aniamtion
    void Vertical_Animation_Function()
    {
        // The movement fo the down and up
        animator.SetFloat("Vertical", movement.y);


        // The idle of the down and up check
        if (movement.y <= -0.01)
        {
            // Down&Up
            IsFacingDown = true;
            IsFacingUp = false;
            // Left&Right
            // IsFacingLeft = true;
            // IsFacingRight = false;
        }
        else if (movement.y >= 0.01)
        {
            // Down&Up
            IsFacingDown = false;
            IsFacingUp = true;
            // Left&Right
            // IsFacingLeft = false;
            // IsFacingRight = true; 
        }


        // The idle of down and up
        // down
        if (movement.y == 0 && IsFacingDown == true)
        {
            animator.SetBool("IsDownSide", true);
        }
        else
        {
            animator.SetBool("IsDownSide", false);
        }
        // up
        if (movement.y == 0 && IsFacingUp == true)
        {
            animator.SetBool("IsUpSide", true);
        }
        else
        {
            animator.SetBool("IsUpSide", false);
        }
    }
    #endregion
#endregion
}