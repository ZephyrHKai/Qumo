using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrainPower : MonoBehaviour
{
    [SerializeField] Image BrainUI;
    [SerializeField] float DrainTime;
    [SerializeField] float CurrentTime;
    public GameObject GameTimer;

    public bool PsychicVisionActive = false;

    // Update is called once per frame
    private void Start()
    {
        DrainTime = GameTimer.GetComponent<Failscene>().fullGameTime;
        CurrentTime = GameTimer.GetComponent<Failscene>().GameTime;
    }

    void Update()
    {
        DrainTime = GameTimer.GetComponent<Failscene>().fullGameTime;
        CurrentTime = GameTimer.GetComponent<Failscene>().GameTime;
        BrainUI.fillAmount = CurrentTime / DrainTime;
        /*
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (PsychicVisionActive == false)
            {
                BrainUI.fillAmount -=( 2.0f / DrainTime) * Time.deltaTime;
                PsychicVisionActive = true;

            }
            else
            {
                BrainUI.fillAmount -= (1.0f / DrainTime )* Time.deltaTime;
                PsychicVisionActive = false;

            }
        }
        */
       
    }
}
