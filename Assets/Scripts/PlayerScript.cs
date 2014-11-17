using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public GameObject Attack1;
    public GameObject Attack2;
    public GameObject Attack3;

    public string lastHit = "";

    void OnTriggerEnter(Collider other) {

        if(other.tag.Equals("circle")) {
            Attack1.SetActive(true);
            Attack2.SetActive(false);
            Attack3.SetActive(false);
            Debug.Log("Circle collided");
        }
        if(other.tag.Equals("square")) {
            Attack1.SetActive(false);
            Attack2.SetActive(true);
            Attack3.SetActive(false);
            Debug.Log("Square collided");
        }
        if(other.tag.Equals("triangle")) {
            Attack1.SetActive(false);
            Attack2.SetActive(false);
            Attack3.SetActive(true);
            Debug.Log("Triangle collided");
        }
        Destroy(other.gameObject);
    }
}
