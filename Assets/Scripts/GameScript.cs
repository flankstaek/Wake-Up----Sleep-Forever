using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

    public GameObject scoreObj;

    public int scoreVal = 0;

    private int count = 0;
	
	// Update is called once per frame
	void Update () {
        scoreVal += (int)((double)Time.time * 10.0) - count;

        scoreObj.guiText.text = scoreVal.ToString();

        count = (int)((double)Time.time * 10.0);
	}

    public void killEnemy() {
        scoreVal += 100;
    }

    public void hitEnemy() {
        scoreVal -= 100;
    }

    public void resetScore() {
        scoreVal = 0;
    }
}
