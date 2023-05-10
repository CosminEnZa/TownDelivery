using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterNavigatorController : MonoBehaviour
{
    public int MovementSpeed;
    public int RotationSpeed;
    public float StopDistance;
    Vector3 velocity;
    Vector3 destination;

    //Animator _animator;

    Vector3 lastPosition;
    public Vector3 Destination;
    public bool ReachedDestination;

    private void Start()
    {
        //_animator = GetComponent<Animator>();
    }

    void Update()
    {
       if(transform.position != destination)
        {
            Vector3 destinationDirection = Destination - transform.position;
            destinationDirection.y = 0;

            float destinationDistance = destinationDirection.magnitude;

            if(destinationDistance >= StopDistance)
            {
                ReachedDestination = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, RotationSpeed * Time.deltaTime);
                transform.Translate(Vector3.forward * MovementSpeed * Time.deltaTime);
            }
            else
            {
                ReachedDestination = true;
            }

            velocity = (transform.position - lastPosition) / Time.deltaTime;
            velocity.y = 0;
            var velocityMagnitude = velocity.magnitude;
            velocity = velocity.normalized;
            var fwdDotProduct = Vector3.Dot(transform.forward, velocity);
            var rightDotProduct = Vector3.Dot(transform.right, velocity);

            //_animator.SetFloat("Horizontal", rightDotProduct);
            //_animator.SetFloat("Forward", fwdDotProduct);
        }
       else
        {
            ReachedDestination = true;
        }
    }

    public void SetDestination(Vector3 destination)
    {
        this.destination = destination;
        ReachedDestination = false;
    }
}
