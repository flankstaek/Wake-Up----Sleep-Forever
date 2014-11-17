using UnityEngine;
using System.Collections;

public class Attack2Collider : MonoBehaviour {

 void OnTriggerEnter(Collider other) {
        Debug.Log(other.gameObject.tag);
        Debug.Log("Attack 2 Destroy");
        Destroy(other.gameObject);
}
}
