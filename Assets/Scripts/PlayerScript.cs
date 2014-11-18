using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public GameObject Attack1;
    public GameObject Attack2;
    public GameObject Attack3;

    public string lastHit = "";

    public GameScript gs;

    void OnTriggerEnter(Collider other) {
        gs.hitEnemy();

        if(other.tag.Equals("circle") && lastHit != "circle") {
            lastHit = "circle";
            Attack1.SetActive(true);
            Attack2.SetActive(false);
            Attack3.SetActive(false);
        }
        if(other.tag.Equals("square") && lastHit != "square") {
            lastHit = "square";
            Attack1.SetActive(false);
            Attack2.SetActive(true);
            Attack3.SetActive(false);
        }
        if(other.tag.Equals("triangle") && lastHit != "triangle") {
            lastHit = "triangle";
            Attack1.SetActive(false);
            Attack2.SetActive(false);
            Attack3.SetActive(true);
        }
        Destroy(other.gameObject);
    }
}
