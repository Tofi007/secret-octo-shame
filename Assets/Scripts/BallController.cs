using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{

    public GameObject arrow;
    public GameHandler gameHandler;
    public float force = 1000f;
    public GameObject particle;

    public int scoreNumber = 5;
    
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
        gameObject.rigidbody.AddForce(forceVector * force);

        GameObject clone = (GameObject) Instantiate(particle);
        clone.transform.parent = transform;
        Vector3 ballToArrowVector = transform.position - arrow.transform.position;
        clone.transform.position = transform.position - ballToArrowVector / 1.3f;
        clone.transform.rotation = arrow.transform.rotation;
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "LowerWall" || coll.gameObject.tag == "Wall")
        {
            this.gameObject.tag = "LowerWall";
            gameHandler.GameEnd();
        } else if (coll.gameObject.tag == "PlusScore")
        {
            gameHandler.IncreaseScore(scoreNumber);
            Destroy(coll.gameObject);
        } else if (coll.gameObject.tag == "NegScore")
        {
            gameHandler.IncreaseScore((-1) * scoreNumber);
            Destroy(coll.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlusScore")
        {
            gameHandler.IncreaseScore(scoreNumber);
            Destroy(other.gameObject);
        } else if (other.gameObject.tag == "NegScore")
        {
            gameHandler.IncreaseScore((-1) * scoreNumber);
            Destroy(other.gameObject);
        }
    }
}