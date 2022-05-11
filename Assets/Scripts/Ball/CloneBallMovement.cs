using UnityEngine;

public class CloneBallMovement : MonoBehaviour
{
    [SerializeField] private float startPower;
    private Vector2 startDiraction;

    private Rigidbody2D rigidbodyBall;
    private Vector3 rigidbodyVelocity;

    private float imprecision = 0.3f;
    
    void Start()
    {
        rigidbodyBall = GetComponent<Rigidbody2D>();

        AddStartForce();
    }

    void Update()
    {
        if (Mathf.Abs(rigidbodyVelocity.x) - Mathf.Abs(rigidbodyVelocity.y) > imprecision)
        {
            AddStartForce();
        }

        if (rigidbodyBall.velocity == Vector2.zero)
        {
            AddStartForce();
        }

        rigidbodyVelocity = rigidbodyBall.velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Score>().AddScore();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Reflection(collision);
    }

    private void Reflection(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            rigidbodyBall.velocity = new Vector2(rigidbodyVelocity.x,
                rigidbodyVelocity.y * -1);
            return;
        }

        rigidbodyBall.velocity = new Vector2(rigidbodyVelocity.x * -1, rigidbodyVelocity.y);
    }

    private Vector2 GetMoveDiraction()
    {
        float directionX = Random.Range(0.4f, 0.5f) * RandomSign();
        float directionY = Random.Range(0.4f, 0.5f) * RandomSign();

        return new Vector2(directionX, directionY);

        int RandomSign()
        {
            int random = Random.Range(0, 2);
            if (random == 0) return 1;
            return -1;
        }
    }

    public void AddStartForce()
    {
        startDiraction = GetMoveDiraction();

        rigidbodyBall.AddForce(startDiraction * startPower, ForceMode2D.Force);
        rigidbodyVelocity = rigidbodyBall.velocity;
    }
}
