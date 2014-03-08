using UnityEngine;
using System.Collections;

public class ArrowRotator : MonoBehaviour
{

    public GameObject ball;
    public float rotationSpeed = 300f;
    
    void Update()
    {
        transform.RotateAround(ball.transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
