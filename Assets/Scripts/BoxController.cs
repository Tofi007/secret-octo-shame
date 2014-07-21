using UnityEngine;
using System.Collections;

public class BoxController: MonoBehaviour
{

    public float minForce = -1f;
    public float maxForce = 1f;

    void Start()
    {
        this.gameObject.renderer.material.color = Color.yellow;
        RotateBox();
    }
    
    void RotateBox() {
        gameObject.rigidbody.AddTorque(Vector3.up * Random.Range(minForce, maxForce));
        gameObject.rigidbody.AddTorque(Vector3.forward * Random.Range(minForce, maxForce));
        gameObject.rigidbody.AddTorque(Vector3.right * Random.Range(minForce, maxForce));
    }

    void OnCollisionStay(Collision coll)
    {
        if (this.gameObject.tag == "Obstacle")
        {
            if (coll.gameObject.tag == "Ball")
            {
                DestroyBox();
            } else if (coll.gameObject.tag == "LowerWall")
            {
                BecomeWall();
            }
        }
    }

    void DestroyBox()
    {
        Destroy(this.gameObject);
    }

    void BecomeWall()
    {
        this.gameObject.tag = "LowerWall";
        this.gameObject.renderer.material.color = Color.red;
        this.enabled = false;
    }
}
