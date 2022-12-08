using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public float vel = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            animator.SetBool("Moving", true);
            Vector3 dir_norm = new Vector3(horizontal, 0, vertical).normalized;
            gameObject.transform.position += dir_norm * vel;
            gameObject.transform.LookAt(gameObject.transform.position + dir_norm);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }
}
