using System.Collections;
using System.Collections.Generic;
using SFramework;
using UnityEngine;

public class MonoTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameLoop.Instance.sceneController.SetScene(SceneState.RoomScene);
    }
}
