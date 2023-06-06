using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;

    public float horizontalSpeed = 15f; // adjust the speed to your liking
    public float jumpSpeed = 8f; // adjust the jump speed to your liking
    private bool isGrounded; // check if the player is on the ground
    private float initialZPos;
    public float returnSpeed = 2f;
    // public float pushBackForce = 20f; 
    private bool isHit;

    private bool isHurry;

    public float leanAngle = 20f;




    void ResetIsHit()
    {
        isHit = false;
        GlobalVar.isHit = false;
    }

    void Lean()
    {

        float leanAmount = Mathf.Sin(Time.time * 8f) * leanAngle + 10f;

        Quaternion targetRotation = Quaternion.Euler(leanAmount, 0f, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10f);



    }


    void Start()
    {
        controller = GetComponent<CharacterController>();
        initialZPos = transform.position.z;


    }



    void Update()

    {

        if (isHit)
        {

            Invoke("ResetIsHit", 1f);
            direction.z = Mathf.Lerp(direction.z, 0f, Time.deltaTime * 5f);
        }
        else
        {
            if (transform.position.z < initialZPos && isGrounded)
            {
                direction.z = returnSpeed;
            }
            else
            {
                direction.z = 0;
            }
        }



        // Move the player left or right based on arrow key input
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput != 0)
        {
            // Set the rotation angle based on the horizontal input
            float rotationAngle = horizontalInput > 0 ? -20f : 20f;

            // Calculate the target rotation based on the current rotation and the input direction
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, rotationAngle);

            // Use Mathf.Lerp to smoothly interpolate between the current rotation and the target rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10f);

            direction.x = horizontalInput * horizontalSpeed;
        }
        else
        {
            // Reset the rotation to the default rotation when there is no input
            Quaternion defaultRotation = Quaternion.Euler(0f, 0f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, defaultRotation, Time.deltaTime * 10f);

            direction.x = 0;
        }

        // Check if the player is on the ground
        isGrounded = controller.isGrounded;

        // Make the player jump if the jump button is pressed and the player is on the ground
        if (isGrounded)
        {
            isHurry = false;

            Lean();







            if (Input.GetButtonDown("Jump"))
            {



                // Calculate the target rotation based on the current rotation and the input direction
                Quaternion targetRotation = Quaternion.Euler(180f, 0f, 0f);

                // Use Mathf.Lerp to smoothly interpolate between the current rotation and the target rotation

                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 999f);

                direction.y = jumpSpeed;

            }
        }
        else
        {

            if (Input.GetButtonDown("Vertical"))
            {
                isHurry = true;
                direction.y = -8f;
            }
            if (!isHurry)
            {
                // Apply gravity if the player is in the air
                direction.y += Physics.gravity.y * Time.deltaTime;
            }

        }
    }


    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Thomas"))
        {
            isHit = true;
            GlobalVar.isHit = true;
            // Debug.Log("pushhhh");
            direction.z = -30f;
            if (!isGrounded)
            {
                Quaternion targetRotation = Quaternion.Euler(180f, 0f, 0f);



                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 100f);
            }
        }
        else if (other.gameObject.CompareTag("Loss"))
        {

            Destroy(gameObject, 0f);
        }

    }
}
