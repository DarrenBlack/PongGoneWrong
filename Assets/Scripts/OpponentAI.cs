using UnityEngine;
using System.Collections;

public class OpponentAI : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float paddleSpeed = 5f;

    void Start() {
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    void Reset() {

    }

    public void moveTowardsObject(Vector3 newTarget) {

        Vector2 velocity = rb2d.velocity;
        /*

        float distanceFromTargetY = transform.position.y - newTarget.y;
        Debug.Log(distanceFromTargetY);

        if (distanceFromTargetY <= 0.3 && distanceFromTargetY >= -0.3) {            
            velocity.y = 0;
        }
        else if (transform.position.y < newTarget.y) {            
            velocity.y = paddleSpeed;
        }
        else if (transform.position.y > newTarget.y) {
            velocity.y = -paddleSpeed;
        }


        rb2d.velocity = velocity;*/

        float moveDistance = paddleSpeed * Time.deltaTime;

        float ballDistance = Mathf.Abs(transform.position.y - newTarget.y);

        if(moveDistance > ballDistance) {
            moveDistance = ballDistance / 2;
        }

        if(newTarget.y > transform.position.y) {
            transform.Translate(Vector2.up * moveDistance);
        }
        else if(newTarget.y < transform.position.y) {
            transform.Translate(-(Vector2.up * moveDistance));
        }

        rb2d.velocity = velocity;
    }
}
