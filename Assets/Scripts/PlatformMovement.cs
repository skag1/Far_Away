using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : Mechanism
{
    [Header("Platform Movement Ends")]
    [SerializeField] private float leftEnd;
    [SerializeField] private float rightEnd;
    [SerializeField] private float upEnd;
    [SerializeField] private float downEnd;

    [Space(5)]

    [SerializeField] private float moveSpeedX;
    [SerializeField] private float moveSpeedY;

    private float left;
    private float right;
    private float up;
    private float down;
    private float normSpeedX = -1;
    private float normSpeedY = -1;

    private void Awake()
    {
        left = transform.position.x - leftEnd;
        right = transform.position.x + rightEnd;
        up = transform.position.y + upEnd;
        down = transform.position.y - down;
    }

    private void FixedUpdate()
    {
        if (isActivated)
        {
            Move();
        }
    }

    public override void Activate()
    {
        isActivated = true;
    }

    public override void Deactivate()
    {
        isActivated = false;
    }

    private void Move()
    {
        if (transform.position.x < left)
        {
            normSpeedX = 1;
        }
        else if (transform.position.x > right)
        {
            normSpeedX = -1;
        }

        if (transform.position.y < down)
        {
            normSpeedY = 1;
        }
        else if (transform.position.y > up)
        {
            normSpeedY = -1;
        }

        transform.position = new Vector2(transform.position.x + normSpeedX * moveSpeedX * 0.01f, transform.position.y + normSpeedY * moveSpeedY * 0.01f);
    }
}
