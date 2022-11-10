# 게임 UI/UX 기획 

---

### UI 생성 
- Hierachy view - UI - UI 종류선택 
- Canvas 하위에 생성 
    - Canvas Component = UI가 배치되고 랜더링되는 공백
    - Cavnas가 없는 상태에서 UI를 생성하면 자동생성 

### Canvas 설정 
- Render Mode 
    - `Screen Space - Overlay` : 카메라 하나를 사용, 겹쳐서 UI 사용
    - `Screen Space - Camera` : Render Camera추가 되어야 함, 실제 UI를 비추는 카메라
    - `World Space` : `Canvas`가 월드공간에 배치된다. 캔버스 스케일을 많이 조정해야 한다, 주로 `VR`환경에서 활용

- `Screen Space - Overlay`
    - 캔버스가 화면에 맞게 스케일 된 후에 Scene이나 Camera의 레퍼런스 없이 직접 랜더링 
    - 화면의 크기나 해상도가 변경되면 UI는 자동적으로 맞춤 스케일 
    ![Screen Space_Overlay](https://github.com/Gosome95/TIL/blob/main/Unity/Atents_Academy/img/ScreenSpace_Camera.png?raw=true)

- `Screen Space - Camera`
    - Canvas는 주어진 카메라 앞에서 어느 정도 거리에 있는 평면 객체에 그려진 것처럼 랜덜이
    - UI 화면 크기는 `카메라 절두체`내에 정확하게 맞게 조정 -> 항상 거리에 따라 다름
    - 화면에 크기나 행상도 또는 카메라 절두체가 변경되면 UI가 자동으로 조절 
    ![Screen Space_Camera](https://github.com/Gosome95/TIL/blob/main/Unity/Atents_Academy/img/ScreenSpace_Overlay.png?raw=true)

- `World Space`
    - UI를 정면의 평면 객체처럼 랜더링
    - 스크린 공간 모드와 달리 평면은 카메라를 향할 필요가 없으며 원하는대로 방향을 지정
    - Canvas의 크기는 `RectTransform`을 사용하여 설정할 수 있지만 화면 크기는 카메라의 시야각 및 거리에 따라 다름
    - 다른 정면 개체는 캔버스를 통과할 수 있음 
    ![World Space](https://github.com/Gosome95/TIL/blob/main/Unity/Atents_Academy/img/WorldSpace.png?raw=true)


### UI image 교체하기 
1. 갖고 오고 싶은 이미지를 `Working Directory`에 저장
2. 그림 교체를 위해 Editor 상 설정 변경 
3. Inspector - Image - Source Image - `UISprite`
    - Texture type = 어디에 사용할지에 따라서 다르게 적용
    - UI로 사용 -> Sprite(2D and UI)
    - Texture로 사용 -> Default
4. code ~ image Component 접근 
```cs
using UnityEngine.UI;

Image img; 
void Start() 
{
	img = GetComponent<Image>(); 
	img.sprite = Resources.Load<Sprite>("test");
    #image Component에서 sprite 프로퍼티에 그림파일 로드
} 
```
- 제일 많이 사용하는 이미지 형식 = `png` 

### 내 머리위를 따라다니는 HP UI를 추가하고 싶다 어떻게 하면 될까?
- Player Character = 3차원 공간에 위치 
- UI = Canvas 공간에 위치 = 화면 공간에 위치 
- 3차원에 위치한 캐릭터가 화면에 어디있는지 알면 해결! 
    - `월드공간 좌표계`를 `스크린 좌표계`로 변환

```csharp
using UnityEngine.UI;

public Image hp; 
void Start() 
{
	
}

void Update()
{
	# hp bar 위치조정 
	Vectro3 tmp = trasform.position;
	tmp.y += 2f;

	# 월드좌표를 스크린좌표로 변환 
	Vector3 screenPos = Camera.main.WorldToScreenPoint(tmp);  // 캐릭터의 좌표
	hp.transform.position = screenPos; // 스크린좌표를 hp bar에 적용
}
```
- inspector - image
    - Image Type - Filed
    - Fill Method - Horizontal
    - Fill Origin  - Left
    - Fill Amount - 조절

### 키보드 F1키를 눌렀을 경우 UI hp의 이미지를 변경 
```csharp
using UnityEngine.UI;

public Image hp; 
void Start() 
{
	
}

void Update()
{
	// hp bar 위치조정 
	Vectro3 tmp = trasform.position;
	tmp.y += 2f;

	// 월드좌표를 스크린좌표로 변환 
	Vector3 screenPos = Camera.main.WorldToScreenPoint(tmp);  // 캐릭터의 좌표
	hp.transform.position = screenPos; // 스크린좌표를 hp bar에 적용

	# 키보드 F1키를 눌렀을 경우 UI hp의 이미지를 변경 
	# 변경하는 이미지의 이름 Mp.png
	if(Input.GetKeyDown(KeyCode.F1))
	{
		hp.sprite = Resources.Load<Sprite>("Mp");
		// 자료형 Sprite
	}
}
```

### 키보드 F2키를 눌렀을 경우 Cube(Character)의 텍스처를 변경
```csharp
void Update()
{
	# 키보드 F2키를 눌렀을 경우 Cube(Character)의 텍스처를 변경
	# 변경하는 텍스처의 이름은 newCube.png
	if(Input.GetKeyDown(KeyCode.F2))
	{
		GetComponent<MeshRenderer>().material.mainTexture = Resource.Load<Texture2D>("newCube");
		// 자료형 Texture2D
	}
}
```

</br>
</br>

## 이론 더하기
### 엘버타 대학에서 수행한 UI 연구결과
- 일관성을 유지해야 한다 
- 단축키이의 기능을 지원해야 한다
- 만족할 만한 수준의 피드백을 지원해야 한다
- 미리 정의된 작업을 제공하는 인터페이스를 디자인해야 한다
- Player가 심각한 실수를 할 여지를 주지 말아야 한다
- 취소를 쉽게 행사할 수 있도록 해야 한다
- 제어권은 Player에게 있어야 한다
- Player의 단기 기억을 혹사 시키지 말아야 한다 = 게임을 공부시키지 않도록! 