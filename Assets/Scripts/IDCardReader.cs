using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDCardReader : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private int _hashIsOpen = Animator.StringToHash("IsOpen");

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ID Card"))
        {
            _animator.SetBool(_hashIsOpen, true);
            Destroy(other.gameObject);
        }
    }
}
