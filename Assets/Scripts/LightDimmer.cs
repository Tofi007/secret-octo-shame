using UnityEngine;
using System.Collections;

public class LightDimmer : MonoBehaviour {

    public float dimSpeed = 1f; 

	void Update () {
        gameObject.light.intensity -= dimSpeed * Time.deltaTime;
	}
}
