using System.Collections;
using System.Collections.Generic;
using General;
using Unity.VisualScripting;
using UnityEngine;

public class DevHubManager : MonoBehaviour
{
    public SongInfo songInfo;

    private void Start()
    {
        songInfo = new SongInfo(-100, -100);
    }
}
