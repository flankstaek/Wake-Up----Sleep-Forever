using UnityEngine;
using System.Collections;

public class Attack2Collider : MonoBehaviour {

    public GameScript gs;
    public MainMenu ms;


 void OnTriggerEnter(Collider other) {
        if(gs != null) {gs.killEnemy();}
        if(ms != null) {ms.addKill();}
        Destroy(other.gameObject);
}
}
