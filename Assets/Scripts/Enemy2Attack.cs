using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Attack : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private float speed;



    private Transform player;

    private Rigidbody2D rb2d;


    [SerializeField]
    private EnemyHealth enemyLife;

    [SerializeField]
    private GameObject[] damageAttack;



    private float time;
    [SerializeField]
    private float timeToAttack;

    private bool isAttack = false;

    [SerializeField]
    private AudioSource audioHit;

    private int randomNumber;






    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
        time = timeToAttack;

    }

    void setDeath()
    {
        Destroy(this.gameObject);

    }
    // Update is called once per frame
    void FixedUpdate()
    {


        if (enemyLife.currentHealth <= 0)
        {
            anim.Play("Death");
            this.enabled = false;
            Invoke("setDeath", 1f);
            speed = 0;
            rb2d.gravityScale = 1;
            rb2d.isKinematic = false;
        }


        anim.SetBool("isRun", true);
        ChasePlayer();

        if (isAttack == true)
        {
            StopChasingPlayer();
            anim.SetBool("isRun", false);

            time -= Time.deltaTime;
            if (time <= 0)
            {
                randomNumber = Random.Range(0, 2);
                if(randomNumber == 0)
                {
                    Debug.Log("ESTA ACTIVO");
                    audioHit.Play();
                    anim.Play("Attack1");
                    damageAttack[0].SetActive(true);
                    time = timeToAttack;
                }

                if(randomNumber == 1)
                {
                    Debug.Log("ESTA ACTIVO");
                    audioHit.Play();
                    anim.Play("Attack2");
                    damageAttack[1].SetActive(true);
                    time = timeToAttack;
                }
                



            }
            else
            {
                damageAttack[0].SetActive(false);
                damageAttack[1].SetActive(false);
            }

        }




    }


    void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            rb2d.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            rb2d.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }



    void StopChasingPlayer()
    {
        rb2d.velocity = Vector2.zero;
        //transform.position = Vector2.MoveTowards(transform.position, enemyPosOriginal, moveSpeed * Time.deltaTime);


    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            // anim.SetBool("isTouch", true);
            isAttack = true;
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            // anim.SetBool("isTouch", false);
            isAttack = false;
        }
    }

}
