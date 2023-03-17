using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObj : MonoBehaviour
{
   private object thisObject;
   private void Awake()
   {
      thisObject = GetComponent<object>();
   }
}
