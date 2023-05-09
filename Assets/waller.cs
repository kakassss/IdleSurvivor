using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag("Wall")) return;

        //Debug.Log("onur111 " + gameObject.name);
    }
}
