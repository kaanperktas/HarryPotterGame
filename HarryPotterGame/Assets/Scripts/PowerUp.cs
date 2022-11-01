using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Health Settings")]
    public bool healtPowerUp = false;
    public int healtAmount = 1;
    [Header("Magic Settings")]
    public bool magicPowerUp = false;
    public int magicAmount = 5;
    [Header("Transform Settings")]
     private float turnSpeed = -5f;
    [Header("Scale Settings")]
     private float period = 2f;
    [SerializeField] Vector3 scaleVector;
     private float scaleFactor;

    private Vector3 startScale;

    private void Awake()
    {
        startScale = transform.localScale;
    }

    void Start()
    {
        if (healtPowerUp && magicPowerUp)
        {
            healtPowerUp = false;
            magicPowerUp = false;
        }
        else if (healtPowerUp)
        {
            magicPowerUp = false;
        }
        else if (magicPowerUp)
        {
            healtPowerUp = false;
        }
    }
    void Update()
    {
        transform.Rotate(0f, turnSpeed, 0f);
        SinusWawe();
    }
    private void SinusWawe()
    {
        if (period <= 0f)
        {
            period = 0.1f;
        }
        float cycles = Time.timeSinceLevelLoad / period;
        const float piX2 = Mathf.PI * 2;
        float sinsWawe = Mathf.Sin(cycles * piX2);
        scaleFactor = sinsWawe / 2 + 0.5f;
        Vector3 offset = scaleFactor * scaleVector;
        transform.localScale = startScale + offset;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Harry")
        {
            return;
        }

       // AudioSource.PlayClipAtPoint(clipToPlay, transform.position);

        if (healtPowerUp)
        {
            other.gameObject.GetComponent<Target>().GetHealt += healtAmount;
        }
        else if (magicPowerUp)
        {
            other.gameObject.GetComponent<Attack>().GetMagic += magicAmount;
        }
        Destroy(gameObject);
    }
}
