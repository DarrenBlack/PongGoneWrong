using UnityEngine;
using System.Collections;

public class PaddleScript : MonoBehaviour {

    private Rigidbody2D rb2d;

    public float speed;
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;

    void Start () {
        rb2d = this.GetComponent<Rigidbody2D>();	
	}

	void Update () {
        Vector2 velocity = rb2d.velocity;

        if (Input.GetKeyDown(moveUp)) {
            velocity.y = speed;
        }
        else if (Input.GetKeyDown(moveDown)) {
            velocity.y = -speed;
        }         	
        else if (!Input.anyKey) {
            velocity.y = 0;
        }
        rb2d.velocity = velocity;
	}
}
