using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairManager : MonoBehaviour
{


    public int index;
    public GameObject myCandleFire;
    public GameObject Ghost;
    public GameObject indicator;

    public bool correct_candle_position = false;
    public bool isOn = false;

    public bool isGhost = false;
    

    public bool isRealGhost = false;

    public bool isSealed = false;

    public GameObject myseal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGhost) 
        {
            Ghost.SetActive(true);
        }


        // if (correct_candle_position)
        // {
        //     indicator.SetActive(true);
        // }
    }
}
