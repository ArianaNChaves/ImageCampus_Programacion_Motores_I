using System;
using UnityEngine;
using UnityEngine.Serialization;
using Unity.Mathematics;
using Random = UnityEngine.Random;


public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private KeyCode keyUp;
    [SerializeField] private KeyCode keyDown;
    [SerializeField] private KeyCode keyLeft;
    [SerializeField] private KeyCode keyRight;
    
    private Vector2 _distance;
    private bool _canMove;
    private void Start()
    {
        _canMove = true;
    }
    void Update()
    {
        if (!_canMove) return;
        Move();
    }
    private void Move()
    {
        _distance = Vector2.zero;
        if (Input.GetKey(keyUp))
        {
            _distance += Vector2.up;
        }
        if (Input.GetKey(keyDown))
        {
            _distance += Vector2.down;
        }
        if (Input.GetKey(keyLeft))
        {
            _distance += Vector2.left;
        }
        if (Input.GetKey(keyRight))
        {
            _distance += Vector2.right;
        }

        Vector2 move = _distance.normalized;
        transform.Translate(move * (speed * Time.deltaTime));
    }
    
    public void SetPlayerSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    public float GetPlayerSpeed()
    {
        return speed;
    }
    public void SetCanMove(bool canMove)
    {
        _canMove = canMove;
    }
}
