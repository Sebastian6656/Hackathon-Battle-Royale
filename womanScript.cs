using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class womanScript : MonoBehaviour
{
    float moveSpeed;
    float gravity;
    float jumpSpeed;
    float groundLevel;
    float turnSpeed;
    Rigidbody body;
    bool colliding;
    Rigidbody collidingBody;
    GameObject held;
    bool thrown;
    Inventory inventory;
    Transform tempTrans;
    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory();
        thrown = false;
        moveSpeed = 5f;
        turnSpeed = 180f;
        gravity = 0.5f;
        groundLevel = transform.position.y;
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        turn();
        jump2();
        hit();
        pickables();
        itemChange();
    }
    void itemChange()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (held != null)
            {
                held.transform.position = new Vector3(1000, 1000, 1000);
            }
            held = inventory.items[0];
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            if (held != null)
            {
                held.transform.position = new Vector3(1000, 1000, 1000);
            }
            held = inventory.items[1];
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            if (held != null)
            {
                held.transform.position = new Vector3(1000, 1000, 1000);
            }
            held = inventory.items[2];
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            if (held != null)
            {
                held.transform.position = new Vector3(1000, 1000, 1000);
            }
            held = inventory.items[3];
        }
    }
    void pickables()
    {
        if (held!=null)
        {
            held.transform.localPosition = new Vector3(-75, 0, 0);
        }
        if (held!=null && Input.GetMouseButtonDown(0))
        {
            applyForce(held.GetComponent<Rigidbody>());
            held.transform.parent = null;
            inventory.RemoveItem(held);
            held = null;
        }
        if (collidingBody!=null && collidingBody.tag=="pickable")
        {
            if (Input.GetKey(KeyCode.E))
            {
                inventory.AddItem(collidingBody.gameObject);
                collidingBody.gameObject.transform.parent = transform;
                collidingBody.gameObject.transform.position = new Vector3(1000, 1000, 1000);
            }
        }
    }
    void hit()
    {
        if (Input.GetMouseButton(0) && collidingBody!=null && collidingBody.tag=="hitable")
        {
            applyForce(collidingBody);
        }
    }
    void applyForce(Rigidbody body)
    {
        Vector3 direction = body.transform.position - transform.position;
        direction = new Vector3(direction.x, 0, direction.z);
        body.AddForceAtPosition(30f * direction, transform.position, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        colliding = true;
        if (collision.gameObject.name!="Plane")
        {
            collidingBody = collision.gameObject.GetComponent<Rigidbody>();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        colliding = false;
    }
    public void turn()
    {
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime*Input.GetAxis("Horizontal"), Space.World);
    }
    void move()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 8f;
        }
        else
        {
            moveSpeed = 5f;
        }
        transform.Translate(new Vector3((-1)* Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime,0,0),Space.Self);
    }
    void jump2()
    {
        if (Input.GetKey(KeyCode.Space) && colliding)
        {
            body.velocity = new Vector3(0, 8f, 0);
        }
    }
    float jump()
    {
        if (Input.GetAxis("Jump")==1f && transform.position.y==groundLevel)
        {
            print("jump");
            jumpSpeed = 12f;
        }
        else if (transform.position.y<=groundLevel)
        {
            jumpSpeed = 0;
            transform.position = new Vector3(transform.position.x,groundLevel,transform.position.z);
        }
        else if (transform.position.y>groundLevel)
        {
            jumpSpeed -= gravity;
        }
        print(jumpSpeed);
        return jumpSpeed;
    }
}
