using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandbyAnchor : MonoBehaviour
{
    private PlayManager playManager;
    private StandbyAnchorChild childR, childL;
    private Transform mesh;
    private float timer;

    private void Start()
    {
        playManager = GameObject.Find("PlayManager").GetComponent<PlayManager>();
        childR = transform.GetChild(0).GetComponent<StandbyAnchorChild>();
        childL = transform.GetChild(1).GetComponent<StandbyAnchorChild>();
        mesh = transform.GetChild(2).transform;
        timer = 0f;
    }

    private void Update()
    {
        if(childR.isStay && childL.isStay) {
            if(timer > 3f) {
                playManager.Play();
                Destroy(this.gameObject);
            }

            mesh.Rotate(1, 0, 0, Space.World);
            timer += Time.deltaTime;
        }
        else {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            timer = 0f;
        }
    }
}
