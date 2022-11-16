# TextRPG 만들기 in procedure oriented program

> 인프런 `Rookiss`님의 [<C#과 유니티로 만드는 MMORPG게임 개발 시리즈 Part1:C#기본문법>](https://inf.run/CJG3) 내용을 보고 공부목적으로 작성한 글 입니다.

## 디버깅 기초 
- [마이크로소프트 공식문서](https://learn.microsoft.com/ko-kr/visualstudio/debugger/what-is-debugging?view=vs-2022)
- [Mac용 Visual Studio를 사용하여 디버깅](https://learn.microsoft.com/ko-kr/visualstudio/mac/debugging?view=vsmac-2022)

![](https://github.com/Gosome95/TIL/blob/main/images/Debugging_MSExample.png?raw=true)
- `빨간점`은 일종의 '트랩'을 깔아두는 것 
- 코드가 이 지점에 도달하면, 바로 똭! 코드 실행을 멈추고 잡아버리는 개념
	- `빨간점을` 세팅한다고 바로 화살표가 나오는게 아니고, F5로 프로그램을 실행해서 '트랩'에 걸린 다음에서야 화살표가 나타나고 이를 조절할 수 있다 
- `화살표`는 코드의 실행 위치를 나타내며 이를 강제로 다른 위치로 보내버리면, 과거나 미래로 돌아갈 수 있다
- 호출스텍 : 여기까지 오게 된 경로 간접체험 
- 한 단계씩 코드 실행 (⌘F11) -> Line by line
- 프로시저 단위 실행 (⇧⌘O, F10) -> 함수(Method)단위 실행 

</br>   
#### 메소드 디버깅 호출 과정 ≒ 영화 \<Inception\>
- 현실 → 1차 꿈 → 2차 꿈 → 3차 꿈
- depth가 늘어남. 꿈의 여러가지 깊이(depth)
- 함수가 여러 개 있을 때 디버깅 단계 실행하면 인셉션에서 꿈에 들어가듯이 한 레이어(Layer)로 들어갈 수 있다 
</br> 

- 조건을 걸어서 디버깅도 가능 
	- value = 30 일때만, Breakpoint 
```csharp
static void Print(int value)
{
	Console.WrilteLine(value);
}

static void AddAndPrint(int a, int b)
{
	int ret = a + b;
	Print(ret);
	return ret;
}

static void Main(string[] args)
{
	int ret = Program.AddAndPrint(4, 10);
	Program.AddAndPrint(5, 15); 
	Program.AddAndPrint(6, 17; 
	Program.AddAndPrint(3, 11); 
	Program.AddAndPrint(12, 31); 
	Program.AddAndPrint(10, 20); // 이때만 Breakpoint
}
```
- MMORPG, 무수히 많은 몬스터 객체 중 특정 ID의 몬스터를 관찰하고 싶을 때 ID조건을 디버깅해서 멈추어보는게 가능하다. ([상용게임에선 안 됨!]([https://inflearn.com/questions/93750](https://inflearn.com/questions/93750)))

-   중단점(Breakpoint) 말고 Console.WriteLine() 으로 로그를 남기는 방법도 있음
    -   Unity에서는 주로 쓰이는 방법이긴 함
    -   프로그램을 있는 그대로 분석할 수 없고 프로그램이 커지면 커질 수록 부담이 될 수 있음