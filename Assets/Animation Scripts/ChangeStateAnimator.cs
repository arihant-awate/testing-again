using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class ChangeStateAnimator : MonoBehaviour
{
    [SerializeField]Animator animator;
    [SerializeField] Rigidbody rb;
    [SerializeField] float movespeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator != null)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {

                
                animator.SetTrigger("Walk");
                transform.Translate(Vector3.forward);
                

            }

        }
        if(animator.GetCurrentAnimatorStateInfo(0).tagHash==1)
        {
            Debug.Log(animator.GetCurrentAnimatorStateInfo(0).tagHash);
            animator.ResetTrigger("Walk");
        }
      
    }
}
