using UnityEngine;
using System.Collections;

public class RandomCubeSpawner : MonoBehaviour
{
    public GameObject spawnedObject;
    public float spawnWidth = 5f;
    public float spawnMin = 1.5f;
    public float spawnMax = 3f;
    public float dragMin = 0.3f;
    public float drageMax = 1f;
    public float massMin = 0.1f;
    public float massMax = 0.5f;
    public float scaleMin = 0.2f;
    public float scaleMax = 1f;
    public float speedUpTime = 100.0f;
    public float maxSpeedUp = 0.3f;

    private float currentSpeed = 0f;
    
    // Use this for initialization
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        Vector3 pos = transform.position;
        pos.x += Random.Range(-1f, 1f) * (spawnWidth / 2f);

        Vector3 scale = new Vector3(Random.Range(scaleMin, scaleMax), Random.Range(scaleMin, scaleMax), Random.Range(scaleMin, scaleMax));

        GameObject newObject = (GameObject)Instantiate(spawnedObject, pos, Quaternion.identity);
        newObject.layer = 11;

        newObject.transform.localScale = scale;
        newObject.transform.Rotate(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));

        Rigidbody rbody = newObject.GetComponent<Rigidbody>();
        rbody.drag = Random.Range(dragMin, drageMax);
        rbody.mass = Random.Range(massMin, massMax);

        currentSpeed = Mathf.Lerp(1.0f, maxSpeedUp, Time.time / speedUpTime);
        float nextSpawn = Random.Range(spawnMin, spawnMax) * currentSpeed;

        //print(nextSpawn);
        
        Invoke("Spawn", nextSpawn);
    }

    public float getSpeed()
    {
        return currentSpeed;
    }
}
