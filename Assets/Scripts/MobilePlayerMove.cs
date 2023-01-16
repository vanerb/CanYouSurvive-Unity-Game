using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlayerMove : MonoBehaviour
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

    [SerializeField]
    private Joystick joystick;

    bool isJumping = false;



    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        
        rb2d.velocity = new Vector2(joystick.Horizontal * speed, rb2d.velocity.y);

        chasePlayer();


      
            if (CheckGround.isGrounded == true)
            {
            if (isJumping == true)
            {
                jump.Play();
                anim.SetBool("isJump", true);
                rb2d.velocity = new Vector2(rb2d.velocity.x, speedJump);
            }
            }
            else
            {
                anim.SetBool("isJump", false);
            }
        
       

    }

    void chasePlayer()
    {
        if (joystick.Horizontal > 0)
        {
            anim.SetBool("isRun", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (joystick.Horizontal < 0)
        {
            anim.SetBool("isRun", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            anim.SetBool("isRun", false);
        }
    }

    public void Jump()
    {
        isJumping = true;
       
    }

    public void NoJump()
    {
        isJumping = false;
    }
}
