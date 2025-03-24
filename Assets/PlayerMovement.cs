using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    
    private Rigidbody2D _rb;
    private GameObject _player;
    private Vector2 _input;
    private ScoreManager _scoreManager;
    
    private void Start()
    {
        _rb = this.gameObject.GetComponent<Rigidbody2D>();
        _scoreManager = FindObjectOfType<ScoreManager>();
    }
    
    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dirToMouse = mousePos - (Vector2)transform.position;
        dirToMouse.Normalize();
        
        _input.x= Input.GetAxisRaw("Horizontal");
        _input.y= Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        _rb.AddForce(_input * speed);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Icon"))
        {
            LossScript lossScript = collision.GetComponent<LossScript>();
            if (lossScript != null)
            {
                if (lossScript.isConnect)
                {
                    _scoreManager.IncreaseScore(lossScript.points);
                }
                else
                {
                    _scoreManager.DecreaseScore(lossScript.points);
                }
            }
            
            Destroy(collision.gameObject);
        }
    }
}
