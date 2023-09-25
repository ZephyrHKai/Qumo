using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractManager : MonoBehaviour
{

    [SerializeField] Camera cam;
    public bool hasseal = false;
    public GameObject Jumpscare1;
    public AudioSource JPS;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 20f);

        if ( hit.collider != null && Input.GetMouseButtonDown(0))
        {
            if (hit.collider.tag == "chair")
            {
                if (hit.collider.gameObject.GetComponent<ChairManager>().isOn)
                {
                    hit.collider.gameObject.GetComponent<ChairManager>().myCandleFire.SetActive(false);
                    hit.collider.gameObject.GetComponent<ChairManager>().isOn = false;
                }
                else
                {
                    hit.collider.gameObject.GetComponent<ChairManager>().myCandleFire.SetActive(true);
                    hit.collider.gameObject.GetComponent<ChairManager>().isOn = true;
                }
            }
            
        }
        if (hit.collider != null && Input.GetKeyDown(KeyCode.E))
        {
            if (hit.collider.tag == "Seal") {
                hit.collider.gameObject.SetActive(false);
                Jumpscare1.SetActive(true);
                JPS.Play();
                //cam.transform.LookAt(Jumpscare1.transform.position);
                hasseal = true;
            }
            if (hit.collider.tag == "chair"&&hasseal) {
                hit.collider.gameObject.GetComponent<ChairManager>().isSealed = true;
                hit.collider.gameObject.GetComponent<ChairManager>().myseal.SetActive(true);
            }
           

        }

    }
}
