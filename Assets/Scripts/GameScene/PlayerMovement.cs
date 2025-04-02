using UnityEngine;

namespace GameScene
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed;
        public GameObject looseScreen;
        public GameObject gameMenu;
    
        private Rigidbody2D _rb;
        private GameObject _player;
        private Vector2 _input;
        private ScoreManager _scoreManager;
        private Animator _animator;
        private bool _isDead;
    
        private void Start()
        {
            _rb = this.gameObject.GetComponent<Rigidbody2D>();
            _scoreManager = FindObjectOfType<ScoreManager>();
            _animator = this.gameObject.GetComponent<Animator>();
        }
    
        private void Update()
        {
            if (_isDead)
            {
                return;
            }
        
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dirToMouse = mousePos - (Vector2)transform.position;
            dirToMouse.Normalize();
        
            _input.x= Input.GetAxisRaw("Horizontal");
            _input.y= Input.GetAxisRaw("Vertical");
        
            if (_input.x < 0)
            {
                transform.localScale = new Vector3(2, 2, 2);
            }
            else if (_input.x > 0)
            {
                transform.localScale = new Vector3(-2, 2, 2);
            }

            if (_input.y != 0 || _input.x != 0)
            {
                _animator.SetBool("isRunning", true);
            }
            else
            {
                _animator.SetBool("isRunning", false);
            }
        }

        private void FixedUpdate()
        {
            if (_isDead)
            {
                return;
            }
        
            _rb.AddForce(_input * speed);
        }
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("KillIcon") && collision.isTrigger)
            {
                _isDead = true;
                LossScript lossScript = collision.GetComponent<LossScript>();
                if (lossScript != null)
                {
                    looseScreen.SetActive(true);
                }
                
                Destroy(gameMenu);
                Destroy(collision.gameObject);
            }
        
            if (collision.CompareTag("Icon") && collision.isTrigger)
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
}