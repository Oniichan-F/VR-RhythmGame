using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandbyAnchor : MonoBehaviour
{
    private PlayManager playManager;
    private StandbyAnchorChild childR, childL;
    private Transform meshR, meshL;
    private float timer;

    private void Start()
    {
        playManager = GameObject.Find("PlayManager").GetComponent<PlayManager>();
        childR = transform.GetChild(0).GetComponent<StandbyAnchorChild>();
        childL = transform.GetChild(1).GetComponent<StandbyAnchorChild>();
        meshR = childR.transform.Find("Mesh").transform;
        meshL = childL.transform.Find("Mesh").transform;
        timer = 0f;
    }

    private void Update()
    {
        if(childR.isStay) {
            meshR.Rotate(0, 0, 1, Space.World);
        }
        else {
            meshR.rotation = Quaternion.Euler(0f, 90f, 90f);
        }
        if(childL.isStay) {
            meshL.Rotate(0, 0, 1, Space.World);
        }
        else {
            meshL.rotation = Quaternion.Euler(0f, 90f, 90f);
        }

        if(childR.isStay && childL.isStay) {
            if(timer > 3f) {
                playManager.Play();
                Destroy(this.gameObject);
            }
            timer += Time.deltaTime;
        }
        else {
            timer = 0f;
        }
    }
}
