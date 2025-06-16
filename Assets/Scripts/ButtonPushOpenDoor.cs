using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPushOpenDoor : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private int _hashIsOpen = Animator.StringToHash("IsOpen");
    private XRSimpleInteractable _simpleInteractable;

    private void Awake() => _simpleInteractable = GetComponent<XRSimpleInteractable>();

    private void OnEnable() => _simpleInteractable.selectEntered.AddListener(x => OpenDoor());

    private void OpenDoor()
    {
        _animator.SetBool(_hashIsOpen, true);
    }
}