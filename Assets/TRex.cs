using UnityEngine;
using System.Collections;

public class TRex : MonoBehaviour
{
    private enum Direction { LEFT, RIGHT }

    private Direction dir = Direction.LEFT;

    public KeyCode actionButton = KeyCode.Space;
    public float speed = 4;

    public void Update()
    {
        if (Input.GetKeyDown(actionButton))
        {
            ToggleDirection();
        }
    }

    public void FixedUpdate()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        Vector3 vel = body.velocity;
        float velX;
        if (dir == Direction.LEFT)
        {
            velX = -speed;
        }
        else
        {
            velX = speed;
        }
        body.velocity = new Vector3(velX, vel.y, 0f);
    }

    public void ToggleDirection()
    {
        dir = (Direction) (((int)dir + 1) % 2);
    }
}
