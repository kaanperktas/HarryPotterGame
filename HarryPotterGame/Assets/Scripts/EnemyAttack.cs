using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Android.Types;
using Unity.VisualScripting;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] private float shootRange = 10f;
    [SerializeField] private float reloadTime = 5f;
    [SerializeField] private GameObject magic;
    private bool isReloaded = false;
    private Attack attack;
    [SerializeField] private Transform aimTransform;
    [SerializeField] private AudioClip clip;
    private int playerHealthAmount = 1;

    private void Awake()
    {
        attack = GetComponent<Attack>();
    }
    void Update()
    {
       // magic.transform.position += magic.transform.position * Time.deltaTime * 10f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Harry")
        {
            Fire();
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }
    }

    public void Fire()
    {
        float difference = 180f - transform.eulerAngles.x;
        float targetRotation = 0f;
        if (difference >= 90f)
        {
            targetRotation = 90f;
        }
        else if (difference < 90f)
        {
            targetRotation = -90f;
        }
        GameObject bulletClone = Instantiate(magic, aimTransform.position, Quaternion.Euler(targetRotation, 0f, 0f));
        bulletClone.GetComponent<Magic>().owner = gameObject;
    }

}
