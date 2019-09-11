using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour {
	private int score;
    public Text countText;
    public Rigidbody player;

	// Start is called before the first frame update
	void Start() {
        SetScoreText();
        player = GetComponent<Rigidbody>();
    }

	// Update is called once per frame
	void Update() {
		float h = Input.GetAxis("Horizontal"),
		      v = Input.GetAxis("Vertical");
		transform.Translate(
			h * Time.deltaTime * 10,
			v * Time.deltaTime * 10,
			0,
			Space.World
			);
	}

	void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.CompareTag("Finish")) {
            score += 1;
            SetScoreText();
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            score -= 1;
            SetScoreText();
        }
    }

    void resetPosition() {
        player.transform.position = new Vector3(0,-8,0);
    }

    void SetScoreText() {
        countText.text = "Score: " + score.ToString();
        resetPosition();
    }
}
