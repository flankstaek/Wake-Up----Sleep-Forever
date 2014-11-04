using UnityEngine;
using System.Collections;

public class AttackScript1 : MonoBehaviour {

    float hAxis;
    float vAxis;

    void Update() {
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");

        float angle = Mathf.Atan2(vAxis * Mathf.PI, hAxis * Mathf.PI);
        Vector3 newPos = new Vector3(.5f * Mathf.Cos(angle), .5f * Mathf.Sin(angle), 1);

        transform.position = newPos;

        
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Rad2Deg * angle - 90f);

        /*
        float angle = Random.Range(0, Mathf.PI * 2);

        Vector3 point = new Vector3(r * Mathf.Cos(angle), r * Mathf.Sin(angle), 1);
        */
    }

	void OnTriggerEnter(Collider other) {
        Debug.Log("Destroyed shape");
        Destroy(other.gameObject);
    }
}
