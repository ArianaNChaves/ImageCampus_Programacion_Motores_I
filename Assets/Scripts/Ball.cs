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
    
    private Rigidbody2D _rigidbody2D;
    private Vector3 _direction;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Obstacle"))
        {
            speed += incrementalSpeed;
            _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * speed;
        }
    }
    public void Initiate(Transform direction)
    {
        _direction = direction.right;
        _rigidbody2D.velocity = new Vector2(_direction.x, _direction.y) * speed;
    }
}
