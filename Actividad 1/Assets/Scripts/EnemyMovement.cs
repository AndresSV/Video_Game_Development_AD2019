using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public Rigidbody enemy;
    private int direction = 1;
    // Start is called before the first frame update
    void Start() {
        enemy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {

         enemy.transform.Translate(new Vector3(direction * 4 *Time.deltaTime, 0.0f, 0.0f), Space.World);

    }

    private void OnCollisionEnter(Collision collision) {
        direction *= -1;
    }
}
