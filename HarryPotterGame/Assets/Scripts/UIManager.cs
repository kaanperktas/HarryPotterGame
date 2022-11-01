
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image healthFill;
    public Image magicFill;

    private Attack playerMagic;
    private Target playerHealth;

    private void Awake()
    {
        playerMagic = GameObject.FindGameObjectWithTag("Harry").GetComponent<Attack>();
        playerHealth = playerMagic.GetComponent<Target>();
    }

    void Update()
    {
        UpdateHealthFill();
        UpdateMagicFill();
    }

    private void UpdateMagicFill()
    {
        magicFill.fillAmount = (float)playerMagic.GetMagic / playerMagic.GetClipSize;
    }

    private void UpdateHealthFill()
    {
        healthFill.fillAmount = (float)playerHealth.GetHealt / playerHealth.GetMaxHealt;
    }
}
