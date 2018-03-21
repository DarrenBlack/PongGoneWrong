using UnityEngine;
using System.Collections;

public abstract class PowerUp : MonoBehaviour {

    public string powerUpName;
    public string description;

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag == "Ball") {            
            PowerUpEffect();
            Destroy(this.gameObject);
            GameManager.Instance.screenShaker.Shake(0.5f, 0.025f);
        }
    }

    public abstract void PowerUpEffect();
}