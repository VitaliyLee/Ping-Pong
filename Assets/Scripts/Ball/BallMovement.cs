using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [HideInInspector] public float rememberTime;
    public float timeToStart;

    [SerializeField] private AudioSource hitWallSound, hitPlatformSound;

    private Vector2 startDiraction;
    private float startPower;

    [Space(10)]
    [Range(1, 100)]
    private float boostPercent;

    private Rigidbody2D rigidbodyBall;
    private Vector3 rigidbodyVelocity;
    private float boostValue = 1;

    void Start()
    {
        rigidbodyBall = GetComponent<Rigidbody2D>();
        
        rememberTime = timeToStart;
    }

    void Update()
    {   
        if (timeToStart > 0)
        {
            timeToStart -= Time.deltaTime;
            if(timeToStart <= 0)
            {
                AddStartForce(); 
            }
        } 
    }

    private void FixedUpdate()
    {
        if (rigidbodyVelocity.magnitude - rigidbodyBall.velocity.magnitude > 0 && timeToStart <= 0)
        {
            rigidbodyBall.velocity = rigidbodyVelocity;
        }

        rigidbodyVelocity = rigidbodyBall.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Reflection(collision);
    }

    private void Reflection(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            Boost(boostPercent);
            rigidbodyBall.velocity = new Vector2(rigidbodyVelocity.x,
                rigidbodyVelocity.y * -1);

            rigidbodyBall.velocity *= boostValue;
            boostValue = 1;

            hitPlatformSound.Play();
            return;
        }

        hitWallSound.Play();

        rigidbodyBall.velocity = new Vector2(rigidbodyVelocity.x * -1, rigidbodyVelocity.y);
        
        boostValue = 1;      
    }

    private Vector2 GetMoveDirection()
    {
        float directionX = Random.Range(0.4f, 0.5f) * RandomSign();
        float directionY = Random.Range(0.4f, 0.5f) * RandomSign();

        return new Vector2(directionX , directionY);

        int RandomSign()
        {
            int random = Random.Range(0, 2);
            if (random == 0) return 1;
            return -1;
        }
    }

    public void AddStartForce()
    {
        startDiraction = GetMoveDirection();

        rigidbodyBall.AddForce(startDiraction * startPower, ForceMode2D.Force);
        rigidbodyVelocity = rigidbodyBall.velocity;
    }

    public void Boost(float _boostPercent)
    {
        boostValue += _boostPercent / 100;
    }

    public void SetParameters(float _boostPercent, float _startPower)
    {
        boostPercent = _boostPercent;
        startPower = _startPower;
    }
}
