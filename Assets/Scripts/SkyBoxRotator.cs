using UnityEngine;
using System.Collections;

public class SkyBoxRotator : MonoBehaviour {

    public float xSpeed = 0f;
    public RandomCubeSpawner rcs;
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.RotateAround(this.gameObject.transform.position, Vector3.right, xSpeed * Time.deltaTime * (1.0f / rcs.getSpeed()));
	}
}
