using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;


public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject wands;
    [SerializeField] private GameObject magic;
    [SerializeField] private bool isPlayer = false;
   // public GameObject a;
    private Transform magicTransform;
    private float magicRate = 0.5f;
    private int magicCount = 10;
    private int maxMagicCount = 15;
    private float currentMagicRate = 0f;
    private AudioClip clipToPlay;
    private AudioSource audioSource;
    private Move move;
  // private GameObject a;
    public float GetCurrentMagicRate
    {
        get { return currentMagicRate; }
        set { currentMagicRate = value; }
    }
    public int GetMagic { get { return magicCount; } set { magicCount = value;
            if (magicCount > maxMagicCount) magicCount = maxMagicCount; } }
    public float GetMagicRate
    {
        get
        {
            return magicRate;
        }
        set
        {
            magicRate = value;
        }
    }
    public int GetClipSize
    {
        get
        {
            return maxMagicCount;
        }
        set
        {
            maxMagicCount = value;
        }
    }
    public Transform GetMagicTransform
    {
        get 
        { return magicTransform; 
        }
        set
        {
            magicTransform = value;
        }
    } 
    public AudioClip GetClipToPlay
    {
        get { return clipToPlay; }
        set { clipToPlay = value; }
    }

    private void Awake()
    {
      //  a = GameObject.FindGameObjectWithTag("shield");
       move = GetComponent<Move>(); 
       audioSource = GetComponent<AudioSource>();

    }
     void Start()
    {
       // a.SetActive(false);
    }
    void Update()
    {
        if (currentMagicRate > 0)
        {
            currentMagicRate -= Time.deltaTime;
        }
        PlayerInput();

    }
    private void PlayerInput()
    {
        if (isPlayer)
        {
            if (Input.GetMouseButtonDown(0))
            {
               
                if (currentMagicRate <= 0 && magicCount > 0)
                {
                   move.GetAnim.SetBool("Attack", true);
                    //Fire();
                }
            }
            else
            {
                  move.GetAnim.SetBool("Attack", false);
            } 
        }
    }
    public void Fire()
    {
        float difference = 360f - transform.eulerAngles.y;
        float targetRotation =90f;
        if (difference >= 90f)
        {
            targetRotation = 90f;
        }
        else if (difference < 90f)
        {
            targetRotation = -90f;
        }
        magicCount--;
        currentMagicRate = magicRate;
        audioSource.PlayOneShot(clipToPlay);
        GameObject bulletClone = Instantiate(magic, magicTransform.position, Quaternion.Euler(-targetRotation, 0f, 0f));
        bulletClone.GetComponent<Magic>().owner = gameObject;
    }

}
