# TextRPG 만들기 in procedure-oriented program

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
</br>

## TextRPG 만들기 in procedure-oriented program

### 1. 간단 구현
```csharp
namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // textRPG 직업 선택창 입력하기 
            while (true)
			{
	            Console.WriteLine("직업을 선택하세요!");
	            System.Console.WriteLine("[1] 기사");
	            Console.WriteLine("[2] 궁수"); 
	            Console.WriteLine("[3] 법사"); 
							
				string input = Console.ReadLine();
				if (input == "1" || input == "2" || input == "3")
					break; 
			}
        }
    }
}
```

### 2. enum 형태로 구현 
- `input` 을 받는 부분이 string 하드코딩한 거니까 `enum` 형태로 재설계 
- [code](https://github.com/Gosome95/TIL/commit/c6edb37f0eb3d8f8c4b5fcb977585ef9d9b0af64)
```cs
//Add enum
enum ClassType
{
	None = 0,
	Knight = 1,
	Archer = 2,
	Mage = 3
 }

static void Main(string[] args)
{
	ClassType choice = ClassType.None;
	while (true)
	{
		// Choose a class method
	}
}
```
- `enum` 열거형 
	- 내부적으로 `{0, 1, 2, 3}` 같은 `정수`
	- 그 숫자에 각각 이름을 붙인 개념  { `ClassType.None`, `ClassType.Knight`, ....}
</br>

- `ClassType choice = ClassType.None;` = 초기값을 넣어주는 것 
	choice가 없다는 것을 None으로 초기화 
	나중에 다른 값을 Player 입력을 받아 골라줌 
	<u>**값을 입력받지 않으면 여전히 None 상태니까 ➡️ 활용해서 예외처리** </u>
- enum 구현부 안에 숫자는 반드시 {0, 1, 2, 3}일 필요 없고 {10, 15, 20} 같은 다른 값도 가능 
- `enum ClsassType` 을 만들어주고  `Classtype choice;` 를 하면 `ClassType 타입의 변수`를 할당
- `ClassType`은 enum 타입이기 때문에 {0, 1, 2, 3} 4개의 값 중 하나를 골라서 사용하게 된다 
- `메모리` 상으로는 `일반 정수`이지만 C# 코드에선 "1" "2" "3" 같은 의미없는 하드코딩해서 넣는 것이 아니라 <u>**`ClassType.Knight` 와 같이 알아보기 쉬운 값을 사용**</u>할 수 있게 된다 


#### while 문 밖에 ClassType 을 선언하는 것과 while문 코드블럭 안에서 선언하는게 무엇이 다를까?

```cs
static void Main(string[] args)
{
	# ClassType choice = ClassType.None;
	while (true)
	{
		# ClassType choice = ClassType.None;
		// Choose a class method
	}
}
```
- `while` 문 안이면 변수 라이프가 중괄호(Code Block)까지 
- `while`문 밖에서 사용하고자 한다면 에러 발생 

- 그러나 **함수 안에서는 초기화 필!** 
	- <u>**변수를 사용하려면, 무조건 초기화를 한 변수여야 한다**</u> 가 `C#` 기본 룰 
	- 변수마다 기본 값이 정해져 있지만, 
	-  로컬 변수 (함수 내부에서 선언해서 사용하는 함수)는 기본 값으로 세팅이 되지 않는다 
	- while 문 안에서 ClassType choice, `기본값 = None` 으로 컴파일러가 자동 설정할 수 있지만
	  `ChooseClass()` 함수 내부에서는 `None`으로 선언해줘야 한다 

### 3. while 조건 변경 버전 
- [code](https://github.com/Gosome95/TIL/commit/a92b7a42b83bf1f3ba07105806a3af27a6508967)
```cs
while (true)
{

	if (choice != ClassType.None)
		break;
}
//////////////
while (choice == ClassType.None)
{

}
```

### 4. ChooseClass 함수로 따로 빼주기 
- [code](https://github.com/Gosome95/TIL/commit/299122b723581233125b9c0bc7ce6ed8527d0e5a)
- 보통 `기능`별로 함수로 묶어준다. 
- 많이 사용하는 기능도 코드 재사용을 위해 함수로 뺀다.
#### `choice`를 함수 내부에서도 선언해주고, 외부로 알리는 코드 필요
```cs
static ClassType ChooseClass()
{
/////////
ClassType choice = ClassType.None;
string input = Console.ReadLine();
//////////
return choice;
}

static void Main(string[] args)
{
	while (true)
	{
		ClassType choice = ChooseClass();
	}
}
```
- 인자가 하나밖에 없으니까 `반환타입(enum ClassType)`으로 돌려주기 
- `로컬변수 choice` 자체는 함수 내부에서만 유효
- 그러나 `반환타입` + `return` 은 이 값을 복사해달라고 요청 
- 이 반환한 값을 함수 외부에서도 사용 가능 
	- [Rokiss Q&A : 함수의 반환타입](https://inflearn.com/questions/411030)
	- 함수의 반환 타입을 설정해주면, 반드시 해당 타입으로 결과물을 return
	- `ChooseClass();` 함수를 호출하는 쪽에서는, 결과물을 받아올 수가 있다
</br>

- 이 경우, `ChooseClass()`는 결과물 반환을 위해 `ClassType`으로 `반환타입`을 만들었고 
- 함수의 결과물은 `ClassType choice` 변수 에다가 받아주고 있다 
	- 처음에는 직업이 없다가 (`choice = ClassType.None`)
	- `ChooseClass()` **호출**이 완료되면 결과물 반환 
	- `choice = ChooseClass()` 작업이 바뀐다 
	- [Rokiss Q&A](https://inflearn.com/questions/204273)
</br>
- [Rokiss Q&A : ClassType choice = 0 으로 하면 안되나요?](https://inflearn.com/questions/204041)
	- 코드 가독성을 따져주자 
