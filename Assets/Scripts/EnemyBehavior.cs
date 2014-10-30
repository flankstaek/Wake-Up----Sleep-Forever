using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

    public float moveSpeed = 500f;

	void Awake () {
        GameObject circ = GameObject.FindWithTag("playarea");
        GameObject transObj = new GameObject("Transformer");
        transObj.transform.position = circ.transform.position;
        transObj.transform.position = new Vector3 
        (transObj.transform.position.x, transObj.transform.position.y, 1);
        transform.LookAt(transObj.transform);

        if(gameObject.tag.Equals("triangle")) {
            transform.Rotate(180, 0, 0);
        }
        GameObject.Destroy(transObj);
    }

	// Update is called once per frame
    void Update () {
        if(gameObject.tag.Equals("triangle")) {
            transform.Translate(Vector3.back * (moveSpeed * Time.deltaTime));
        }
        else{
            transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));
        }
    }
}
