using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackSelectButton : MonoBehaviour
{
    [SerializeField] private string packName;
    private Button button;

    private void Start()
    {
        if(TryGetComponent(out button)) {
            button.onClick.AddListener(OnClickPackSelectButton);
        }
    }

    public void OnClickPackSelectButton()
    {
        Debug.Log(packName);
    }
}
