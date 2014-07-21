using UnityEngine;
using System.Collections;

public class ScoreLabelController : MonoBehaviour
{
    private Vector3 originalScale;
    private float originalAlpha;
    public ParticleEmitter partEmitter;
    private UILabel label;
    public GameHandler gameHandler;
    private bool isPulsing = false;

    void Start()
    {
        partEmitter.GetComponent<ParticleAnimator>().autodestruct = false;
        label = this.gameObject.GetComponent<UILabel>();
        originalScale = this.gameObject.transform.localScale;
        originalAlpha = label.alpha;
    }

    void Update()
    {
        if (!isPulsing)
        {
            SetCurrentScore();
        }
    }

    // Update is called once per frame
    public void Pulse(float growth, float secondsUntilRevert)
    {
        isPulsing = true;
        SetCurrentScore();

        partEmitter.Emit();

        label.alpha = 1.0f;

        this.gameObject.transform.localScale *= growth;
        Invoke("ReturnToOriginal", secondsUntilRevert);
    }

    void ReturnToOriginal()
    {
        this.gameObject.transform.localScale = originalScale;
        label.alpha = originalAlpha;
        isPulsing = false;
    }

    void SetCurrentScore()
    {
        label.text = gameHandler.getScore().ToString();
    }
}
