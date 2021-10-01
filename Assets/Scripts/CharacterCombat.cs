using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{

    [SerializeField]
    LayerMask targetLayer;

    [Header("LightAttackController")]
    [SerializeField]
    int lattackDamage;
    [SerializeField]
    float lattackRange;
    [SerializeField]
    GameObject lattackPoint;

    public bool isLattacking = false;


    [Header("StrongAttackController")]
    [SerializeField]
    int sattackDamage;
    [SerializeField]
    float sattackRange;
    [SerializeField]
    GameObject sattackPoint;

    public bool isSattacking = false;


    //LightAttack

    public void Lattack()
    {
        Collider2D[] hitResults = Physics2D.OverlapCircleAll(lattackPoint.transform.position, lattackRange, targetLayer);

        if (hitResults == null)
            return;

        foreach(Collider2D hit in hitResults)
        {
            if(hit.GetComponent<Health>() != null) ;
            {
                hit.GetComponent<Health>().TakeDamage(lattackDamage);
            }

        }

    }


    private void LonDrawGizmosSelected()
    {
        if (lattackPoint == null)
            return;

        Gizmos.DrawWireSphere(lattackPoint.transform.position, lattackRange);

    }

    //StrongAttack

    public void Sattack()
    {
        Collider2D[] hitResults = Physics2D.OverlapCircleAll(sattackPoint.transform.position, sattackRange, targetLayer);

        if (hitResults == null)
            return;

        foreach (Collider2D hit in hitResults)
        {
            if (hit.GetComponent<Health>() != null) ;
            {
                hit.GetComponent<Health>().TakeDamage(sattackDamage);
            }

        }

    }
   
    
    private void OnDrawGizmosSelected()
    {
        if (lattackPoint == null)
            return;

        Gizmos.DrawWireSphere(lattackPoint.transform.position, lattackRange);

    }
}
