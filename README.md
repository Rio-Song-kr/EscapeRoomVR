# 게임명 : Escape Room VR

## 게임 개요

- **게임 장르** : VR 퍼즐 / 방 탈출
- **목표** : 플레이어가 퍼즐을 풀고 오브젝트를 상호작용하여 단일 방에서 탈출
- **타깃 플랫폼** : Oculus Quest 2/3S(+ OpenXR 지원 VR)
- **세부 사항** : Assets/Documents 폴더 참고

## 컨벤션

### 코드 컨벤션

```cs

// 예시
public int PublicField;
public static int MyStaticField;
public const int k_MyConstant;

private int _myPrivate;
private static int _myPrivate;
private const int k_MyConstant;

protected int _myProtected;


```

### Git 컨벤션

| Type     | 내용                                                    |
| -------- | ------------------------------------------------------- |
| Feat     | 새로운 기능 추가, 기존의 기능을 요구 사항에 맞추어 수정 |
| Fix      | 기능에 대한 버그 수정                                   |
| Set      | 프로젝트, 기타 환경 설정 등                             |
| Chore    | 그 외 기타 수정                                         |
| Docs     | 문서(주석 수정)                                         |
| Refactor | 기능의 변화가 아닌 코드 리팩터링                        |
| Test     | 테스트 코드 추가/수정                                   |
