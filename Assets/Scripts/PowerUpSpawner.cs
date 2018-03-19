using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpSpawner : MonoBehaviour {

    public Transform topLeft, topRight, bottomLeft, bottomRight;
    public List<GameObject> powerUps;
    public List<GameObject> powerUpTypes;

    public float SpawnTimer;
    
    public void StartSpawningPowerUps() {
        StartCoroutine(SpawnAfter(Random.Range(3f, SpawnTimer)));
    }

    IEnumerator SpawnAfter(float seconds) {
        yield return new WaitForSeconds(seconds);
        Debug.Log("testing");
        float x = Random.Range(bottomRight.position.x, topLeft.position.x);
        float y = Random.Range(bottomRight.position.y, topLeft.position.y);

        GameObject newPowerUp = Instantiate(powerUpTypes[Random.Range(0, powerUpTypes.Count)], new Vector3(x, y, 0), Quaternion.identity) as GameObject;
        powerUps.Add(newPowerUp);
        StartCoroutine(SpawnAfter(Random.Range(3f, 10f)));
    }

    public void RemoveAllPowerUps(){
        foreach(GameObject i in powerUps) {
            Destroy(i);           
        }
        powerUps.Clear();
        StopSpawning();
    }

    public void StopSpawning() {
        StopAllCoroutines();
    }
}
