using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour {

    public Camera mainCam;
    public BoxCollider2D topWall, bottomWall, leftWall, rightWall;
    
    public Transform player1, player2, scores, ball;

	// Use this for initialization
	void Start () {
        //move each wall to its edge location
        topWall.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        topWall.offset = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y + 0.5f);

        bottomWall.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width * 2, 0f, 0f)).x, 1f);
        bottomWall.offset = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y - 0.5f);

        leftWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y); ;
        leftWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);

        rightWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        rightWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);

        Vector3 scorepos1 = scores.position;
        scorepos1.y = mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y;
        scores.position = scorepos1;

        Reset();
    }

    void Reset() {
        Vector3 newpos1 = player1.position;
        newpos1.x = mainCam.ScreenToWorldPoint(new Vector3(75f, 0f, 0f)).x;
        player1.GetComponent<Rigidbody2D>().position = newpos1;
        Vector3 newpos2 = player2.position;
        newpos2.x = mainCam.ScreenToWorldPoint(new Vector3(Screen.width - 75f, 0f, 0f)).x;
        player2.GetComponent<Rigidbody2D>().position = newpos2;
    }
}
