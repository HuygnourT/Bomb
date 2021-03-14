using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected bool isRight;
    [SerializeField] protected bool isUp;

    [SerializeField] private LayerMask layerDetect;


    protected Direction currentDirection = Direction.Right;
    protected Rigidbody2D rb;

    private float countTime = 0;
    private float timeDetect;  

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeDetect = Random.Range(0, 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DetectWall();
        transform.position = GetNearestPosition();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag(ConstVariable.TAG_BOMB_EXPLOSION))
        {
            Destroy(gameObject);
        }
    }

    protected enum Direction
    {
        Right,
        Left,
        Up,
        Down
    };

    protected void DetectWall()
    {
        List<Direction> directions = new List<Direction>();

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right,1f,layerDetect);
        if(!hit.collider)
        {
            directions.Add(Direction.Right);
        }

        hit = Physics2D.Raycast(transform.position, Vector2.left, 1f, layerDetect);
        if (!hit.collider)
        {
            directions.Add(Direction.Left);
        }

        hit = Physics2D.Raycast(transform.position, Vector2.up, 1f, layerDetect);
        if (!hit.collider)
        {
            directions.Add(Direction.Up);
        }

        hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, layerDetect);
        if (!hit.collider)
        {
            directions.Add(Direction.Down);
        }

        if (directions.Count > 0)
            currentDirection = directions[Random.Range(0, directions.Count)];
    }

    private Vector3 GetNearestPosition()
    {
        Vector3 position = transform.position;// - Vector3.up * 0.5f;

        //if(currentDirection == Direction.Down)
        //    position += Vector3.up * 0.5f;

        //if (currentDirection == Direction.Up)
        //    position -= Vector3.down * 0.5f;

        //if (currentDirection == Direction.Right)
        //    position -= Vector3.right * 0.5f;

        //if (currentDirection == Direction.Left)
        //    position += Vector3.right * 0.5f;

        float posX = 0, posY = 0;

        if (Mathf.Round(position.x) > position.x)
        {
            posX = Mathf.Round(position.x) - 0.5f;
        }
        else
        {
            posX = Mathf.Round(position.x) + 0.5f;
        }

        if (Mathf.Round(position.y) > position.y)
        {
            posY = Mathf.Round(position.y) - 0.5f;
        }
        else
        {
            posY = Mathf.Round(position.y) + 0.5f;
        }

        position = new Vector3(posX, posY, position.z);

        return position;
    }

}
