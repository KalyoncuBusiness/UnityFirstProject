using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;


    public void TakeDamage(int damage)
    {
        health -= damage;

        CheckIfWeDead();
    }


    private void CheckIfWeDead()
    {
        if (health<=0)
        {
            health = 0;
            Debug.Log("You Are Die" + gameObject.name);
        }
    }
}
