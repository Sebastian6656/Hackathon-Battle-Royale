using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;
    Inventory inventory = new Inventory();
    public static Object WalkedOverObject;
 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.E))
        {
           
            if (WalkedOverObject) {
                
                inventory.AddItem(WalkedOverObject);
          
                Destroy(WalkedOverObject);

            }
            Debug.Log(WalkedOverObject);
            // you can play a buzz sound here since E key has failed :) :) :)
        }
    }




  
}
