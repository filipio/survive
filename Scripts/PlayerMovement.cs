using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 30f;
    [SerializeField]
    private float moveSpeed = 5f;

    private Animator animator;
    private CharacterController characterController;


    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
    }


    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var mouseHorizontal = Input.GetAxis("Mouse X");

        animator.SetFloat("Speed", vertical);

        if(Input.GetMouseButton(1) == false)
        {
            transform.Rotate(Vector3.up, mouseHorizontal * Time.deltaTime * rotationSpeed);
        }
        
        characterController.SimpleMove(transform.forward * Time.deltaTime * moveSpeed * vertical);
    }
}
