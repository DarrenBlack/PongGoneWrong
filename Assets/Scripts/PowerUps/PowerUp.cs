using UnityEngine;
using System.Collections;

public abstract class PowerUp : MonoBehaviour {

    public string powerUpName;
    public string description;

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.tag == "Ball") {
            
            PowerUpEffect();
            Destroy(this.gameObject);
        }
    }

    public abstract void PowerUpEffect();
}