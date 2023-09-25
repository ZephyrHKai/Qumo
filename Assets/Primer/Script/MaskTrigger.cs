using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskTrigger : MonoBehaviour
{   
    // Start is called before the first frame update

    [SerializeField] GameObject mask;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger");
        if (other.CompareTag("Player"))
        {
            mask.SetActive(true);
            mask.GetComponent<Animator>().Play("MaskFadeOut");
            Debug.Log("mask");
        }
    }

}
