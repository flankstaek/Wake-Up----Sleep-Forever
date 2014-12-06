using UnityEngine;
using System.Collections;

public class AttackScript3 : MonoBehaviour {

	float buttonAxis;
    public float timeActive = 0.0f;
    public float timeDelay = 0.0f;
    float timeKeeper = 0.0f;
    bool delayed = false;

    public GameScript gs;
    public MainMenu ms;
	
	// Update is called once per frame
	void Update () {
        buttonAxis = Input.GetAxis("Button");

        if(!delayed) {
            renderer.enabled = false;
            collider.enabled = false;
        }
        if(Time.timeSinceLevelLoad - timeKeeper > timeDelay && !delayed && buttonAxis != 0) {
            delayed = true;
            timeKeeper = Time.timeSinceLevelLoad;
        }
        if(delayed && Time.timeSinceLevelLoad - timeKeeper <= timeActive) {
            renderer.enabled = true;
            collider.enabled = true;
        }
        else if(delayed){
            delayed = false;
            timeKeeper = Time.timeSinceLevelLoad;
        }
	}

     void OnTriggerEnter(Collider other) {
        if(gs != null) {gs.killEnemy();}
        if(ms != null) {ms.addKill();}
        Destroy(other.gameObject);
    }

    void OnDisable() {
        renderer.enabled = false;
        collider.enabled = false;
    }
}
