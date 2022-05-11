using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    private Vector2 mousePosition;

    private float moveX;

    private Rigidbody2D rigidbody2;

    private void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Movement();
        }
        rigidbody2.velocity = Vector2.zero;
    }

    private void Movement()
    {
        MoveDirection();

        if (Math.Round(transform.position.x, 1) != Math.Round(mousePosition.x, 1))
        {
            transform.position += new Vector3(moveX, 0, 0) * movementSpeed * Time.deltaTime;
        }
    }

    private void MoveDirection()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePosition.x == 0) moveX = 0;
        if (mousePosition.x > 0) moveX = 1;
        if (mousePosition.x < 0) moveX = -1;
    }

    public void SetSpeed(float Speed)
    {
        movementSpeed = Speed;
    }
}
