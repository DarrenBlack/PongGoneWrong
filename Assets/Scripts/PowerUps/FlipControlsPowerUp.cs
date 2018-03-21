using UnityEngine;
using System.Collections;
using System;

public class FlipControlsPowerUp : PowerUp
{

    public float duration;

    public override void PowerUpEffect()
    {
        GameManager.Instance.FlipControls(duration);
    }

}
