using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 10;

    public bool IsDead()
    {
        return health <= 0? true:false;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
