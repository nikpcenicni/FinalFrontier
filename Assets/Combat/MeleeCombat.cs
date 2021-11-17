using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackpoint;
    public float attackRange = 0.5f;
    public int attackDamage = 10;
    public LayerMask enemyLayers;

    public float attackRate = 2f;
    float nextAttacktime = 0f; 

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttacktime)
        {
            if (Input.GetMouseButton(1))
            {
                MeleeAttack();
                nextAttacktime = Time.time + 1f / attackRate; 
            }
        }
        
    }

    void MeleeAttack()
    {
        //play attack animantion
        animator.SetTrigger("Attack");

        //detect enemy in range
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemyLayers);


        //damage enemy
        foreach(Collider2D enemy in hitenemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

    }
    void onDrawGizmosSelected()
    {
        if(attackpoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }

}
