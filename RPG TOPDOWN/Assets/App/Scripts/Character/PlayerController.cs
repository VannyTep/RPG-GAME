using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Walk,
    Attack,
    Interact
}

public class PlayerController : MonoBehaviour
{
    public PlayerState CurrentState;
    Rigidbody2D rb2d;
    public Vector2 movement;
    public float speed;
    private Animator animator;

    [Space]

    [Header("HitBox Space")]
    [SerializeField] GameObject[] HitBox;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        for (int i = 0; i < HitBox.Length; i++)
        {
            HitBox[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement = Vector2.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Fire1") && CurrentState != PlayerState.Attack)
        {
            StartCoroutine(AttackCo());
        }
        
        if (CurrentState == PlayerState.Walk)
        {
            Update_Animation();
        }
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("Attacking", true);
        CurrentState = PlayerState.Attack;
        for (int i = 0; i < HitBox.Length; i++)
        {
            HitBox[i].SetActive(true);
        }
        yield return null;
        animator.SetBool("Attacking", false);
        yield return new WaitForSeconds(0.33f);
        CurrentState = PlayerState.Walk;
        for (int i = 0; i < HitBox.Length; i++)
        {
            HitBox[i].SetActive(false);
        }
    }

    void FixedUpdate() 
    {
        Move();
    }

    void Move()
    {
        rb2d.MovePosition(rb2d.position + movement * speed * Time.fixedDeltaTime);
    }

    void Update_Animation()
    {
        if (movement != Vector2.zero)
        {
            Animator_Function();
            animator.SetBool("Movement", true);
        }
        else
        {
            animator.SetBool("Movement", false);
        }
    }

    void Animator_Function()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
    }
}