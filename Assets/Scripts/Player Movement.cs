using System;
using UnityEngine;
using UnityEngine.Serialization;
using Unity.Mathematics;
using Random = UnityEngine.Random;


public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private Player  playerSelection;
    
    private Vector2 _distance;
    private bool _canMove;
    private KeyCode _keyUp;
    private KeyCode _keyDown;
    
    private enum Player
    {
        Player1,
        Player2
    }
    private void Awake()
    {
        switch (playerSelection)
        {
            case Player.Player1:
                _keyUp = KeyCode.W;
                _keyDown = KeyCode.S;
                break;
            case Player.Player2: //todo Como haria esto correctamente? Porque el sprite quiero que mire <- pero eso cambia si esta rotado
                _keyUp = KeyCode.DownArrow;
                _keyDown = KeyCode.UpArrow;
                break;
            default:
                Debug.LogError("Player Movement - Awake - Player no asignado");
                break;
        }  
    }
    private void Start()
    {
        _canMove = true;
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
        if (!_canMove) return;
        _distance = Vector2.zero;
        if (Input.GetKey(_keyUp))
        {
            _distance += Vector2.left; //todo Ver si esto esta bien asi o como rotar el sprite
        }
        if (Input.GetKey(_keyDown))
        {
            _distance += Vector2.right; //todo lo mismo se aplica
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
