using System.Numerics;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : NetworkBehaviour
{
public GameObject cameraHolder;
public UnityEngine.Vector3 offset;


public override void OnStartAuthority()
{
cameraHolder.SetActive(true);
}

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "GameScene")
        {
            cameraHolder.transform.position = transform.position + offset;
        }
    }
}
