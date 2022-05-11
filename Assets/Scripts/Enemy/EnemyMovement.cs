using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float reactionSpeed;

    private Ball ball;

    private float moveX;

    private Rigidbody2D rigidbodyBall;

    private float timer;

    private Rigidbody2D rigidbodyEnemy;

    private void Start()
    {
        timer = 0;

        rigidbodyEnemy = GetComponent<Rigidbody2D>();

        ball = SpawnBall.GetInstance().spawnedBall;

        rigidbodyBall = ball.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > reactionSpeed)
        {
            CalculateDirection();
            timer = 0;
        }
    }

    private void FixedUpdate()
    {
        rigidbodyEnemy.velocity = Vector2.zero;

        EnemyMove();
    }

    private void EnemyMove()
    {
        
        transform.position += new Vector3(moveX, 0, 0) * Time.deltaTime * speed;
    }

    private void CalculateDirection()
    {
        if (ball.transform.position.y > 0)
        {
            if (ball.transform.position.x < transform.position.x)
            {
                moveX = -1;
            }

            else if (rigidbodyBall.velocity.magnitude == 0)
            {
                moveX = 0;
            }

            else
            {
                moveX = 1;
            }
        }

        else
        {
            moveX = 0;
        }
    }

    public void SetParameters(float _speed, float _reactionSpeed)
    {
        speed = _speed;
        reactionSpeed = _reactionSpeed;
    }
}
