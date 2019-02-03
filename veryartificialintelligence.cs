using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class veryartificialintelligence : MonoBehaviour
{
    float moveSpeed = 1.5f;
    float turnSpeed = 90f;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("woman");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.05f);
        transform.Rotate(0, 10f,0);
    }
}
