using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IDamagebe
{
    void TakeDamage(float damage);
}
public class PlayerCondition : MonoBehaviour , IDamagebe
{
    public UICondition uiCondition;
    
    Condition health { get {  return uiCondition.health; } }

    public event Action onTakeDamage;
    void Update()
    {
        if (health.curValue < 0f)
        {
            Die();
        }
    }
    public void Heal(float value)
    {
        health.Add(value);
    }
    private void Die()
    {
        Debug.Log("Die");
    }

    public void TakeDamage(float damage)
    {
        health.Subtract(damage);
        onTakeDamage?.Invoke();
    }
    public IEnumerator TakeContinuousDamage(float damage, float duration, float interval)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            Debug.Log(damage);
            health.Subtract(damage);
            onTakeDamage?.Invoke();
            elapsedTime += interval;
            yield return new WaitForSeconds(interval);
        }
    }
}
