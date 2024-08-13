using System;
using UnityEngine;
using UnityEngine.Serialization;
using Unity.Mathematics;
using Random = UnityEngine.Random;


public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float rotation = 10.0f;
    [SerializeField] private KeyCode keyUp;
    [SerializeField] private KeyCode keyDown;
    [SerializeField] private KeyCode keyLeft;
    [SerializeField] private KeyCode keyRight;

    private SpriteRenderer _spriteRenderer;
    private Color _default;
    private Vector2 _distance;
    private bool _canMove;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        
        _default = _spriteRenderer.color;
        _canMove = true;
    }

    void Update()
    {
        if (!_canMove) return;
        Move();
        ChangeColor();
        RotateSprite();
        ReturnToDefaultColor();
        

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

    private void ChangeColor()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            float r, g, b;

            r = Random.Range(0f, 1f);
            g = Random.Range(0f, 1f);
            b = Random.Range(0f, 1f);
            
            _spriteRenderer.color = new Color(r,g,b);
        }
    }
    private void RotateSprite()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(Vector3.forward * (-rotation));
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(Vector3.forward * (rotation));
        }
    }

    private void ReturnToDefaultColor()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            _spriteRenderer.color = _default;  
        }
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
