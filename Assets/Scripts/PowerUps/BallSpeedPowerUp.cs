using UnityEngine;
using System.Collections;

public class BallSpeedPowerUp : PowerUp {

    public float speedChange;

    BallSpeedPowerUp(float SpeedChange) {
        speedChange = SpeedChange;
    }

    public override void PowerUpEffect() {
        GameManager.Instance.SetBallSpeed(speedChange);
    }
}
