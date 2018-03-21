using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;


    public Camera mainCam;

    [Header("Collider Positions")]
    public BoxCollider2D topWall;
    public BoxCollider2D bottomWall;
    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;

    [Header("Players")]
    public GameObject player1;
    public GameObject player2;
    Transform player1Transform;
    Transform player2Transform;
    ParticleSystem player1PS;
    ParticleSystem player2PS;

    [Header("UI Positions")]
    public Transform scores;

    [Header("Ball Elements")]

    public GameObject masterBall;
    public List<GameObject> balls;

    [Header("Spawner Elements")]
    public PowerUpSpawner spawner;

    [Header("Paddle Elements")]
    public GameObject playerPaddle;
    public float paddleRotationSpeed;
    public bool PaddlesRotating;
    public Quaternion targetRotation;

    bool startOfGame = true;

    static int playerScore1 = 0;
    static int playerScore2 = 0;

    public ScreenShake screenShaker;

    void Awake()
    {
        Instance = this;
        screenShaker = this.GetComponent<ScreenShake>();
        player1Transform = player1.transform;
        player2Transform = player2.transform;

        player1PS = player1.GetComponentInChildren<ParticleSystem>();
        player2PS = player2.GetComponentInChildren<ParticleSystem>();
    }

    void Start()
    {
        StartGame();
    }

    void Update()
    {

        float angleDifference = Mathf.Abs(player1Transform.rotation.z - targetRotation.z);

        if (PaddlesRotating && angleDifference > 1.0f)
        {
            targetRotation *= Quaternion.AngleAxis(paddleRotationSpeed, Vector3.forward);
            player1Transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * Time.deltaTime);
        }
        else
        {
            player1Transform.rotation = Quaternion.identity;
            targetRotation = new Quaternion(0, 0, 180, 0);
            StopPaddleRotation();
        }
    }

    void StartGame()
    {        //move each wall to its edge location
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

    public void Reset()
    {
        player1PS.Pause();
        player2PS.Pause();

        Vector3 newpos1 = player1Transform.position;
        newpos1.x = mainCam.ScreenToWorldPoint(new Vector3(75f, 0f, 0f)).x;
        newpos1.y = 0;
        player1Transform.position = newpos1;

        Vector3 newpos2 = player2Transform.position;
        newpos2.x = mainCam.ScreenToWorldPoint(new Vector3(Screen.width - 75f, 0f, 0f)).x;
        newpos2.y = 0;
        player2Transform.position = newpos2;

        balls.Clear();
        spawner.RemoveAllPowerUps();
        GameObject newBall = Instantiate(masterBall, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        newBall.GetComponent<BallScript>().beginWaitTime = 3f;
        balls.Add(newBall);
        spawner.StartSpawningPowerUps();

        player1PS.Play();
        player2PS.Play();
    }

    public void Score(string wallName, GameObject scoringBall)
    {
        screenShaker.Shake(0.1f, 0.1f);

        if (wallName == "rightWall")
        {
            playerScore1 += 1;
        }
        else if (wallName == "leftWall")
        {
            playerScore2 += 1;
        }
        GUIManager.UpdateScoreGui(playerScore1, playerScore2);

        if (balls.Count == 1)
        {
            Destroy(scoringBall);
            balls.Remove(scoringBall);
            Reset();
        }
        else
        {
            Destroy(scoringBall);
            balls.Remove(scoringBall);
        }
    }

    public void SetBallSpeed(float speedChange)
    {
        foreach (GameObject ball in balls)
        {
            ball.SendMessage("ChangeSpeed", speedChange);
        }
    }

    public void AddBall(int numOfNewBalls)
    {
        for (int i = 0; i < numOfNewBalls; i++)
        {
            GameObject newBall = Instantiate(masterBall, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            newBall.GetComponent<BallScript>().beginWaitTime = 0.5f;
            balls.Add(newBall);
        }
    }

    public void StartPaddleRotation()
    {
        PaddlesRotating = true;
    }

    public void StopPaddleRotation()
    {
        PaddlesRotating = false;
    }

    public void FlipControls(float duration)
    {
        playerPaddle.GetComponent<PaddleScript>().FlipControls(duration);
    }
}
