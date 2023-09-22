using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("REFERENCES")]
    public Transform cameraLookAt;
    private PlayerController _playerController;
    private CinemachineInputProvider _inputProvider;
    
    [Header("SETTINGS")]
    public bool isInverse;
    public float speed = 5;
    
    //Rotação atual do input da camera
    [Header("STATE")]
    public Vector2 rotation = new Vector2(0,0);

    private void OnEnable()
    {
        _playerController = GetComponent<PlayerController>();
        _inputProvider = GetComponent<CinemachineInputProvider>();
        UpdateRotation();
    }

    void Update()
    {
        if (!_playerController.isSelected)
            return;

        UpdateRotation();
    }
    
    void UpdateRotation()
    {
        //O mouse movimentando no eixo X
        rotation.y += _inputProvider.GetAxisValue(0) * speed;
        
        //O mouse movimentando no eixo Y
        rotation.x += (isInverse ? -1 : 1) * _inputProvider.GetAxisValue(1) * speed;
        
        //Limitando -89 e 89
        rotation.x = Mathf.Clamp(rotation.x, -89f, 89f);

        //Aplica a rotacao na camera
        cameraLookAt.eulerAngles = new Vector3(rotation.x, rotation.y, isInverse ? 180:0);
    }
}
