using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdjustButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        if(TryGetComponent(out button)) {
            button.onClick.AddListener(OnClickAdjustButton);
        }       
    }

    public void OnClickAdjustButton()
    {
        SceneManager.LoadScene("AdjustScene");
    }
}
