using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public GameObject Attack1;
    public GameObject Attack2;
    public GameObject Attack3;

    public string lastHit = "";

    void OnTriggerEnter(Collider other) {

        //Enable when not testing inputs
        // if(other.tag.Equals("circle")) {
        //     Attack1.SetActive(true);
        //     Debug.Log("Circle collided");
        // }
        // if(other.tag.Equals("square")) {
        //     Attack1.SetActive(false);
        //     Debug.Log("Square collided");
        // }
        // if(other.tag.Equals("triangle")) {
        //     Attack1.SetActive(false);
        //     Debug.Log("Triangle collided");
        // }
        Destroy(other.gameObject);
    }
}
