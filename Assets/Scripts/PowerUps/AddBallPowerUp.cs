using UnityEngine;
using System.Collections;

public class AddBallPowerUp : PowerUp {

    AddBallPowerUp(int NoOfBalls) {
        noOfBalls = NoOfBalls;
    }

    public int noOfBalls;

    public override void PowerUpEffect() {
        GameManager.Instance.AddBall(noOfBalls);
    }
}
