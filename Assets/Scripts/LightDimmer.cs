using UnityEngine;
using System.Collections;

public class LightDimmer : MonoBehaviour
{
    public float dimSpeedStart = 1f;
    public float dimSpeedEnd = 1f;

    void Update()
    {
        //gameObject.light.intensity -= dimSpeed * Time.deltaTime;
        gameObject.transform.position += Vector3.forward * Time.deltaTime * Mathf.Lerp(dimSpeedStart, dimSpeedEnd, Time.deltaTime * 0.7f);
    }
}
