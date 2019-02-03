using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item: MonoBehaviour
{

    public string name;
   public Sprite sprite;

    void OnTriggerEnter(Collider other)
    {
        movement.WalkedOverObject = this.gameObject;

    }
    void OnTriggerExit(Collider other)
    {
        if (movement.WalkedOverObject == this.gameObject) movement.WalkedOverObject = null;
    }
}

