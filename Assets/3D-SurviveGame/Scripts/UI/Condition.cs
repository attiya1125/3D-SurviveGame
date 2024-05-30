using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float curValue;
    public float startValue;
    public float maxValue;
    public float PassiveValue;

    public Image uibar;
    void Start()
    {
        curValue = startValue;
    }
    void Update()
    {
        //Ui ������Ʈ
        uibar.fillAmount = GetPercentage();
    }
    float GetPercentage()
    {
        return curValue / maxValue;
    }
    public void Add(float value) // ȸ��
    {
        curValue = Mathf.Min(curValue + value, maxValue); // maxvalue�� �� ������ maxvalue���� ��
    }

    public void Subtract(float value) // ������
    {
        curValue = Mathf.Max(curValue - value, 0);
    }
}
