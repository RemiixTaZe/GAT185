using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        EventManager.Instance.Subscribe("StartSession", onGameSessionStart);
    }

    void onGameSessionStart()
    {
        Debug.Log("start");
    }
}
