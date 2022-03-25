using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardWeapon : MonoBehaviour
{
    Guard guard;

    private void Awake()
    {
        guard = GetComponentInParent<Guard>();
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<MonsterInputSystem>().TakeDamage(guard.GetDamage());
        }
    }
}
