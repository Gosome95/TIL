# TextRPG 만들기 in procedure-oriented program

> 인프런 `Rookiss`님의 [<C#과 유니티로 만드는 MMORPG게임 개발 시리즈 Part1:C#기본문법>](https://inf.run/CJG3) 내용을 보고 공부목적으로 작성한 글 입니다.

# TextRPG 만들기 메뉴얼 

## 게임 로비만들기 메뉴얼
- [ ] 최종 Goal : 직업(class) 선택할 수 있도록 로비화면을 설계하는 함수 만들기 
- [ ] 직업 범위 안에 있는 값이 아니면 재입력을 요구할 것 
- [ ] 직업 선택을 구현하는 부분은 하드코딩 하지 않도록 할 것 
	- [ ] [enum 형태로 설계](https://github.com/Gosome95/TIL/commit/c6edb37f0eb3d8f8c4b5fcb977585ef9d9b0af64) 
	- [ ] enum 변수명은 ClassType 
- [ ] 직업선택 함수 만들기 
	- [ ] 함수명은 ChooseClass()  
	- [ ] 함수 안 로컬변수 선언(변수명은 choice) 및 초기화를 진행해줄것. 
	- [ ] 함수에서 [직업 선택창] 띄워주기 
	- [ ] 사용자 입력을 받아 직업 선택 
	- [ ] switch 문으로 [ClassType] 정해주기 
	- [ ] 함수 안에서 사용된 로컬변수 choice를 외부로 알리는 코드 추가 
		- [ ] 간단하게는 함수의 반환타입 이용 (hint : enum ClassType)
		- [ ] ref, out 으로도 가능     
- [최종 구현 예시](https://github.com/Gosome95/TIL/commit/299122b723581233125b9c0bc7ce6ed8527d0e5a)

## 플레이어 생성하기 메뉴얼
- [ ] 최종 Goal : Player Character를 생성하는 함수 만들기 
	- [ ] 각 직업은 스텟(stat)을 갖고 있음. 최초 시작은 `{hp, attack}`
	- [ ] `CratePlayer 함수`를 호출하면 `{hp, attack}`이 각 직업에 맞게 채워지길 바람

- [ ] 직업 스텟은 구조체(struct) 형태로 포장 관리 
	- [ ] 구조체 명 = Player
	- [ ] 구조체 안 접근한정자 = public
- [ ] CreatePlayer함수 인수(Argument)와 매개변수(Parmeter) 결정
	- [ ] Main 함수 호출 시 
		- [ ] 첫번째 인수 = ClassType choice
		- [ ] 두번째 인수 = struct로 선언한 Player 
	- [ ] 함수 입력(input) 매개변수
		- [ ] 첫번재 인자 = ClassType choice
		- [ ] 두번째 인자 = struct로 선언한 Player 
```cs
// CreatePlayer Method
static void CreatePlayer(ClassType choice, out Player player)

// Main Method
Player player;
CreatePlayer(choice, out player);
	// choice 변수는 Main 함수에서 이전에 선언해주었음 
```
- [ ] Main 함수 
	- [ ]  `if(choice != Classtype.None)` 분기 이후, `CratePlayer 함수`를 호출하여 캐릭터 생성
	- [ ] 구조체 선언. 변수명 = player
	- [ ] 최종 로그를 찍어서 확인 
- [ ] Player Character 생성 함수 = CreatePlayer() 
	- [ ] switch 문을 사용해서 각 직업 스텟 정해주기 
		- 기사 hp 100, attack 10
		- 궁수 hp 75, attack 12
		- 법사 hp 50, attack 15
	- [ ] default 값 설정해주기    
- [구조체(struct) 없이 만든 코드](https://github.com/Gosome95/TIL/commit/b7e2f9b10a3305be5486464f42b0f6169114871e)
- [구현 예시 코드](https://github.com/Gosome95/TIL/commit/d2e3f679bf34696e816d6a02d0a71d69fb238f1b)  

</br>

- 설명 
- Main 함수에서 입력받은 `choice 변수` 정보를 `CreatePlayer() 함수`로 넘겨줘야 한다
-  함수 인자(매개변수)는 여러개일 수 있지만, 반환은 하나만 가능
- `ChooseClass()` 는 조작(처리)해야 될 값이 오직 ClassType choice; 하나 뿐이라 반환이 가능했음
- 이 경우에는 반환해야 할 값이 처음에는 { out int, out int attack } 이렇게 있고, 더 추가될 수 있으니까 구조체를 이용하여 반환하기 


## TextRPG 몬스터 생성 메뉴얼
--- 
- [ ]  게임 접속
- [ ]  `EnterGame()` 함수 만들기
    - [ ]  접속메세지 띄워주기 {마을에 접속했습니다}
    - [ ]  선택지 주기 { 필드로 가기, 로비로 돌아가서 다시 직업선택 }
    - [ ]  사용자 입력 받기
    - [ ]  잘 못된 값이 들어오면 다시 물어보기 (hint : `while`)
    - [ ]  {로비로 돌아가기}를 어떻게 구현할 수 있을까?
        - [ ]  간단하게는 return 사용
        - [ ]  아니면 `if else if`문으로 구현
        - 시작프로젝트 잘 못 설정해서 한참을 헤맸다…
- [ ]  마을이나 필드로 갈 수가 있음
- [ ]  `EnterField()` 함수 만들기
    - [ ]  안내메세지 띄워지기 { 필드에 접속했습니다 }
    - [ ]  CreateRandomMonster() 함수 만들기 
        - [ ]  위에서 만든 `캐릭터 생성`과 유사하다
        
        ```csharp
        Player player;
        CreatePlayer(choice, out player);
        /////
        Monster monster
        CreateRandomMonster(out Monster); 
        ```
        
        - [ ]  열거형 `enum MonsterType  { None, Slime, Orc, Skeleton}`
        - [ ]  구조체 `struct Monster { hp, attack}`
        - [ ]  랜덤으로 1~3 몬스터 중 하나를 리스폰
            - [ ]  랜덤값 설정
                - [ ]  `Random rand = new Random();`
                - [ ]  `rand.Next(1, 4);`         포함, 제외
            - [ ]  switch문 input에 해당하는 변수 선언 및 랜덤값으로 초기화
            - [ ]  `switch` 문 사용하여 MonsterType  할당 및 몬스터 스텟 정해주기
                - [ ]  enum 타입이라서 (int)로 `형변환` 필요
                - [ ]  슬라임 { 20, 2}  | 오크 { 40, 4}  |   스켈레톤 { 30. 3}
                - [ ]  기본값 주기
                - [ ]  **리스폰 안내 메세지 띄워주기**
    - [ ]  [1] 을 누르면 전투모드로 돌입
    - [ ]  [2]을 누르면 일정 확률로 마을로 도망

## TextRPG 전투 메뉴얼
- [ ]  `EnterField()`
    - [ ]  while 문으로 감싸주기
    - [ ]  [1] 전투모드 돌입 , [2] 일정확률로 마을로 도망 `안내메세지` 띄우기
    - [ ]  사용자 입력 받기 (string input)
    - [ ]  `if    else` 문으로 분기
        - [ ]  여기서 `Fight()` 함수 호출
        - 우리가 원하는 건 `player`, `monster` 가 서로 전투를 하는 것
        - 그럴려면 함수를 호출 할 때 `player`, `monster` 정보를 알고 있어야지 서로의 체력을 깎을 수 있다 → `함수 인수와 매개변수`
            - `monster`는 `EnterFiled` 함수 안에 존재   OK
            - [ ]  `player` 정보는 Main에서만 지금까지 관리되고 있었음 → 길을 뚫어주자
                - [ ]  Main 함수 - `Player player`   (원본)
                - [ ]  `EnterGame(ref Player player)`
                - [ ]  `EnterField(ref Player player)`
                - [ ]  `Fight(ref Player player, ref Monster monster)`
            - `ref` 키워를 붙여주지 않으면 계속 원본이 아니라 복사본을 갖고 작업을 한다. 그럼 정작 Main 함수 위치한 Player player 정보는 그대로임 
             그래서 `ref`로 원본 작업할거야라고 알려주자 
                
- [ ]  `Fight()` 함수
    - [ ]  while( )문으로 묶기  ← 이게 `한 턴`
    - [ ]  플레이어가 몬스터 공격
      `monster.hp  -= player.attack;`
    - [ ]  if 문으로 다시 분기
    - [ ]  `input = 1` 일때  → 전투모드
        - [ ]  남은 체력 보여주기
    - 힌트 코드
        ```csharp
        static void Fight(Player player, Monster monster)
        {
        	while(true)
        	{
        		//플레이어가 몬스터 공격
        		monster.hp -= player.attack;
        		if(monster.hp <= 0)
        		{
        			Console.WriteLine("승리했습니다");
        			Console.Writeine($"남은 체력 : {player.hp}");
        			break;
        		}
        		// 몬스터 반격 
        		player.hp -= monster.attack;
        		if(player.hp <=0)
        		{
        			Console.WriteLine("패배했습니다!");
        			break;
        		}
        	}
		}
        ```
        
    - [ ]  `input = 2` → 일정확률로 마을로 도망
        - [ ]  `Radom rand  = new Random();`
        `int randVlaue = rand.Next(0, 101);`  난수생성
        - [ ]  `if   else` 문으로 분기
		- [ ]  확률은 33%  (`randVlaue ≤ 33`)
- [ ]  코드 스타일 개선
    ```csharp
    - Main 함수 
    
    // 변경 전
    ClassType choice = ChoooseClass();
    if (choice != ClassType.None)
    {
    	// 캐릭터 생성
    	Player player;
    	CreatePlayer(choice, out player);
    
    	EnterGame(ref player);
    }
    
    // 변경 후  : 중괄호 중첩을 줄일 수 있음 
    ClassType choice = ChoooseClass();
    if (choice == ClassType.None)
    	continue;
    
	// 캐릭터 생성
	Player player;
	CreatePlayer(choice, out player);

	EnterGame(ref player);
    ```
### 헷갈렸던 부분 & 막힌부분
- 강의 직후 Manual 보면서 막혔던 부분 
	- 함수 내부에서 swich case 문 사용
	- `CreaterPlayer()` `default`를 써주지 않으면 왜 오류?

- [x] [`enum` 및 `struct` C# 기본문법 내용 추가](https://github.com/Gosome95/TIL/blob/main/CSharp/enum%26struct.md)
	- struct 사용 
	- 직업 포장할 때 `enum` 빨간 줄 표시 
		-  `;`  을 붙여주는줄 알았는데   `,`  였음 

</br>

- [ ]  `static void CreatePlayer(ClassType choice, out Player player)` 
        `CreatePlayer(choice, out player);`
    - [ ]  `choice`는 여기서 `ref`나 `out` 으로 넘겨주지 않던가?
    - 여기서 `choice`를 `ref` 나 `out` 으로 넘겨주지 않으면  **값 복사**가 일어남
    - 그럼 우리는 `원본`으로 작업하기를 바라는가?
    - `choice` 는 어차피  0, 1 ,2 , 3 같은 숫자(정수)가 입력되어 있고 우리가 함수 안에서 `switch`문에서 필요한 정보도 이 값만 있으면 됨. **실제 원본 데이터를 조작할 일은 없음** → 그럼 굳이 원본을 이용해서 작업할 필요는 없음
- [ ]  `CreateMonster` 에서 `out`  키워드 사용 하던가?
    - `Monster monster` 로 `구조체`를 이용했음
    - 구조체는 기본적으로 `값 형식` - 스택 할당.
    - 그런데 우리는 진짜 monster hp `원본`을 갖고 작업하기를 바람
        - 붙이지 않으면 처음에 호출하는 `EnterField()` 함수 안에서 선언된 `Monster monster` 사본으로 값을 넘기게 됨
        - `CreateMonster()` 함수는 전달받은 인수 `monster` 를 `복사`한 값을 매개변수로 이용하여 작업
        - 실제 CreateMonster함수를 호출한 위치인  `EnterField()` 에서 우리가 조작하는 `monster` 변수는 값이 그대로임
    - 그러니까 `out` 키워드 사용
- [ ]  `Fight` 함수 에서 매개변수 키워드  ref,  out??
    - `ref` 로 하면 안되나?
    - `EnterGame` 
      `EnterField`
      `Fight`
    - [x]  왜 다  `out` 이 아니라 `ref` 로 썼지? ➡️ [보충내용](https://github.com/Gosome95/TIL/blob/main/CSharp/Method_RefBook.md)
    - `out` 키워드를 사용하면 그 매개변수를 함수 안에서 반드시 사용해야함 
    `CS0177: 제어가 현재 메서드를 벗어나기 전에 ‘player’ out 매개 변수를 할당해야 합니다`
    - EnterGame, EnterField에서 **굳이** `player` 변수를 초기화까지 해줄 구간이 없음

--- 

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
- MMORPG, 무수히 많은 몬스터 객체 중 특정 ID의 몬스터를 관찰하고 싶을 때 ID조건을 디버깅해서 멈추어보는게 가능하다. ([상용게임에선 안 됨!](https://inflearn.com/questions/93750))

-   중단점(Breakpoint) 말고 Console.WriteLine() 으로 로그를 남기는 방법도 있음
    -   Unity에서는 주로 쓰이는 방법이긴 함
    -   프로그램을 있는 그대로 분석할 수 없고 프로그램이 커지면 커질 수록 부담이 될 수 있음
</br>

--- 

# TextRPG 만들기 in procedure-oriented program

## TextRPG1 - 직업 선택하기 
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
