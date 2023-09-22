using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.TextCore.Text;

public class CameraController : MonoBehaviour
{
    public PlayerController playerController;
    public Vector2 lastRotation;

    [SerializeField]
    private AxisState xAxis;
    [SerializeField]
    private AxisState yAxis;

    public Transform cameraLookAt;
    public CinemachineInputProvider inputProvider;

    public bool isInverse;

    // Start is called before the first frame update
    void Start()
    {
        xAxis.SetInputAxisProvider(0, inputProvider);
        yAxis.SetInputAxisProvider(1, inputProvider);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.isSelected)
        {
            xAxis.Value = lastRotation.x;
            yAxis.Value = lastRotation.y;
            return;
        }

        xAxis.Update(Time.deltaTime);
        yAxis.Update(Time.deltaTime);

        xAxis.m_InputAxisValue = Mathf.Clamp(xAxis.Value, -1, 1);
        yAxis.m_InputAxisValue = Mathf.Clamp(yAxis.Value, -1, 1);

        cameraLookAt.eulerAngles = new Vector3(yAxis.Value, xAxis.Value, isInverse?180:0);

        lastRotation = new Vector2(xAxis.Value, yAxis.Value);
    }
}
