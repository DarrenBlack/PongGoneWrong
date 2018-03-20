using UnityEngine;
using System.Collections;

public class RotatePaddlesPowerUp : PowerUp {
    

    public override void PowerUpEffect() {
        GameManager.Instance.StartPaddleRotation();
    }

}
