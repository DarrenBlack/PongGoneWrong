using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    public float startingballSpeed = 100f;
    public float ballSpeed = 100f;

    public float beginWaitTime = 3f;

    public GameObject trail;
    
    public Rigidbody2D ballBody;

    void Start() {
        StartCoroutine(WaitFor(beginWaitTime));
    }

    void FixedUpdate() {
        ballBody.velocity = ballBody.velocity.normalized * ballSpeed;
    }

    IEnumerator WaitFor(float seconds) {
        yield return new WaitForSeconds(seconds);
        GoBall();
    }
	
	void OnCollisionEnter2D (Collision2D coll) {
        if(coll.collider.tag == "Paddle") {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y /2 + coll.collider.GetComponent<Rigidbody2D>().velocity.y/3);            
        }        	
	}
    
    public void GoBall() {        

        float fiftyFifty = Random.Range(0f, 1f);
        Vector2 newVelocity = new Vector2(0, 0);

        if(fiftyFifty < 0.5) {
            newVelocity.x = Random.Range(0.5f, 2.5f);
        }
        else{
            newVelocity.x = Random.Range(-0.5f, -2.5f);
        }

        fiftyFifty = Random.Range(0f, 1f);

        if (fiftyFifty < 0.5) {
            newVelocity.y = Random.Range(0.5f, 2.5f);
        }
        else {
            newVelocity.y = Random.Range(-0.5f, -2.5f);
        }

        ballBody.AddForce(newVelocity.normalized * ballSpeed);
    }


    void ChangeSpeed(float speedChange) {
        ballSpeed = ballSpeed + speedChange;
    }
}
