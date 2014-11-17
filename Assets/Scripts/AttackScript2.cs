using UnityEngine;
using System.Collections;

public class AttackScript2 : MonoBehaviour {

    float lBumper;
    float rBumper;
    float lTrigger;
    float rTrigger;

    
    public GameObject attack1;
    public GameObject attack2;

    bool trigger;

	// Update is called once per frame
    void Update () {
        lBumper = Input.GetAxis("Left Bumper");
        rBumper = Input.GetAxis("Right Bumper");
        lTrigger = Input.GetAxis("Left Trigger");
        rTrigger = Input.GetAxis("Right Trigger");

        trigger = false;

        if(lBumper == 1 && !trigger) {
            trigger = true;
            attack1.renderer.enabled = true;
            attack1.transform.rotation = Quaternion.Euler(0,0,90);
            attack2.renderer.enabled = false;
            attack2.collider.enabled = false;
            if(rBumper == 1) {
                attack1.renderer.enabled = false;
                attack2.renderer.enabled = true;
                attack2.collider.enabled = true;
                attack2.transform.rotation = Quaternion.Euler(0,0,0);
            }
            else if(lTrigger == 1) {
                attack1.renderer.enabled = false;
                attack2.renderer.enabled = true;
                attack2.collider.enabled = true;
                attack2.transform.rotation = Quaternion.Euler(0,0,90);
            }
        }
        if(lTrigger == 1 && !trigger) {
            trigger = true;
            attack1.renderer.enabled = true;
            attack1.transform.rotation = Quaternion.Euler(0,0,180);
            attack2.renderer.enabled = false;
            attack2.collider.enabled = false;
            if(lBumper == 1) {
                attack1.renderer.enabled = false;
                attack2.renderer.enabled = true;
                attack2.collider.enabled = true;
                attack2.transform.rotation = Quaternion.Euler(0,0,90);
            }
            else if(rTrigger == 1) {
                attack1.renderer.enabled = false;
                attack2.renderer.enabled = true;
                attack2.collider.enabled = true;
                attack2.transform.rotation = Quaternion.Euler(0,0,180);
            }
        }
        if(rBumper == 1 && !trigger) {
            trigger = true;
            attack1.renderer.enabled = true;
            attack1.transform.rotation = Quaternion.Euler(0,0,0);
            attack2.renderer.enabled = false;
            attack2.collider.enabled = false;
            if(lBumper == 1) {
                attack1.renderer.enabled = false;
                attack2.renderer.enabled = true;
                attack2.collider.enabled = true;
                attack2.transform.rotation = Quaternion.Euler(0,0,0);
            }
            else if(rTrigger == 1) {
                attack1.renderer.enabled = false;
                attack2.renderer.enabled = true;
                attack2.collider.enabled = true;
                attack2.transform.rotation = Quaternion.Euler(0,0,270);
            }
        }
        if(rTrigger == 1 && !trigger) {
            trigger = true;
            attack1.renderer.enabled = true;
            attack1.transform.rotation = Quaternion.Euler(0,0,270);
            attack2.renderer.enabled = false;
            attack2.collider.enabled = false;
            if(rBumper == 1) {
                attack1.renderer.enabled = false;
                attack2.renderer.enabled = true;
                attack2.collider.enabled = true;
                attack2.transform.rotation = Quaternion.Euler(0,0,270);
            }
            else if(lTrigger == 1) {
                attack1.renderer.enabled = false;
                attack2.renderer.enabled = true;
                attack2.collider.enabled = true;
                attack2.transform.rotation = Quaternion.Euler(0,0,180);
            }
        }
        if(!trigger) {
            attack1.renderer.enabled = false;
            attack2.renderer.enabled = false;
            attack2.collider.enabled = false;
        }
    }

    void OnDisable() {
        attack1.renderer.enabled = false;
        attack2.renderer.enabled = false;
        attack2.collider.enabled = false;

    }
}
