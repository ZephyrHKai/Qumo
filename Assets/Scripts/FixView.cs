using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixView : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Player"))
        {
            Debug.Log("hit player");
            cam.transform.LookAt(target.transform);
        }
    }
}
