using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    [SerializeField] Attack attack;
    [SerializeField] Transform magicTransform;
    [SerializeField] private float magicRate;
    [SerializeField] private AudioClip clip;
    private int currentMagicCount;

    public int GetCurrentMagicCount
    {
        get { return currentMagicCount; }
        set { currentMagicCount = value; }
    }

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        if (attack != null)
        {
            attack.GetMagicTransform = magicTransform;
            attack.GetMagicRate = magicRate;
            attack.GetMagicRate = currentMagicCount;
            attack.GetClipToPlay = clip;
        }
    }
}
