using UnityEngine;
using System.Collections;

public class IntroPlayerScript : MonoBehaviour {

    public GameObject Attack1;
    public GameObject Attack2;
    public GameObject Attack3;

    public Material blue;
    public Material red;
    public Material green;

    public GameObject player;

    public string lastHit = "";

    public bool collide = true;


    void OnTriggerEnter(Collider other) {
        if(collide) {
            if(other.tag.Equals("circle") && lastHit != "circle") {
                lastHit = "circle";
                Attack1.SetActive(true);
                Attack2.SetActive(false);
                Attack3.SetActive(false);
                player.renderer.material = blue;
            }
            if(other.tag.Equals("square") && lastHit != "square") {
                lastHit = "square";
                Attack1.SetActive(false);
                Attack2.SetActive(true);
                Attack3.SetActive(false);
                player.renderer.material = red;
            }
            if(other.tag.Equals("triangle") && lastHit != "triangle") {
                lastHit = "triangle";
                Attack1.SetActive(false);
                Attack2.SetActive(false);
                Attack3.SetActive(true);
                player.renderer.material = green;
            }
        }
        Destroy(other.gameObject);
    }

    public void attackOff() {
        Attack1.SetActive(false);
        Attack2.SetActive(false);
        Attack3.SetActive(false);
    }
}
