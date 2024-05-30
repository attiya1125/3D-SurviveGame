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
    public float duration;

    private Coroutine delay;
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
    public IEnumerator TakeContinuousDamage(float damage, float interval)
    {
        float elapsedTime = 0f;
        duration = 5;

        while (elapsedTime < duration)
        {
            Debug.Log(damage);
            health.Subtract(damage);
            onTakeDamage?.Invoke();
            elapsedTime += interval;
            yield return new WaitForSeconds(interval);
        }
    }

    public void StartCor(float damage)
    {
        if (delay != null)
        {
            duration += 5;
        }
        else
        {
            delay = StartCoroutine(TakeContinuousDamage(damage, 1f));
        }
    }
}
