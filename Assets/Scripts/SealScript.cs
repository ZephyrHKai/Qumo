using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SealScript : MonoBehaviour
{
    //[SerializeField] PostProcessVolume MyVolume;
    //[SerializeField] PostProcessProfile Standard;
    //[SerializeField] PostProcessProfile NightVision;
    [SerializeField] GameObject SealObject;
    //[SerializeField] GameObject NightVisionOverlay;

    //public Light FlLight;

    

    void Start()
    {    
        SealObject.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       

    }
}
