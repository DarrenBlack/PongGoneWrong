using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject scoreObj;

    static int playerScore1 = 0;
    static int playerScore2 = 0;    
    
    public static void Score(string wallName) {
        if(wallName == "rightWall") {
            playerScore1 += 1;
        }
        else if(wallName =="leftWall") {
            playerScore2 += 1;
        }
        GUIManager.UpdateScoreGui(playerScore1, playerScore2);        
    }
}
