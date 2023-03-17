using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//link the player to the death script and the animator


public class DEATHSCRIPT : MonoBehaviour
{
    public Animator An;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player" && An.GetInteger("deathbyfall") == 0)
        {
            An.SetInteger("deathbyfall", 1);
        }
    }
}