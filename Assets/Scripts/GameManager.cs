using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public Camera mainCam;
    public BoxCollider2D topWall, bottomWall, leftWall, rightWall;

    public Transform player1, player2, scores;

    public PowerUpSpawner spawner;

    public GameObject masterBall;
    
    public List<GameObject> balls;

    bool startOfGame = true;

    static int playerScore1 = 0;
    static int playerScore2 = 0;

    void Awake() {
        Instance = this;
    }

    void Start() {
        StartGame();        
    }

    void StartGame() {        //move each wall to its edge location
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

    public void Reset() {
        Vector3 newpos1 = player1.position;
        newpos1.x = mainCam.ScreenToWorldPoint(new Vector3(75f, 0f, 0f)).x;
        player1.GetComponent<Rigidbody2D>().position = newpos1;
        Vector3 newpos2 = player2.position;
        newpos2.x = mainCam.ScreenToWorldPoint(new Vector3(Screen.width - 75f, 0f, 0f)).x;
        player2.GetComponent<Rigidbody2D>().position = newpos2;

        balls.Clear();
        spawner.RemoveAllPowerUps();
        GameObject newBall = Instantiate(masterBall, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        newBall.GetComponent<BallScript>().beginWaitTime = 3f;
        balls.Add(newBall);
        spawner.StartSpawningPowerUps();
    }

    public void Score(string wallName, GameObject scoringBall) {
        if(wallName == "rightWall") {
            playerScore1 += 1;
        }
        else if(wallName =="leftWall") {
            playerScore2 += 1;
        }
        GUIManager.UpdateScoreGui(playerScore1, playerScore2);

        if(balls.Count == 1) {
            Destroy(scoringBall);
            balls.Remove(scoringBall);
            Reset();
        }
        else {
            Destroy(scoringBall);
            balls.Remove(scoringBall);
        }        
    }

    public void SetBallSpeed(float speedChange) {
        foreach(GameObject ball in balls) {
            ball.SendMessage("ChangeSpeed", speedChange);
        }
    }



    public void AddBall(int numOfNewBalls) {
        for (int i = 0; i < numOfNewBalls; i++) {            
            GameObject newBall = Instantiate(masterBall, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            newBall.GetComponent<BallScript>().beginWaitTime = 0.5f;
            balls.Add(newBall);
        }
    }

    public void PowerUpHit() {
        
    }

}
