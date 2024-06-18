using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour
{
    private Vector2 followSpot;
    public float speed;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public bool inDialog;
    public bool cutSceneInProgress;

    // Start is called before the first frame update
    void Start()
    {
        followSpot = transform.position;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inDialog)
        {
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                followSpot = new Vector2(mousePosition.x, mousePosition.y);
               // Debug.Log(mousePosition);
            }
            transform.position = Vector2.MoveTowards(transform.position, followSpot, Time.deltaTime * speed);
            UpdateAnimation();
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        followSpot = transform.position;
    }

    private void UpdateAnimation()
    {

        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         float distance = Vector2.Distance(transform.position, followSpot);
                animator.SetFloat ("distance", distance);
                if (distance < 0.01)
                {

                 animator.SetFloat("angle", 0);
                }

     
    }

}
