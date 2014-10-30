using UnityEngine;
using System.Collections;

public class AttackScript1 : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
        Debug.Log("Destroyed shape");
        Destroy(other.gameObject);
    }
}
