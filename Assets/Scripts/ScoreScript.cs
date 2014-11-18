using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

    bool gameover = true;

	// Use this for initialization
	void Awake () {
	   DontDestroyOnLoad(transform.gameObject);
	}

    void Update() {
        if(gameover && Application.loadedLevelName == "gameover") {
            transform.position = new Vector3(.5f, .5f, 0f);
            gameover = false;
        }
    }

}
