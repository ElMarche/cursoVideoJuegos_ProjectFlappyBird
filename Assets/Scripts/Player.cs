using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rbody2D;
    [SerializeField] private float upForce = 350f;
    private bool isDead = false;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rbody2D= GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            Flap();

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("Die");
        isDead = true;
        GameManager.Instance.GameOver();
    }

    private void Flap()
    {
        animator.SetTrigger("Flap");
        rbody2D.velocity = Vector2.zero;
        rbody2D.AddForce(Vector2.up * upForce);
    }
}
