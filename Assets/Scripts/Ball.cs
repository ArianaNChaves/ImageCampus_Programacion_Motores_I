using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float incrementalSpeed = 0.75f;
    
    private Rigidbody2D _rigidbody2D;
    private Vector3 _direction;

    private const float DEVIATION = 10.0f;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 collisionNormalVector = collision.contacts[0].normal;

        Vector3 normal = new Vector3(collisionNormalVector.x, collisionNormalVector.y, 0f);
        _direction = _direction - 2 * Vector3.Dot(_direction, normal) * normal;

        _direction = Quaternion.Euler(0, 0, RandomDeviation()) * _direction;
        
        _rigidbody2D.velocity = new Vector2(_direction.x , _direction.y).normalized * speed;
        
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Obstacle"))
        {
            speed += incrementalSpeed;
            _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * speed;
        }
    }
    public void Initiate(Transform direction)
    {
        _direction = direction.up;
        _rigidbody2D.velocity = new Vector2(_direction.x, _direction.y) * speed;
    }

    private float RandomDeviation()
    {
        return Random.Range(-DEVIATION, DEVIATION);
    }
}
