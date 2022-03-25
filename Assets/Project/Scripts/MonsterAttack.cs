using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    MonsterInputSystem monster;

    private void Awake()
    {
        monster = GetComponentInParent<MonsterInputSystem>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.GetComponent<Health>()!=null)
        {
            collider.gameObject.GetComponent<Health>().TakeDamage(monster.GetMonsterDamage());
        }
    }
}
