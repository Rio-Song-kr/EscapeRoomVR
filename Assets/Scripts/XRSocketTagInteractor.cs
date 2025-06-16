using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRSocketTagInteractor : XRSocketInteractor
{
    [SerializeField] private string _targetTag;

    public override bool CanHover(IXRHoverInteractable interactable)
        => base.CanHover(interactable) && interactable.transform.CompareTag(_targetTag);

    public override bool CanSelect(IXRSelectInteractable interactable)
        => base.CanSelect(interactable) && interactable.transform.CompareTag(_targetTag);


    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        //# 종료 조건 추가
        Debug.Log("End");
    }
}
