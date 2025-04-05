using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private RectTransform healthBarFill, staminaBarFill;

    public void SetHealthBar(float percent)
    {
        healthBarFill.localScale = new Vector3(Mathf.Clamp01(percent), 1f, 1f);
    }
    public void SetStaminaBar(float percent)
    {
        staminaBarFill.localScale = new Vector3(Mathf.Clamp01(percent), 1f, 1f);
    }
}