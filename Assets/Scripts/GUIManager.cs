using UnityEngine;
using System.Collections;
using TMPro;

public class GUIManager : MonoBehaviour {

    public GameObject score1, score2;

    static TextMeshPro scoreText1, scoreText2;

    void Start() {
        scoreText1 = score1.GetComponent<TextMeshPro>();
        scoreText2 = score2.GetComponent<TextMeshPro>();
    }

    public static void UpdateScoreGui(int playerScore1, int playerScore2) {
        scoreText1.SetText(playerScore1.ToString());
        scoreText2.SetText(playerScore2.ToString());
    }

}
