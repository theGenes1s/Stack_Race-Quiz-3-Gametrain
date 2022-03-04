using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed = 10.0f;
    public float rotationSpeed = 720.0f;
    private Rigidbody playerRb; 
    [SerializeField] Color myColor;
    [SerializeField] Renderer [] myRends;
    Transform parentPickup;
    [SerializeField] Transform stackPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        SetColor(myColor);

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");   //Player Movement
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput,0,
        verticalInput);
        movementDirection.Normalize();
        
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        
        if (movementDirection != Vector3.zero)  //Player Rotation Towards Movement Direction.
        {
           
           Quaternion toRotation = Quaternion.LookRotation(movementDirection, 
           Vector3.up);

           transform.rotation = Quaternion.RotateTowards(transform.rotation, 
           toRotation, rotationSpeed * Time.deltaTime);
        }

        

    }
    void SetColor (Color colorIn)
        {
            myColor = colorIn;
            for (int i = 0; i < myRends.Length ; i++)
            {
                myRends[i].material.SetColor("_Color" , myColor);
            }

        }
        private void OnTriggerEnter (Collider other)
        {
            if(other.tag == "Pickup")
            {
                Transform otherTransform = other.transform;

                GameController.instance.UpdateScore(otherTransform.GetComponent<PickupStackColor>().value);

                Rigidbody otherRb = otherTransform.GetComponent<Rigidbody>();
                otherRb.isKinematic = true;
                other.enabled = false;
                if (parentPickup == null)
                {
                    parentPickup = otherTransform;
                    parentPickup.position = stackPosition.position;
                    parentPickup.parent = stackPosition;
                    
                }
                else{
                    parentPickup.position += Vector3.up * (otherTransform.localScale.y);
                    otherTransform.position = stackPosition.position;
                    otherTransform.parent = parentPickup;
                }
            }
        }

        
        
}
