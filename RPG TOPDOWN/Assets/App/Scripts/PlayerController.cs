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
    
    bool IsLeft;
    bool IsRight;
    bool IsUp;
    bool IsDown = true;

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
        // Changing_Facing_Animation();
        Make_Sure_Player_Facing();
        Attack_System();
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
        }
        else if (movement.x >= 0.01)
        {
            // Left&Right
            IsFacingLeft = false;
            IsFacingRight = true;
        }

        // The idle of left and right TEST
        // left
        if (movement.x == 0 && IsFacingLeft == true)
        {
            animator.SetBool("IsLeftSide", IsFacingLeft);
        }
        else
        {
            animator.SetBool("IsLeftSide", false);
        }
        // Right
        if (movement.x == 0 && IsFacingRight == true)
        {
            animator.SetBool("IsRightSide", IsFacingRight);
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
        }
        else if (movement.y >= 0.01)
        {
            // Down&Up
            IsFacingDown = false;
            IsFacingUp = true;
        }

        // The idle of down and up
        // down
        if (movement.y == 0 && IsFacingDown == true)
        {
            animator.SetBool("IsDownSide", IsFacingDown);
        }
        else
        {
            animator.SetBool("IsDownSide", false);
        }
        // up
        if (movement.y == 0 && IsFacingUp == true)
        {
            animator.SetBool("IsUpSide", IsFacingUp);
        }
        else
        {
            animator.SetBool("IsUpSide", false);
        }
    }
    #endregion

//  #region Changing_Facing_Animation
//     void Changing_Facing_Animation()
//     {
//         // Up & Down
//         if (IsFacingDown == true || IsFacingUp == true)
//         {
//             IsFacingLeft = false;
//             IsFacingRight = false;
//         }

//         // Left & Right
//         if (IsFacingLeft == true || IsFacingRight == true)
//         {
//             IsFacingUp = false;
//             IsFacingDown = false;
//         }
//     }
// #endregion

    #region Make_Sure_Player_Facing
        void Make_Sure_Player_Facing()
        {
            if (movement.x > 0.01)
            {
                IsRight = true;
                IsLeft = false;
            }
            else if (movement.x < -0.01)
            {
                IsRight = false;
                IsLeft = true;
            }
            else if (movement.y > 0.01)
            {
                IsUp = true;
                IsDown = false;
            }
            else if (movement.y < -0.01)
            {
                IsDown = true;
                IsUp = false;
            }

            animator.SetBool("IsLeft", IsLeft);
            animator.SetBool("IsRight", IsRight);
            animator.SetBool("IsDown", IsDown);
            animator.SetBool("IsUp", IsUp);
        } 
    #endregion

    #region Attack_System
        void Attack_System()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                animator.SetTrigger("IsAttack");
            }
        }
    #endregion
#endregion
}