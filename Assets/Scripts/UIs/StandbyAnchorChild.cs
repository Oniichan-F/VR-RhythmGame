using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandbyAnchorChild : MonoBehaviour
{
    [SerializeField] private string triggerTag;
    public bool isStay;

    private void Start()
    {
        isStay = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag(triggerTag)) {
            isStay = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag(triggerTag)) {
            isStay = false;
        }       
    }
}
