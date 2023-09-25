using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LightSettingsPlayer : MonoBehaviour
{
    [SerializeField] PostProcessVolume MyVolume;
    [SerializeField] PostProcessProfile Standard;
    [SerializeField] PostProcessProfile NightVision;
    [SerializeField] GameObject SealObject;
    //[SerializeField] GameObject NightVisionOverlay;

    //public Light FlLight;

    public  bool NightVisionActive = false;
    public List<GameObject> ghost_list; 
    private bool FlashlightActive = false;
    public GameObject timer;

    void Start()
    {
        //NightVisionOverlay.gameObject.SetActive(false);
        SealObject.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (NightVisionActive == false)
            {
                MyVolume.profile = NightVision;
                timer.GetComponent<Failscene>().timeSpeed = 2;
                SealObject.gameObject.SetActive(true);
                //NightVisionOverlay.gameObject.SetActive(true);

                foreach (GameObject g in ghost_list)
                {
                    g.SetActive(true);
                }
                NightVisionActive = true;

            }
            else
            {
                MyVolume.profile = Standard;
                timer.GetComponent<Failscene>().timeSpeed = 1;
                //NightVisionOverlay.gameObject.SetActive(false);
                SealObject.gameObject.SetActive(false);
                foreach (GameObject g in ghost_list)
                {
                    g.SetActive(false);
                }
                NightVisionActive = false;

            }
        }
    }
    
}
