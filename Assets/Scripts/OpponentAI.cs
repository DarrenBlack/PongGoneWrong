using UnityEngine;
using System.Collections;

public class OpponentAI : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float paddleSpeed = 5f;

    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    public void moveTowardsObject(Vector3 newTarget)
    {
        Vector2 velocity = rb2d.velocity;

        float moveDistance = paddleSpeed * Time.deltaTime;

        float ballDistance = Mathf.Abs(transform.position.y - newTarget.y);

        if (moveDistance > ballDistance)
        {
            moveDistance = ballDistance / 2;
        }

        if (newTarget.y > transform.position.y)
        {
            transform.Translate(Vector2.up * moveDistance);
        }
        else if (newTarget.y < transform.position.y)
        {
            transform.Translate(-(Vector2.up * moveDistance));
        }

        rb2d.velocity = velocity;
    }
}
