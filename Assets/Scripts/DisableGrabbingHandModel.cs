using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DisableGrabbingHandModel : MonoBehaviour
{
    [SerializeField] private GameObject _leftHandModel;
    [SerializeField] private GameObject _rightHandModel;
    private XRGrabInteractable _grabInteractable;

    private void Awake() => _grabInteractable = GetComponent<XRGrabInteractable>();

    private void OnEnable()
    {
        _grabInteractable.selectEntered.AddListener(HiderGrabbingHand);
        _grabInteractable.selectExited.AddListener(SHowGrabbingHand);
    }

    private void OnDisable()
    {
        _grabInteractable.selectEntered.RemoveListener(HiderGrabbingHand);
        _grabInteractable.selectExited.RemoveListener(SHowGrabbingHand);
    }

    private void HiderGrabbingHand(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("Left Hand")) _leftHandModel.SetActive(false);
        else if (args.interactorObject.transform.CompareTag("Right Hand")) _rightHandModel.SetActive(false);
    }

    private void SHowGrabbingHand(SelectExitEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("Left Hand")) _leftHandModel.SetActive(true);
        else if (args.interactorObject.transform.CompareTag("Right Hand")) _rightHandModel.SetActive(true);
    }
}