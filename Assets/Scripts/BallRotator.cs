using UnityEngine;
using System.Collections;

public class BallRotator : MonoBehaviour {

    public float minForce = -30f;
    public float maxForce = 30f;

    public float deltaTime = 1f;

	// Update is called once per frame
	void Start () {
        RotateBall();
	}

    void RotateBall() {
        gameObject.rigidbody.AddTorque(Vector3.up * Random.Range(minForce, maxForce));
        gameObject.rigidbody.AddTorque(Vector3.forward * Random.Range(minForce, maxForce));
        gameObject.rigidbody.AddTorque(Vector3.right * Random.Range(minForce, maxForce));
        Invoke("RotateBall", deltaTime);
    }
}
