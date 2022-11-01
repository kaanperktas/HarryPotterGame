using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    [SerializeField] private float magicSpeed = 8;
    public GameObject owner;

    void Update()
    {
        transform.position += transform.up * magicSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Enemy" || other.gameObject.tag == "Wall" || other.gameObject.tag == "Harry" || other.gameObject.tag == "Voldemort")
        {
            Destroy(gameObject);
        }
        if (gameObject.tag =="bullet" && other.gameObject.tag =="Enemy" || other.gameObject.tag == "Voldemort")
        {
            if (other.gameObject != null)
            {
                other.gameObject.GetComponent<Target>().GetHealt -= 1;
            }
        }
        else if (gameObject.tag == "enemysbullet" && other.gameObject.tag == "Harry")
        {
            if (other.gameObject != null)
            {
                other.gameObject.GetComponent<Target>().GetHealt -= 1;

            }
        }
    }
}