using Unity.XR.CoreUtils;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class WalkSound : MonoBehaviour
{
    [SerializeField] private float _stepInterval = 0.5f;
    private float _stepTimer = 0f;

    private Vector3 _previousPosition;

    private void Awake() => _previousPosition = transform.position;

    private void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 deltaPosition = currentPosition - _previousPosition;
        float estimatedSpeed = deltaPosition.magnitude / Time.deltaTime;
        
        if (estimatedSpeed > 0.1f)
        {
            _stepTimer -= Time.deltaTime;

            if (_stepTimer <= 0f)
            {
                PlayFootstepSound();
                _stepTimer = _stepInterval;
            }
        }
        else
        {
            _stepTimer = 0f;
        }
        _previousPosition = currentPosition;
    }

    private void PlayFootstepSound() => GameManager.Instance.Audio.PlaySFX(AudioClipName.WalkSound, transform.position);
}