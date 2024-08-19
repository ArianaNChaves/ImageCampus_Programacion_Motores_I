using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeColor : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Color _default;
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        // _canMove = true;
    }
    void Update()
    {
        // if (!_canMove) return;
        ChangeColor();
        ReturnToDefaultColor();
    }
    private void ReturnToDefaultColor()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            _spriteRenderer.color = _default;  
        }
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
}
