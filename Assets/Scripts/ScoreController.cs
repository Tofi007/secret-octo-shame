using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour
{
    public float timeOutMin = 3f;
    public float timeOutMax = 6f;

    void Start()
    {
        Invoke("DestroyNow", Random.Range(timeOutMin, timeOutMax));
    }

    void DestroyNow()
    {
        Destroy(this.gameObject);
    }
}
