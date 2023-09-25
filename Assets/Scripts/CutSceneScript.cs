using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject CutSceneObject;
    // Start is called before the first frame update
    void Start()
    {
        Player.SetActive(true);
        CutSceneObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter");
            Player.SetActive(false);
            CutSceneObject.SetActive(true);
            Destroy(this);
        }
    }

}
