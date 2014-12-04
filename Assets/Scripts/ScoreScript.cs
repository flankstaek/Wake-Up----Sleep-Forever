using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

    bool gameover = true;

    public GameScript gs;

	void Awake () {
	   DontDestroyOnLoad(transform.gameObject);
       Screen.showCursor = false;
	}

    void Update() {
        if(gameover && Application.loadedLevelName == "gameover") {
            transform.position = new Vector3(.5f, .5f, 0f);
            gameover = false;
        }
        if(Input.GetAxis("Start") > 0) {
            gs.resetScore();
            Application.LoadLevel("sleep");
            Destroy(gameObject);
        }
        if(Input.GetKeyDown("escape")) {
            Application.Quit();
        }
    }

}
