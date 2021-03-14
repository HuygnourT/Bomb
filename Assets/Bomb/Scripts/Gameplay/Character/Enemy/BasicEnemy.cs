using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        switch(currentDirection)
        {
            case Direction.Up:
                transform.Translate(Vector2.up * Time.fixedDeltaTime * speed);
                break;

            case Direction.Down:
                transform.Translate(Vector2.down * Time.fixedDeltaTime * speed);
                break;

            case Direction.Right:
                transform.Translate(Vector2.right * Time.fixedDeltaTime * speed);
                break;

            case Direction.Left:
                transform.Translate(Vector2.left * Time.fixedDeltaTime * speed);
                break;
        }
    }  

}
