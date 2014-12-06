using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

    bool gameover = true;
    bool highscore;
    int score;

    public GameScript gs;
    public GameObject scoreObj;

    private int spaces = 0;

	void Awake () {
	   DontDestroyOnLoad(transform.gameObject);
       Screen.showCursor = false;
	}

    void Update() {
        if(gameover && Application.loadedLevelName == "gameover") {
            transform.position = new Vector3(.5f, .45f, 0f);
            guiText.alignment = TextAlignment.Center;
            guiText.anchor = TextAnchor.MiddleCenter;
            if(PlayerPrefs.GetInt("score") <= score) {
                PlayerPrefs.SetInt("score", score);
                highscore = true;
            }
            else {
                highscore = false;
            }
            if(highscore) {
                guiText.text = "NEW HIGH SCORE! " + score;
            }
            else {
                scoreObj.guiText.text = "Your high score is: " + PlayerPrefs.GetInt("score");
                Instantiate(scoreObj);
                guiText.text = "Your score was: " + score;
            }
            gameover = false;
        }
        else if(gameover) {
            score = gs.getScore();
        }
        if(Input.GetAxis("Start") > 0) {
            PlayerPrefs.Save();
            gs.resetScore();
            Application.LoadLevel("sleep");
            Destroy(gameObject);
            spaces = 0;
        }
        if(Input.GetKeyDown("escape")) {
            Application.Quit();
        }
        if(Input.GetKeyDown("space")) {
            spaces++;
        }
        if(spaces > 5) {
            PlayerPrefs.DeleteAll();
        }
    }

}
