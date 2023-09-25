using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscare2 : MonoBehaviour
{
    public int count;
    public GameObject j1,j2,cam;

    public AudioSource JPS;// Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 2) {
            j1.SetActive(true);
            j2.SetActive(true);
            JPS.Play();
            count = 3;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            if (!cam.GetComponent<LightSettingsPlayer>().NightVisionActive) {
                count++;
            }
            
        }
    }
}
