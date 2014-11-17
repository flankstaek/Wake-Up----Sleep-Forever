using UnityEngine;
using System.Collections;

public class AttackScript3 : MonoBehaviour {

	float buttonAxis;
    public float timeActive = 0.0f;
    public float timeDelay = 0.0f;
    float timeKeeper = 0.0f;
	
	// Update is called once per frame
	void Update () {
        buttonAxis = Input.GetAxis("Button");

        if(buttonAxis != 1) {
            renderer.enabled = false;
            collider.enabled = false;
        }
        else if(Time.time - timeKeeper > timeDelay){
            timeKeeper = Time.time;
        }

        if(Time.time - timeKeeper <= timeActive) {
            renderer.enabled = true;
            collider.enabled = true;
        }
	}

     void OnTriggerEnter(Collider other) {
        Debug.Log("Attack 3 Destroy");
        Destroy(other.gameObject);
    }

    void OnDisable() {
        renderer.enabled = false;
        collider.enabled = false;
    }
}
