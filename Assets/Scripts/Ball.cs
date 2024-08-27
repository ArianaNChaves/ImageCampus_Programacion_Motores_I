using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 0.5f;
    [SerializeField] private float incrementalSpeed = 0.5f;
    [SerializeField] private Transform target;
    
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;
    private float _desviation = 1.0f;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        // _rigidbody2D.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
        Vector3 direction = target.right;
        _rigidbody2D.velocity = new Vector2(direction.x, direction.y) * speed;
         
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Obstacle"))
        {
            speed += incrementalSpeed;
            _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * speed;
        }
    }
}
