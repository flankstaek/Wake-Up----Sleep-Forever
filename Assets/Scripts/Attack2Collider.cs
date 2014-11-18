using UnityEngine;
using System.Collections;

public class Attack2Collider : MonoBehaviour {

    public GameScript gs;


 void OnTriggerEnter(Collider other) {
        gs.killEnemy();
        Destroy(other.gameObject);
}
}
