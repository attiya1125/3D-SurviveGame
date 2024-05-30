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
        //Ui 업데이트
        uibar.fillAmount = GetPercentage();
    }
    float GetPercentage()
    {
        return curValue / maxValue;
    }
    public void Add(float value) // 회복
    {
        curValue = Mathf.Min(curValue + value, maxValue); // maxvalue가 더 작으면 maxvalue값이 들어감
    }

    public void Subtract(float value) // 데미지
    {
        curValue = Mathf.Max(curValue - value, 0);
    }
}
