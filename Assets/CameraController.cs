using System;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.TextCore.Text;

public class CameraController : MonoBehaviour
{
    public PlayerController playerController;
    public Transform cameraLookAt;

    public bool isInverse;
    public CinemachineInputProvider inputProvider;

    //Rotação atual do input da camera
    public Vector2 rotation = new Vector2(0,0);

    public float speed = 5;

    private void OnEnable()
    {
        UpdateRotation();
    }

    void Update()
    {
        if (!playerController.isSelected)
            return;

        UpdateRotation();
    }
    
    void UpdateRotation()
    {
        //O mouse movimentando no eixo X
        rotation.y += inputProvider.GetAxisValue(0) * speed;
        
        //O mouse movimentando no eixo Y
        rotation.x += (isInverse ? -1 : 1) * inputProvider.GetAxisValue(1) * speed;
        
        //Limitando -89 e 89
        rotation.x = Mathf.Clamp(rotation.x, -89f, 89f);

        //Aplica a rotacao na camera
        cameraLookAt.eulerAngles = new Vector3(rotation.x, rotation.y, isInverse ? 180:0);
    }
}
