using System;
using UnityEngine;
using UnityEngine.Serialization;
using Unity.Mathematics;
using Random = UnityEngine.Random;


public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private Player playerSelection;

    private const int FIXED_SPEED = 50;
    private const float WHERE_STOP = 4.0f;
    
    private const float HIGH = 15.0f;
    private const float NORMAL = 10.0f;
    private const float LOW = 5.0f;
    
    private Vector2 _distance;
    private KeyCode _keyUp;
    private KeyCode _keyDown;
    private SpeedVariation _lastVariation;
    private Rigidbody2D _rigidbody2D;

    private bool _canMoveUp;
    private bool _canMoveDown;
    
    private enum Player
    {
        Player1,
        Player2
    }
    private enum SpeedVariation
    {
        Default,
        Normal,
        High,
        Low
    }
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        switch (playerSelection)
        {
            case Player.Player1:
                _keyUp = KeyCode.W;
                _keyDown = KeyCode.S;
                break;
            case Player.Player2:
                _keyUp = KeyCode.UpArrow;
                _keyDown = KeyCode.DownArrow;
                break;
            default:
                Debug.LogError("Player Movement - Awake - Player no asignado");
                break;
        }  
    }
    private void Start()
    {
        _lastVariation = SpeedVariation.Normal;
    }
    void Update()
    {
        RestrictMovement();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        _distance = Vector2.zero;
        
        if (Input.GetKey(_keyUp) && _canMoveUp)
        {
            _distance += Vector2.up;
        }
        if (Input.GetKey(_keyDown) && _canMoveDown)
        {
            _distance += Vector2.down;
        }

        _rigidbody2D.velocity = _distance * (speed * Time.fixedDeltaTime * FIXED_SPEED);
    }
    private void RestrictMovement()
    {
        _canMoveUp = transform.position.y <= WHERE_STOP;
        _canMoveDown = transform.position.y >= -WHERE_STOP;

        if (!_canMoveUp && _rigidbody2D.velocity.y > 0)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
        }
        else if (!_canMoveDown && _rigidbody2D.velocity.y < 0)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, 0);
        }
    }
    public void ChangeSpeedModifier(int change)
    {
        switch (change)
        {
            case 0:
                if (_lastVariation != SpeedVariation.Normal)
                {
                    SetPlayerSpeed(NORMAL);
                    _lastVariation = SpeedVariation.Normal;
                }
                else
                {
                    ChangeSpeedModifier(1);
                }
                break;
            case 1:
                if (_lastVariation != SpeedVariation.High)
                {
                    SetPlayerSpeed(HIGH);
                    _lastVariation = SpeedVariation.High;
                }
                else
                {
                    ChangeSpeedModifier(2);
                }
                break;
            case 2:
                if (_lastVariation != SpeedVariation.Low)
                {
                    SetPlayerSpeed(LOW);
                    _lastVariation = SpeedVariation.Low;
                }
                else
                {
                    ChangeSpeedModifier(0);
                }
                break;
            default:
                Debug.LogError("Player Movement - Change Speed Modifier - Out of range");
                break;
        }
        // Debug.Log($"Players Speed: {_lastVariation}");
    }
    public void SetPlayerSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    public float GetPlayerSpeed()
    {
        return speed;
    }
}
