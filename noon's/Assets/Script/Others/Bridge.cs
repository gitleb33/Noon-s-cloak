using UnityEngine;

public class Bridge : MonoBehaviour
{
    private Animator bridgeanim;
    private BoxCollider2D bridgecollider;
    private float animend;
    private bool timertrigger;
    private void Start()
    {
        bridgeanim = GetComponent<Animator>();
        bridgecollider = GetComponent<BoxCollider2D>();
        timertrigger = false;
    }

    private void Update()
    {
        if(timertrigger == true)
        {
            animend += Time.deltaTime;
        }


        if (animend >= 0.5)
        {
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        timertrigger = true;
        bridgeanim.Play("destroyed");
        bridgecollider.enabled = false;
    }
}
