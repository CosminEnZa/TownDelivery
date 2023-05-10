using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
        public Transform cameraTarget;
        public float sSpeed = 10.0f;
        public Vector3 dist;
        public Transform lookTarget;
        private Vector3 velocity = Vector3.zero;

    private void OnEnable()
    {
        
        dist = new Vector3(-3.24f, -3.74f, 7.88f);
        
    }

    void FixedUpdate()
        {
        
        Vector3 dPos = cameraTarget.position + dist;
            Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime);
            transform.position = sPos;
            transform.LookAt(lookTarget.position);
        }
    }
