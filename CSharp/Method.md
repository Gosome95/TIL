# 함수 Method
> 인프런 `Rookiss`님의 [<C#과 유니티로 만드는 MMORPG게임 개발 시리즈 Part1:C#기본문법>](https://inf.run/CJG3) 내용을 보고 공부목적으로 작성한 글 입니다.

- C# 메서드(Method) 
- C++ 함수(Functhion) 
- 또는 프로시저(Procedure)

## Quick Summary
- 돌려받을 값도 없고, 넣을 값도 없다 ➡️ 반환형식 = void 타입
-  **Input을 받을 때 ref 나 out 을 붙이면 -> 값을 복사하는게 아니라 '실제 그 변수'를 넘기겠다** 
- ref의 경우 [함수 외부] <-> [함수 내부] 양방향으로 통신하기 위해서 데이터 참조를 주고 받는 개념
  [함수 내부/외부 사이에서 데이터를 빠르게 넘겨주기 위해 사용할 것이냐]
- out의 경우 [함수 내부]에서 작업한 최종 결과물을 [함수 외부] 쪽으로 넘겨주는 일방적 통행
  [그저 최종 데이터를 함수 외부로 넘겨주기 위한 용도로 사용할 것이냐]
  - ref와 달리 [result1, result2]가 함수 내에서 사용되어야 함 
- 반환(return)값은 int, float 같은 기본 데이터타입이 될 수 있고,
  사용자가 정의한 클래스 타입이 될 수도 있다 
</br>

- `AddOne` = Input 할 때부터 ref 키워드 추가 
- `AddOne2` = int로 넘겨주고 반환 
	- **int a= 1; 이라는 [1]값을 복사해서 retrun 으로 값을 반환** 
- 일반적으로는 return으로 값을 반환하지만, <u>swap은 원본 그대로 사용 </u>
- 오버로딩 (함수이름의 재사용)
	- 매개변수 개수 
	- 매개변수 타입
	- 선택적 매개변수 

---

### 사용 이유 
- 코드를 기능별로 묶어서 사용할 필요가 있기 때문 
- 어떤 기능들의 묶음 
- 수학) 어떤 입력을 넣었을 때 `출력`을 뱉어주는 것 

## 문법   
```cs
한정자 반환형식 이름 (매개변수 목록)  {   }
static void HelloWorld() {   }
```
![](https://github.com/Gosome95/TIL/blob/main/images/Method_return.png?raw=true)

### 돌려받을 값도 없고, 넣을 값도 없다 ➡️ 반환형식 = void 타입 

```cs
// 함수 정의 
static void HelloWworld()
{
    Console.WriteLine("Hello World");
}

public static void Main(string[] args)
{
   // 함수 사용(호출)
    HelloWorld(); 
    MainClass.HelloWorld(); 
}
```
"딱히 뭔가를 넣어주고/반환하는 함수는 아니다" 는 의미
여기서 void는 '없다'

### 넣은 입력값에 따라 출력을 받아와야 하는 경우 
```csharp
static int Add(int a, int b)
{
    return a + b; 
}

public static void Main(string[] args)
{
    int result = MainClass.ADD(4, 5);
    Console.WriteLine(result);
}
```
덧셈 함수는 "정수 a, b를 알려줄테니, 그 두 숫자의 합이 무엇인지 알려줘"라는 기능을 수행하는 기계이기 때문에,
인자로 int a, int b를 받고 결과물도 int (정수의 합은 정수겠죠)로 지정

- 덧셈함수 
    - `한정자` `반환형식` `함수이름` `(매개변수 목록)`
    - **입력** = int형 변수 두 개 
    - **출력** = int 
    - **연산** = 중괄호(`코드블럭`) 부분 
    - **반환** = `return`

#### 함수 사용 
- <U>**동일한 class**</U> 내라면 <U>`MainClass.`</U> 부분을 생락 가능
- <U>**다른 클래스**</U>에서 해당 기능을 사용하려면 <U>`MainClass.Add()`</U>를 넣어주면 됨 
- 반환 형식 넘길 게 없으면 void 
    - `void Add(int num);` 형태라면
    - 반환 형식 = void 
    - Input은 받을 수 있지만 Output은 반환할 수 없다 

### 값 복사, 참조    
```csharp
class Program 
{
    static int AddOne(int number)
    {
        number = number + 1; 
    }

    public static void Main(string[] args)
    {
        int a = 0; 
        Program.AddOne(a);
        
        Console.WriteLine(a); 
    }
}
```
- 예상 결과 = 1, *실제 결과* = 0 
- **`Program.AddOne(a)`**
    - `a` = 인자(매개변수)
    - 입력 값을 `복사` 또는 `참조` 형태로 넘길 수 있음 
    - **기본형식 = `복사`타입** 
- `a`를 넘기는 게 아니라 `a`가 들고 있는 값 `0`을 넘긴다 
- 함수 부분에서 [0 + 1] 연산은 들어가지만
 <U>**실제 `a`메모리는 변화가 없다**</U> 

- 복사 = 짝퉁
- 참조 = 진퉁(원본)

#### `ref` = 값 복사 말고 진퉁(원본)! 
- ref = Reference 
- `참조값`으로 실제 a의 메모리를 가져와줌 
```cs
static int AddOne(ref int number)
- - -
Program.AddOne(ref a); 
```
- 그냥 `int`값이 아니라 `int`값을 참조하는 변수로 넘겨준다 
- 안붙이면 그냥 복사된 a, 함수 밖에서 선언된 실제 a는 변하지 않음 
- **<u>ref, out ~ a의 주소값을 넘겨주어 `변수` 그 자체를 연산에 사용</u>**


#### void AddOne()과 int AddOne() 차이 
- 입력을 받을 때부터 `ref`로 원본 작업 -> `void AddOne()`
- 함수 선언부터 `int`로 반환타입을 받아서 작업 -> `int AddOne2()` 
```csharp
class Program 
{
	static void AddOne(ref int number)
	{
		number = number + 1; 
	}
	
	static int AddOne2(int number)
	{
		retrun number + 1; 
	}
	
	public static void Main(string[] args)
	{
		int a = 0; 
		Program.AddOne(ref a);
		Console.WriteLine(a);
		 
		a = Program.AddOne2(a);            
		Console.WriteLine(a); 
        }
    }
}
```
- `AddOne` = Input 할 때부터 ref 키워드 추가 
- `AddOne2` = int로 넘겨주고 반환 
	- **int a= 1; 이라는 [1]값을 복사해서 retrun 으로 값을 반환** 
- <u>**결과는 같아도 디자인적으로 두번째 방식이 더 좋다!** </u>
	- AddOne + ref 버전은 항상 원본으로 사용함
	  결과만 확인하고 싶은 테스트 용으로 사용하기 곤란함 
	- AddOne2 버전은 값을 안 바꾸고 저장하는 용도로도 사용 가능! 
<U></U>

#### Swap 
- 일반적으로는 return으로 값을 반환 하지만, <u>swap은 원본 그대로 사용 </u>
```cs
// 반환타입 void 
static void Swap (ref int a, ref int b)
{
	int temp = a; 
	a = b;
	b = temp;        // b값 = temp = a 원본 
}

// 반환타입 int 
static int Swap (ref int a, ref int b)
{
	int temp = a; 
	a = b;
	b = temp;
	return 0; 
}

static void Main(string[] args)
{
	int num1 = 101;
	int num2 = 202; 
	Program.Swap(ref num1, ref num2); 
	Console.WriteLine(num1); 
	Console.WriteLine(num2); 
}
```
- 곧바로 대입하면 값이 바뀜! 
  그래서 `임시저장 변수`로 원본저장 
- 반환타입 `void Swap()`
	- Swap(ref int a, ref int b)의 경우 `인자`로 넘겨준 `a`, `b`의 값을 직접 고칩니다.
	- 따라서 Swap이 완료될 때 특별히 반환할 값이 없으므로 void이 타당하지만,
	- 그렇다고 int 형식을 반환한다고 특별히 문제가 되진 않습니다.
	- 대신 `return 0` 추가 
	- 반환형식이 int인데 아무것도 반환하지 않으면 에러가 나기 때문에, 큰 의미 없는 `retur 0` 추가

####  `out`키워드 사용 
- `ref` 키워드만 사용하면 함수 내부에서 값 사용을 하지 않아도 함수가 작동되는 문법적 문제가 있음 
	- `static void AddOne(ref int number) {  }`
	- 실제로 어떤 값을 반환해주긴 해야하는데, 아무것도 안 함 
- `out` 
	- 참조를 한다 = 원본으로 작업을 한다 
	- ref와 달리 [result1, result2]가 함수 내에서 사용되어야 함 
```csharp
// 값을 여러개 반환해야하는 경우 [참조타입] 사용은 out  
static void Divide(int a, int b, out int result1, out int result2)
{
	result1 = a/b; 
	result2 = a % b;  
}

static void Main(string[] args)
{  
	int num3 = 10;
	int num4 = 3; 

	int result1;
	int result2; 
	Divide(10, 3, out result1, out result2);
		 // 입력인자  |    값을 받아오는 값 

	Console.WriteLine(result1);
	Console.WriteLine(result2);
}
```



##  One Step Farther 

### return 및 ref 와 out 개념 추가 

#### return 
[함수의 반환타입 Rokiss Q&A](https://inflearn.com/questions/411030)
[retrun searching 내용](https://smoothiecoding.kr/return-type-csharp-basics/)
-  return 문은 메소드를 종료하고 호출자에게 복귀하는게 목적이지만 동작은 break나 continue 같은 점프문(jump statement)에 속합니다.
- 메소드의 실행이 끝나면 둘 중 하나입니다. 뭔가 값을 돌려주거나 아니면 그냥 호출자에게 복귀하는 것 입니다.
- 메소드 안에서 return 을 만나면 호출자에게 복귀하는데 값은 리턴 타입에 따라 결정됩니다.
- 반환값은 int, float 같은 기본 데이터형이 될 수 있고 사용자가 정의한 클래스 타입이 될 수 있습니다.
- 리턴 타입에서 중요한 것은 타입을 일치시키는 부분입니다. 

#### [ref 와 out](https://www.inflearn.com/questions/30171) 
- **Input을 받을 때 ref 나 out 을 붙이면 -> 값을 복사하는게 아니라 '실제 그 변수'를 넘기겠다** 
- C#에서 ref를 붙이면 동작은 포인터와 유사하지만, 변수 사용 방법은 일반 (비참조형)타입과 같다 
  내부적으로는 주소값을 이용하는 포인터 형태와 동일하게 동작하여 원본에 접근하지만
  C포인터 같은 복잡한 문법이 불필요해짐 
</br>

- 기능적으로나 성능적으로나 `ref` vs `out`은 별다른 차이가 없고, 내부적으로 주소를 참조해서 데이터를 다루게 됩니다. (C++의 포인터와 유사)
- ref의 경우 <u>**[함수 외부] <-> [함수 내부] 양방향으로 통신**</u>하기 위해서 데이터 참조를 주고 받는 개념
  [함수 내부/외부 사이에서 데이터를 빠르게 넘겨주기 위해 사용할 것이냐]
- out의 경우<u>**[함수 내부]에서 작업한 최종 결과물을 [함수 외부] 쪽으로 넘겨주는 일방 통행**</u>
  [그저 최종 데이터를 함수 외부로 넘겨주기 위한 용도로 사용할 것이냐]
</br>

- 결과적으로 ref를 사용할 때는 [함수 외부]에서 데이터를 설정하지 않으면 에러가 나고,
  out의 경우 [함수 내부]에서 데이터를 설정하지 않으면 에러가 납니다.
- 추가로 ref를 사용할 때는 [함수 내부]에서 [함수 외부]로부터 전달받은 값을 읽거나 덮어쓰는 행동이 다 가능하지만,
- out을 사용할 때는 <U>**<결과물을 넘겨주는 용도>**</U>로 사용하기 때문에[함수 외부]에서 무슨 값을 넘겨줬는지 읽는 용도로는 사용이  안됩니다.
  즉 애당초 함수 내부에서 외부로 값을 반환하는 용도로 사용하는 것이지 out 값에 어떤 값을 전달해줄 것이라고 기대하진 않습니다.
  
- **대부분의 경우 반환형식을 int로 하는 쪽이 훨씬 좋습니다. (성능적 이슈보다는, 함수 사용 인터페이스 차원에서)**

</br>

- `Main` 함수  ➡️ `AddOne` 함수 
- Main 함수에서 AddOne 함수로 값(인자)를 넘기는 방법 
    - 입력 값(`Input`)을 통해서 
    - `int`, `float`, `struct` 등은 `복사 타입` 
	    인자로 넘어갈 때 값이 복사되어 넘어감 
	    복사된 값을 수정해봤자, 원본에는 영향을 미치지 않는다 
	- `ref` 키워드 추가시 -> 실제 그 변수를 넘기겠다 (`참조 타입`)

- `Main` 함수 ⬅️ `AddOne` 함수
- AddOne 함수 내부에서 Main 함수로 값을 넘기는 방법 
	- 일반적인 방법 = return 값 (반환 값)
	- 함수 내부에서 return 형태로 함수를 호출한 쪽으로 반환해서 전달할 수 있음 
	- `Input` 값이 ref, out 키워드 추가된 `참조타입`이라면, 
	  함수 내부적으로 해당 `변수의 주소값`을 념겨서 원본을 대상으로 연산하게끔 강제해준다 
	- 그러면 Output을 뱉어주지 않더라도, Input을 통해서 받아준 변수를 수정하기만 해도
	  **실제 함수 밖에 있는 변수가 수정되는 효과를 얻을 수 있다** 
	- `class`는 참조 타입이라, `ref` 없이도 자체적으로 원본을 대상으로 연산 
</br>

## 오버로딩
```csharp
static int Add(int a, int b)
{
	Console.WriteLine(”Add int 호출”);
	return a + b;
}

static int Add(float b, float a)
{
	Console.WriteLine(”Add float 호출”);
	return a + b;
}

// 선택적 매개변수 
static int Add(int a, int b, int c = 0, float d = 1.0f, double e = 3.0)
{
	return a + b + c + d + e; 
}
static void Main(string[] args)
{
	Program.Add(1, 2, 3, 2.0f, 4.0);    // 순서 맞추어주기 
	Program.Add(1, 2, d:2.0f);          // C#은 좀더 편하게 선택적으로 가능! 

}
```
- 함수 이름의 재사용 
- 매개변수 형식을 달리하거나, 개수를 다르게 할 때 유용한 기능 
- 같은 이름을 쓸거면 ➡️ 매개변수, 타입이 달라야 한다 
	- 함수 이름
	- 매개변수 개수 
	- 매겨변수 타입 
	- **주의** 반환형식 및 매개변수명은 오버로딩에 영향을 주지 않음 


