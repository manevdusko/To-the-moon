using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour {

    public static int score;
    public static int highscore;

    


    public static GameplayController instance;

    Text highScoreText;
    Text scoreText;
    public BoxSpawner box_Spawner;

    [HideInInspector]
    public BoxScript currentBox;

    public CameraFollow cameraScript;
    private int moveCount;

    void Awake() {
        if (instance == null)
            instance = this;
    }

    void Start() {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        highScoreText = GameObject.Find("HighScore").GetComponent<Text>();

        box_Spawner.SpawnBox();
         score = 0;
        highscore = PlayerPrefs.GetInt ("highscore", highscore);
        highScoreText.text = "" + highscore;
    }

    void Update() {
        DetectInput();
    }

    void DetectInput() {
        if (Input.GetMouseButtonDown(0)) {
            currentBox.DropBox();
        }    
    }

    public void SpawnNewBox() {
        score++;
        scoreText.text = "" + score;
        Invoke("NewBox", 0);
    }

    void NewBox() {
        box_Spawner.SpawnBox();
    }

    public void MoveCamera() {

        moveCount++;

        if(moveCount == 3) {
            moveCount = 0;
            cameraScript.targetPos.y += 2f;
        }

    }

    public void RestartGame() {
        if(score > highscore){
            highscore = score;
             PlayerPrefs.SetInt ("highscore", highscore);
             highScoreText.text = "" + highscore;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

} // class













































