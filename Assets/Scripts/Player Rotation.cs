using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float rotation = 10.0f;
    private void Start()
    {
        // _canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        // if (!_canMove) return; ver como se hace o quizas se llama PAUSE MANAGER CON PUBLIC METHOD
        RotateSprite();
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
}
