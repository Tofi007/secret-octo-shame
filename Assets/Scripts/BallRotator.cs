using UnityEngine;
using System.Collections;

public class BallRotator : MonoBehaviour {

    private float xRotation = 0f;
    private float yRotation = 0f;
    private float zRotation = 0f;

	// Update is called once per frame
	void Update()
    {
        xRotation += Random.Range(-1f, 1f) * Time.deltaTime;
        yRotation += Random.Range(-1f, 1f) * Time.deltaTime;
        zRotation += Random.Range(-1f, 1f) * Time.deltaTime;
        this.gameObject.transform.RotateAround(this.gameObject.transform.position, Vector3.right, xRotation);
        this.gameObject.transform.RotateAround(this.gameObject.transform.position, Vector3.up, yRotation);
        this.gameObject.transform.RotateAround(this.gameObject.transform.position, Vector3.forward, zRotation);
    }
}
