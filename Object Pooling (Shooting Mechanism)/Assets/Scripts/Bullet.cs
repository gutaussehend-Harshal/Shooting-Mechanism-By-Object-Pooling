using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   private Rigidbody rb;

   private void Awake() 
   {
       rb = gameObject.GetComponent<Rigidbody>();
   }

   private void FixedUpdate() 
   {
       rb.velocity = new Vector3(20f, 0f, 0f);
   }

   private void OnEnable()
   {
       StartCoroutine("DisableObject");
   }

   IEnumerator DisableObject() 
   {
       yield return new WaitForSeconds(1f);
       gameObject.SetActive(false);
   }

   private void OnDisable() 
   {
       StopCoroutine("DisableObject");
   }
}
