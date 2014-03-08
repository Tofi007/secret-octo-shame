using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{

    public GameObject arrow;
    public GameHandler gameHandler;
    public float force = 100f;
    public GameObject particle;
    
    void Update()
    {
        if (Input.anyKeyDown && !gameHandler.isGameOver)
        {
            AddArrowForce();
            gameHandler.DecreaseTaps();
        } 
    }
    
    void AddArrowForce()
    {
        Vector2 forceVector = (transform.position - arrow.transform.position);
        gameObject.rigidbody2D.AddForce(forceVector * force);

        GameObject clone = (GameObject) Instantiate(particle);
        clone.transform.parent = transform;
        Vector3 ballToArrowVector = transform.position - arrow.transform.position;
        clone.transform.position = transform.position - ballToArrowVector / 1.3f;
        clone.transform.rotation = arrow.transform.rotation;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Wall")
        {
            gameHandler.GameEnd();
        }
    }
}