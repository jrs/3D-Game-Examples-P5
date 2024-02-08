using UnityEngine;
using TMPro;

public class JumpingWithRollABall : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;
    public float Speed = 10f;
    public float JumpForce = 10f;
    public float GravityModifier = 1f;
    public float OutOfBounds = -10f;
    public bool IsOnGround = true;
    private float _horizontalInput;
    private float _forwardInput;
    private bool _isAtCheckpoint = false;
    private Vector3 _startingPosition;
    private Vector3 _checkpointPosition;
    private Rigidbody _playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= GravityModifier;
        _startingPosition = transform.position;
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Space) && IsOnGround)
        {
            _playerRigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            IsOnGround = false;
        }

        if(transform.position.y < OutOfBounds)
        {
            if(_isAtCheckpoint)
            {
                transform.position = _checkpointPosition;
            }
            else
            {
                transform.position = _startingPosition;
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(_horizontalInput, 0.0f, _forwardInput);

        _playerRigidbody.AddForce(movement * Speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsOnGround = true;
        }

        if(collision.gameObject.CompareTag("Dead Zone"))
        {
            if(_isAtCheckpoint)
            {
                transform.position = _checkpointPosition;
            }
            else
            {
                transform.position = _startingPosition;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Checkpoint"))
        {
            _isAtCheckpoint = true;
            _checkpointPosition = other.gameObject.transform.position;
        }
        if(other.gameObject.CompareTag("Endpoint"))
        {
            _isAtCheckpoint = false;
            transform.position = _startingPosition;
        }

        if(other.gameObject.CompareTag("Collectible"))
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
            Destroy(other.gameObject);
        }
    }
}
