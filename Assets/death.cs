using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : StateMachineBehaviour
{
    public Animator An;
    public GameObject player;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           An.SetFloat("deathbyfall", 1);
        }
    }
}

// Compare this snippet from script.cs:
//     using System.Collections;
//     using System.Collections.Generic;
//     using UnityEngine;
//

