using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50.0f;
    
    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime); 
    }
}
