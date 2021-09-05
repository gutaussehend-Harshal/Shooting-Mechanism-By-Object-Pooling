using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Material material;

    [Range(0, 30)]
    [SerializeField] private float moveSpeed = 5f;

    private void Start() 
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;

        // InvokeRepeating("GenerateBullets", 3f, 0.1f);
    }

    void Update() 
    {
        Movement();
        Shooting();
    }

    private void Movement() 
    {
        // transform.Translate(Vector3.forward * Time.deltaTime  * moveSpeed);
        transform.Translate(Vector3.up * Time.deltaTime * Input.GetAxisRaw("Vertical") * moveSpeed);
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxisRaw("Horizontal") * moveSpeed);
    }

    // private void GenerateBullets() 
    // {
    //     GameObject pooledObject = ObjectPool.sharedInstance.GetPooledObject();
    //     pooledObject.transform.position = transform.position;
    // }

    IEnumerator GenerateBullets() 
    {
        yield return new WaitForSeconds(0.1f);
        GameObject pooledObject = ObjectPool.sharedInstance.GetPooledObject();
        pooledObject.transform.position = transform.position;
    }

    private void Shooting() 
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            StartCoroutine(GenerateBullets());
        }
    }
}
