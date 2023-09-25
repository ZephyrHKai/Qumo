using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flameChange : MonoBehaviour
{
    public float intensity;
    public float range = 43.72f;
    public float T;
    public Light l;// Start is called before the first frame update
    void Start()
    {
        l = GetComponent<Light>();
        
    }

    // Update is called once per frame
    void Update()
    {
      
       
        
    }
}
