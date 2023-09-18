using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class P2Camera : MonoBehaviour
{
    [SerializeField]
    private AxisState xAxis;
    [SerializeField]
    private AxisState yAxis;

    public Transform cameraLookAt;
    public CinemachineInputProvider inputProvider;

    // Start is called before the first frame update
    void Start()
    {
        xAxis.SetInputAxisProvider(0, inputProvider);
        yAxis.SetInputAxisProvider(1, inputProvider);
    }

    // Update is called once per frame
    void Update()
    {
        xAxis.Update(Time.deltaTime);
        yAxis.Update(Time.deltaTime);

        xAxis.m_InputAxisValue = Mathf.Clamp(xAxis.Value, -1, 1);
        yAxis.m_InputAxisValue = Mathf.Clamp(yAxis.Value, -1, 1);

        cameraLookAt.eulerAngles = new Vector3(yAxis.Value, xAxis.Value, 180);
    }
}
