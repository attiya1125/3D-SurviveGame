using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;
    
    Condition health { get {  return uiCondition.health; } }

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
}
