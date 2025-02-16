using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranChecker : MonoBehaviour
{
    private float range = 1.1f;
    private Vector3 offset = new Vector3(0, 1f, 0);
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position + offset, -transform.up);
        Debug.DrawLine(transform.position + offset, transform.position + offset - transform.up * range, Color.red);    

      
        if (Physics.Raycast(ray, out hit, range))
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.layer == 3) 
            {
                Debug.Log("Walkable");
                animator.SetBool("Grounded", true);
            }
            else
            {
                animator.SetBool("Grounded", false);
            }
        }
        else
        {
            animator.SetBool("Grounded", false);
        }

       
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && animator.GetBool("Grounded"))
        {
            Debug.Log("Jump triggered");
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }
}
