using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //DestroySelf();
        animator.SetTrigger("Get");
        //Debug.Log("Enter");
    }

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Stay");
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Exit");
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
