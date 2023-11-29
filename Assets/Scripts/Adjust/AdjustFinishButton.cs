using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AdjustFinishButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        if(TryGetComponent(out button)) {
            button.onClick.AddListener(OnClickAdjustFinishButton);
        }
    }

    public void OnClickAdjustFinishButton()
    {
        SceneManager.LoadScene("DevHub");
    }
}

