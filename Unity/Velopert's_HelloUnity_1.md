## Velopert's Hello Unity_1

> Velopert님 <Unity 삽질> Youtube 영상을 보고 작성해보는 TIL 
 [Velopert 1. Hello Unity](https://youtu.be/_w14ir-ImwU)
 [Unity 삽질 (i) 중력, 1인칭, 충돌, 점프](https://youtu.be/ivuuY3GZrUY)


## What I Learned 
- [ ] 더 찾아볼만한 내용 
    - Input.GetAxis("Horizontal")
    - Input.GetAxis("vertical")

## What I watched 

### 기능구현
1. 기초공부 ~ 움직이는 캐릭터 만들기
2. 1인칭으로 움직이기 

### 1. Input : 방향키로 캐릭터 움직이기 

```cs
[SerializedField] 
float moveSpeed = 10.0f;

void Update()
{
	// transform.Translate( );
	// 특정위치로 움직여라가 아니라 입력받은 값만큼 움직여라 

	// 속도조정 = delta time 
	// 한 프레임에서 다음프레임으로 넘어가는데 걸리는 시간
	// 델타타입을 곱하면 클라이언트 fps가 30 프레임일때랑 200프레임 일때 모두 같은 속도로 움직이게 된다 

    // 방향키로 움직이기 
    float x = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
    float y = 0; 
    float z = Input.GetAxis("vertical") * Time.deltaTime * moveSpeed;
    transform.Translate(x, y, z); 
```


### 2. 1인칭으로 움직이기 
