using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {

    public GameObject triEnemy;
    public GameObject squEnemy;
    public GameObject cirEnemy;

    public float spawnRate = 0.0f;
    private float lastSpawn = 0.0f;

    private int enSpawn;
	
	// Update is called once per frame
	void Update () {
	       if(Time.time - lastSpawn > spawnRate) {
            lastSpawn = Time.time;
            Instantiate(randEnemy(), randPoint(), Quaternion.identity);
           }

           if(Time.fixedTime % 10 == 0) {
            spawnRate = spawnRate / 2;
           }
	}

    GameObject randEnemy() {
        int r = Random.Range(0,3);
        switch (r) {
            case 0:
                return cirEnemy;
            case 1:
                return triEnemy;
            case 2:
                return squEnemy;
            default:
                Debug.Log("Randomization error");
                return null;
        } 
    }

    Vector3 randPoint() {
        float r = gameObject.GetComponent<SphereCollider>().radius;
        r = r * transform.localScale.x;

        float angle = Random.Range(0, Mathf.PI * 2);

        Vector3 point = new Vector3(r * Mathf.Cos(angle), r * Mathf.Sin(angle), 1);
        return point;
    }
}
