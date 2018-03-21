using UnityEngine;
using System.Collections;

public class BallDetectorScript : MonoBehaviour
{

    //public GameObject parentTest;

    void OnTriggerStay2D(Collider2D hitinfo)
    {
        if (hitinfo.tag == "Ball")
        {
            gameObject.SendMessageUpwards("moveTowardsObject", hitinfo.transform.position);
        }
    }
}