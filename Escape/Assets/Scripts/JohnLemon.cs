using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnLemon : MonoBehaviour
{
    public float moveSpeed = 10;
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
        bool hasMoveH = !Mathf.Approximately(moveH, 0);
        bool hasMoveV = !Mathf.Approximately(moveV, 0);

        bool IsWalking = hasMoveH || hasMoveV;
        animator.SetBool("IsWalking", IsWalking);

        if (IsWalking)
        {
            direction = new Vector3(moveH, 0, moveV);
            direction.Normalize();
        }
    }

    private void OnAnimatorMove()
    {
        Vector3 detalDirection = Vector3.RotateTowards(transform.forward, direction, Time.deltaTime * moveSpeed, 0);
        Quaternion rotation = Quaternion.LookRotation(direction);
        rb.MoveRotation(rotation);
        rb.MovePosition(transform.position + direction * animator.deltaPosition.magnitude);
    }
}
