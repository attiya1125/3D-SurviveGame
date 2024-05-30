using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    public float damage;
    public float damageRate;

    List<IDamagebe> things = new List<IDamagebe>();
    void Start()
    {
        InvokeRepeating("DealDamage", 0, damageRate);
    }

    void DealDamage()
    {
        for(int i = 0; i < things.Count; i++)
        {
            things[i].TakeDamage(damage);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamagebe damagebe))
        {
            things.Add(damagebe);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IDamagebe damagebe))
        {
            things.Remove(damagebe);
        }
    }
}
