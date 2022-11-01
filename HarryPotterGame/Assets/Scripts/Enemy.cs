using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] movePoints;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float shootRange = 10f;
    private bool canMoveRight = false;
    [SerializeField] private float reloadTime = 5f;
    private bool isReloaded = false;
    private Attack attack;
    private Transform aimTransform;


    private void Awake()
    {
       attack = GetComponent<Attack>();
    }
    void Update()
    {
        MoveTowards();
        CheckCanMoveRight();
    }
    private void MoveTowards()
    {

        if (gameObject.tag == "Voldemort")
        {
            if (!canMoveRight)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(movePoints[0].position.x, transform.position.y, movePoints[0].position.z), speed * Time.deltaTime);
                //LookAtTheTarget(movePoints[0].position);
                Vector3 lookPosition = (transform.position - movePoints[1].position).normalized;
                if (Vector3.Distance(transform.position, movePoints[1].position) > 0.1f)
                {
                   // transform.forward = lookPosition;
                    transform.forward = Vector3.Lerp(lookPosition, transform.forward, speed * Time.deltaTime);


                }
                
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(movePoints[1].position.x, transform.position.y, movePoints[1].position.z), speed * Time.deltaTime);
                //LookAtTheTarget(movePoints[1].position);
                Vector3 lookPosition = (transform.position - movePoints[0].position).normalized;
                if (Vector3.Distance(transform.position, movePoints[0].position) > 0.1f)
                {
                    transform.forward = Vector3.Lerp(lookPosition, transform.forward, speed * Time.deltaTime);

                }
            }
        }
        else if (gameObject.tag == "Enemy")
        {
            if (!canMoveRight)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, movePoints[0].position.y, transform.position.z), speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, movePoints[1].position.y, transform.position.z), speed * Time.deltaTime);
            }
        }

    }

    private void CheckCanMoveRight()
    {
        if (gameObject.tag == "Enemy")
        {
            if (Vector3.Distance(transform.position, new Vector3(transform.position.x, movePoints[0].position.y, transform.position.z)) <= 0.1f)
            {
                canMoveRight = true;
            }
            else if (Vector3.Distance(transform.position, new Vector3(transform.position.x, movePoints[1].position.y, transform.position.z)) <= 0.1f)
            {
                canMoveRight = false;
            }
        }
        else if (gameObject.tag == "Voldemort")
        {
            if (Vector3.Distance(transform.position, new Vector3(movePoints[0].position.x, transform.position.y, movePoints[0].position.z)) <= 0.1f)
            {
                canMoveRight = true;
            }
            else if (Vector3.Distance(transform.position, new Vector3(movePoints[1].position.x, transform.position.y, movePoints[1].position.z)) <= 0.1f)
            {
                canMoveRight = false;
            }
        }
       
    }
    private void LookAtTheTarget(Vector3 newTarget)
    {
        Vector3 newLookPosition = new Vector3(newTarget.x, transform.position.y, newTarget.z);
        Quaternion targetRotation = Quaternion.LookRotation(newLookPosition - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    }
}
