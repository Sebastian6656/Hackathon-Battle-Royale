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
    GameObject cube;
    Rigidbody cubeBody;
    bool thrown;
    // Start is called before the first frame update
    void Start()
    {
        cube=GameObject.Find("Cube");
        cubeBody=cube.GetComponent<Rigidbody>();
        thrown = false;
        moveSpeed = 5f;
        turnSpeed = 180f;
        gravity = 0.5f;
        groundLevel = transform.position.y;
        body= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!thrown)
        {
            print(cube.transform.localPosition);
            cube.transform.localPosition =new Vector3(-100,0,0);
        }
        move();
        turn();
        jump2();
        hit();
        if (Input.GetMouseButtonDown(0))
        {
            applyForce(cubeBody);
            thrown = true;
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
