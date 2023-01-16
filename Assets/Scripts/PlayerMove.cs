using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField]
    private float speed;

    [SerializeField]
    private float speedJump;

    [SerializeField]
    private Rigidbody2D rb2d;

   
    private float horizontalMove;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private AudioSource jump;

   

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        rb2d.velocity = new Vector2(horizontalMove * speed, rb2d.velocity.y);

        chasePlayer();

        if (CheckGround.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump.Play();
                anim.SetBool("isJump", true);
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                anim.SetBool("isJump", true);
                Jump();
            }
        }
        else 
        {
            anim.SetBool("isJump", false);
        }

        

    }

    void chasePlayer()
    {
        if(horizontalMove > 0)
        {
            anim.SetBool("isRun", true);
            transform.localScale = new Vector3(1,1,1);
        }
        else if(horizontalMove< 0)
        {
            anim.SetBool("isRun", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            anim.SetBool("isRun", false);
        }
    }

    void Jump()
    {
       
        rb2d.velocity = new Vector2(rb2d.velocity.x, speedJump);
    }
}
