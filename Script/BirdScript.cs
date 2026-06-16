using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // Start is called before the first frame update

    private bool ispressed = false;
    private Rigidbody2D rb;

    private SpringJoint2D Spring;

    private TrailRenderer Trail;

    public float release = 0.1f;
    public float maxDragDist = 2f;
    public Transform anchor;

    private GameManager gameManager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Spring = GetComponent<SpringJoint2D>();
        Trail = GetComponent<TrailRenderer>();
        Trail.enabled = false;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ispressed)
        {
            Vector2 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(Vector3.Distance(mouseposition,anchor.position)>maxDragDist)
            {
                rb.position = anchor.position + ((Vector3)mouseposition-anchor.position).normalized*maxDragDist;
            }
            else
                rb.position = mouseposition;
        }
    }

    private void OnMouseUp() {
        ispressed = false;
        rb.isKinematic = false;
        StartCoroutine(ReleaseChar());
    }

    private void OnMouseDown() {
        ispressed = true;
        rb.isKinematic = true;
    }

    IEnumerator ReleaseChar()
    {
        yield return new WaitForSeconds(release);

        Spring.enabled = false;
        Trail.enabled = true;
        this.enabled = false;

        yield return new WaitForSeconds(2f);

        gameManager.NextBird();
    }
}
