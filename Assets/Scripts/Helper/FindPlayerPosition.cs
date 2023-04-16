using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayerPosition : MonoBehaviour
{
    public static FindPlayerPosition Instance;

    [HideInInspector] public GameObject player;
    [SerializeField] string playerTag;
    private void Awake()
    {
        Instance = this;
        player = GameObject.FindGameObjectWithTag(playerTag);
    }
}
