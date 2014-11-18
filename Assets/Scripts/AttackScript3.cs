using UnityEngine;
using System.Collections;

public class AttackScript3 : MonoBehaviour {

	float buttonAxis;
    public float timeActive = 0.0f;
    public float timeDelay = 0.0f;
    float timeKeeper = 0.0f;
    bool delayed = true;

    public GameScript gs;
	
	// Update is called once per frame
	void Update () {
        buttonAxis = Input.GetAxis("Button");

        if(buttonAxis != 1) {
            renderer.enabled = false;
            collider.enabled = false;
        }
        else if(Time.time - timeKeeper <= timeActive && delayed) {
            renderer.enabled = true;
            collider.enabled = true;
        }
        else if(Time.time - timeKeeper > timeActive) {
            delayed = false;
            renderer.enabled = false;
            collider.enabled = false;
        }
        if(Time.time - timeKeeper >= timeDelay && !delayed){
            delayed = true;
            timeKeeper = Time.time;
        }

        if(buttonAxis > 0 && buttonAxis < 1) {
            timeKeeper = Time.time;
        }


	}

     void OnTriggerEnter(Collider other) {
        gs.killEnemy();
        Destroy(other.gameObject);
    }

    void OnDisable() {
        renderer.enabled = false;
        collider.enabled = false;
    }
}
