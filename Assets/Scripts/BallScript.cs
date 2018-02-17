using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
    
    public float ballSpeed = 100f;

    public float beginWaitTime = 3f;
    public float resetWaitTime = 0.5f;

    public GameObject trail;

    ParticleSystem trailParticleSystem;

    Rigidbody2D ballBody;

	// Use this for initialization
	void Start () {
        ballBody = GetComponent<Rigidbody2D>();
        trailParticleSystem = trail.GetComponent<ParticleSystem>();

        StartCoroutine(WaitToStart(beginWaitTime));
	}

    void FixedUpdate() {
        ballBody.velocity = ballBody.velocity.normalized * ballSpeed;
    }

    IEnumerator WaitToStart(float timeToWait) {
        yield return new WaitForSeconds(timeToWait);
        GoBall();        
    }
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D coll) {
        if(coll.collider.tag == "Paddle") {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y /2 + coll.collider.GetComponent<Rigidbody2D>().velocity.y/3);            
        }        	
	}

    void ResetBall() {
        trailParticleSystem.Stop();
        this.transform.position = new Vector3(0, 0, 0);
        ballBody.velocity = Vector2.zero;
        trailParticleSystem.Play();
        StartCoroutine(WaitToStart(resetWaitTime));
    }

    void GoBall() {
        //Randomises ball direction
        //REDO at some point to stop ball going at too sharp an angle up or down
        /*float ramdomNumber = Random.Range(-1f, 1f);
        Vector2 ballVelocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        ballBody.AddForce(startingVelocity.normalized * ballSpeed);
        */

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
}
