using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class DoorSoundController : MonoBehaviour
{
    //# 소리가 재생될 최소 각도
    [SerializeField] private float angleThreshold = 5f; 
    
    private HingeJoint _hingeJoint;
    private float _initialAngle;
    private bool _hasPlayedSound = false;


    void Start()
    {
        _hingeJoint = GetComponent<HingeJoint>();
        
        //# 초기 각도 저장 (Hinge Joint의 기준 각도)
        _initialAngle = _hingeJoint.angle;
    }

    void Update()
    {
        //# 현재 Hinge Joint의 각도
        float currentAngle = _hingeJoint.angle;

        //# 초기 각도와 현재 각도의 차이 계산
        float angleDifference = Mathf.Abs(currentAngle - _initialAngle);

        //# 각도 차이가 임계값을 초과하고 소리가 아직 재생되지 않은 경우
        if (angleDifference > angleThreshold && !_hasPlayedSound)
        {
            PlayDoorSound();
        }
        //# 문이 다시 닫히면 소리 재생 플래그 리셋 (선택 사항)
        else if (angleDifference < angleThreshold && _hasPlayedSound)
        {
            _hasPlayedSound = false;
            GameManager.Instance.Audio.PlaySFX(AudioClipName.ClosedDoorSound, transform.position);
        }
    }

    private void PlayDoorSound()
    {
        GameManager.Instance.Audio.PlaySFX(AudioClipName.DoorSound, transform.position);
        _hasPlayedSound = true;
    }
}