using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePanel : MonoBehaviour
{
    [SerializeField] private float flashStrength = 1f;
    [SerializeField] private float flashSpeed = 3f;
    private Renderer rend;
    private float alpha;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        alpha = 0f;
    }

    private void Update()
    {
        if(rend.material.color.a > 0f) {
            alpha -= flashSpeed * Time.deltaTime;
            rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, alpha);
        }

        if(alpha < 0f) {
            alpha = 0f;
            rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, alpha);
        }
    }

    public void Flash()
    {
        alpha = flashStrength;
        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, alpha);
    }
}
