using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class SpaceShipController : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 3f;
    public float thrustSpeed = 10f;
    public float reverseThrustSpeed = 5f;

    private Vector2 movementInput;
    private Vector2 rotationInput;
    private float thrustInput;
    private float reverseThrustInput;

    

    private void Update()
    {
        MoveSpaceship();
        RotateSpaceship();
        ApplyThrust();
        ApplyReverseThrust();
    }

    private void OnMove(InputValue value){
       movementInput = value.Get<Vector2>();
    }

    private void OnRotate(InputValue value)
    {
        rotationInput = value.Get<Vector2>();
    }
    private void OnThrust(InputValue value)
    {
        thrustInput = value.Get<float>();
        
    }
    private void OnReverseThrust(InputValue value)
    {
        reverseThrustInput = value.Get<float>();
        
    }



    private void MoveSpaceship()
    {
         // Get movement input values
        float horizontalInput = movementInput.x;
        float verticalInput = movementInput.y;

        // Calculate rotation in the x-axis
        float rotationX = -verticalInput * rotationSpeed;
        Quaternion xRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.rotation *= xRotation;

        // Calculate movement
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);

    }

    private void RotateSpaceship()
    {
        // Get rotation input values
        float horizontalInput = rotationInput.x;

        // Calculate rotation
        float rotationAmount = horizontalInput * rotationSpeed;
        Quaternion rotation = Quaternion.Euler(0f, rotationAmount, 0f);
        transform.rotation *= rotation;
    }

    private void ApplyThrust()
    {
        // Get thrust input value
        float thrust = thrustInput * thrustSpeed;

        // Calculate movement along the z-axis
        Vector3 thrustMovement = new Vector3(0f, 0f, thrust) * Time.deltaTime;
        transform.Translate(thrustMovement);
    }

    private void ApplyReverseThrust(){
        //Get reverse thrust input value
        float reverseThrust = reverseThrustInput * reverseThrustSpeed;

        //Calculate movement along the z-axis in reverse
        Vector3 reverseThrustMovement = new Vector3(0f,0f,-reverseThrust) * Time.deltaTime;
        transform.Translate(reverseThrustMovement);

    }
   
}
