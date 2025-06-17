using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingUI : MonoBehaviour
{
    [SerializeField] private float _distance = 1f;
    private Camera mainCamera;
    
    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        transform.position = mainCamera.transform.position + mainCamera.transform.forward * _distance;
        
        if (mainCamera != null)
        {
            //# 카메라를 바라보도록 회전
            transform.LookAt(mainCamera.transform);
            
            //# UI가 뒤집어지지 않도록 Y축 기준으로 180도 회전
            transform.Rotate(0, 180, 0);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}