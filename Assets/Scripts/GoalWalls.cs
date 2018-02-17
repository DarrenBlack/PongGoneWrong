using UnityEngine;
using System.Collections;

public class GoalWalls : MonoBehaviour {
    
    void OnTriggerStay2D(Collider2D hitinfo) {
        if(hitinfo.tag == "Ball") {
            GameManager.Score(transform.name);
            hitinfo.gameObject.SendMessage("ResetBall");          
        }
    }
}
