using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Looper : MonoBehaviour
{
    [SerializeField] private bool isActive = false;
    [SerializeField] private float interval = 3f;
    [SerializeField] private int maxLoop = 10;

    // Edit Area ->
    [SerializeField] private GameObject interactivePanel;
    // Edit Area <-

    private int loopCount;
    private IEnumerator experimentalLoop;

    private void Start()
    {
        if(isActive) {
            loopCount = 0;
            experimentalLoop = ExperimentalLoopFunc();
            StartCoroutine(experimentalLoop);
        }
    }

    private IEnumerator ExperimentalLoopFunc()
    {
        while(true) {
            loopCount += 1;
            Debug.Log("Loop: " + loopCount);

            // Edit Area ->
            interactivePanel.GetComponent<InteractivePanel>().Flash();
            // Edit Area <-

            if(loopCount == maxLoop) {
                yield break;
            }

            yield return new WaitForSeconds(interval);
        }
    }
}
