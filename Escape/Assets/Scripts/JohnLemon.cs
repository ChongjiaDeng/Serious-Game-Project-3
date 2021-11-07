using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnLemon : MonoBehaviour
{
    private Animator animator;
    private Vector3 direction;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        // character move as horizontal or vertical.

        bool hasMoveH = !Mathf.Approximately(moveH, 0);
        bool hasMoveV = !Mathf.Approximately(moveV, 0);
        // To detect the character if it moving. 

        bool IsWalking = hasMoveH || hasMoveV;
        animator.SetBool("IsWalking", IsWalking);

        if (IsWalking)
        {
            direction = new Vector3(moveH, 0, moveV);
            direction.Normalize();
        }
        //if the character is moving that our boolean activa as true. otherwise false.

    }


    private void OnAnimatorMove()
    {
        Quaternion rotation = Quaternion.LookRotation(direction);
        rb.MoveRotation(rotation);
        rb.MovePosition(transform.position + direction * animator.deltaPosition.magnitude);
    }

}


