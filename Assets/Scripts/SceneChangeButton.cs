using UnityEngine;
using System.Collections;

public class SceneChangeButton : MonoBehaviour
{
    public int scene;

    // Update is called once per frame
    void OnClick()
    {
        Application.LoadLevel(scene);
    }
}
