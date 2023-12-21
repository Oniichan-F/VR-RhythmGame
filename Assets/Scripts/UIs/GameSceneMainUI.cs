using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneMainUI : MonoBehaviour
{
    private GameObject readyPanel;

    private void Start()
    {
        readyPanel = transform.Find("ReadyPanel").gameObject;
    }

    public IEnumerator PanelCoroutine()
    {
        readyPanel.transform.Find("Text").gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        Destroy(readyPanel.gameObject);
    }
}
