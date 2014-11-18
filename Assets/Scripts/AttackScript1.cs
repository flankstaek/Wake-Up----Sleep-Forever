using UnityEngine;
using System.Collections;

public class AttackScript1 : MonoBehaviour {

    float hAxis;
    float vAxis;

    public GameScript gs;

    void Update() {
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");

        if(hAxis != 0 || vAxis != 0) {
            renderer.enabled = true;
            collider.enabled = true;

            float angle = Mathf.Atan2(vAxis * Mathf.PI, hAxis * Mathf.PI);
            Vector3 newPos = new Vector3(.5f * Mathf.Cos(angle), .5f * Mathf.Sin(angle), 1);

            transform.position = newPos;


            transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Rad2Deg * angle - 90f);
        }
        else {
            renderer.enabled = false;
            collider.enabled = false;
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
