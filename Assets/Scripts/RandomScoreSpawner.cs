using UnityEngine;
using System.Collections;

public class RandomScoreSpawner : MonoBehaviour {
    public GameObject spawnedObject;

    public float spawnWidth = 5f;
    public float spawnHeight = 10f;
    
    public float spawnMin = 1.5f;
    public float spawnMax = 3f;

    public Color scoreColor;

    // Use this for initialization
    void Start () {
        Spawn ();
    }
    
    void Spawn () {
        Vector3 pos = transform.position;
        pos.x += Random.Range(-1f, 1f) * (spawnWidth / 2f);
        pos.y += Random.Range(-1f, 1f) * (spawnHeight / 2f);

        GameObject newObject = (GameObject)Instantiate (spawnedObject, pos, Quaternion.identity);
        newObject.layer = 12;

        newObject.renderer.material.color = scoreColor;
        
        Invoke ("Spawn", Random.Range(spawnMin, spawnMax));
    }
}
