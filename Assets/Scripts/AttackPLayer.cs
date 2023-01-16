using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPLayer : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private float attackRange;

    [SerializeField]
    private Transform attackPoint;

    [SerializeField]
    private LayerMask enemyLayer;

    
    public int damage;

    [SerializeField]
    private float attackRate;

    [SerializeField]
    private AudioSource audio;

    float nextAttack = 0;
    // Start is called before the first frame update
    void Start()
    {
       // nextAttack = attackRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>= nextAttack)
         {
             if (Input.GetKeyDown(KeyCode.Mouse0))
             {
                audio.Play();
                 Attack();
                 nextAttack = Time.time + 1 / attackRate;
             }

            if (Input.GetKeyDown(KeyCode.Joystick1Button2))
            {
                audio.Play();
                Attack();
                nextAttack = Time.time + 1 / attackRate;
            }
        }


    }

    void Attack()
    {
        anim.SetTrigger("Attack");

        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D enemy in hitEnemy)
        {
            Debug.Log("TE GOLPEO");
            enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
