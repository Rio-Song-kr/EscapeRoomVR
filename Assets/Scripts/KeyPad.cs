using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPad : MonoBehaviour
{
    [SerializeField] private TMP_Text _numbers;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _password = "1234";
    private int _hashIsOpen = Animator.StringToHash("IsOpen");

    public void OnClearClicked() => ClearNumbers();

    public void OnEnterClicked() => CheckPassword();

    public void OnZeroClicked() => UpdateNumbers("0");
    public void OnOneClicked() => UpdateNumbers("1");
    public void OnTwoClicked() => UpdateNumbers("2");
    public void OnThreeClicked() => UpdateNumbers("3");
    public void OnFourClicked() => UpdateNumbers("4");
    public void OnFiveClicked() => UpdateNumbers("5");
    public void OnSixClicked() => UpdateNumbers("6");
    public void OnSevenClicked() => UpdateNumbers("7");
    public void OnEightClicked() => UpdateNumbers("8");
    public void OnNineClicked() => UpdateNumbers("9");

    private void UpdateNumbers(string number)
    {
        GameManager.Instance.Audio.PlaySFX(AudioClipName.KeypadSound, transform.position);
        if (_numbers.text.Length >= _password.Length) _numbers.text = "";

        _numbers.text += number;
    }

    private void ClearNumbers()
    {
        _numbers.text = "";
        GameManager.Instance.Audio.PlaySFX(AudioClipName.KeypadSound, transform.position);
    }

    private void CheckPassword()
    {
        GameManager.Instance.Audio.PlaySFX(AudioClipName.KeypadSound, transform.position);
        if (!_password.Equals(_numbers.text))
        {
            _numbers.text = "WRONG";
            return;
        }

        _numbers.text = "CORRECT";
        _animator.SetBool(_hashIsOpen, true);
        GameManager.Instance.Audio.PlaySFX(AudioClipName.RoomDoorSound, transform.position);
    }
}
