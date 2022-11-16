# 반복문 & 함수 예제 (Rokiss' Repetitive Statement Practice)

> 인프런 `Rookiss`님의 [<C#과 유니티로 만드는 MMORPG게임 개발 시리즈 Part1:C#기본문법>](https://inf.run/CJG3) 내용을 보고 공부목적으로 작성한 글 입니다.


- 전체적으로 이전에 풀었을 때보다 더 시간을 단축했다. 
	-  버전관리를 안하던 시기에 풀었던 것이라 코드 비교를 하기 힘들다...

### 구구단 출력하기
```cs
// Output multiplication table
for (int i = 2; i <= 9; i++)
{
	for (int j = 1; j <= 9; j++)
	{
		Console.WriteLine($"{i} * {j} = {i * j}");
	}
}
```
- 원하는 형태가 다음과 같으므로 
	- 2 * 1 =  2
	- 2 * 2 =  4
	- 2 * 3 =  6
	- ....
	- 9 * 7 = 63
	- 9 * 8 = 72
	- 9 * 9 = 81
- 왼쪽 n회 시행될때 마다, 오른쪽에서는 1~9까지 반복해서 곱해줘야 함  → 💡 이중for문이 필요하겠다!
- 각 시행마다 곱해주는 수 ➡️  for문 안 j 역할 
- 2단, 3단... 단을 표현해주는 것 ➡️ for문 i 역할 

#### [문자열 보간(String interpolation)](https://learn.microsoft.com/ko-kr/dotnet/csharp/tutorials/string-interpolation)
`Console.WriteLine($"{i} * {j} = {i * j}");`
</br>   
- 복합형식 지정(Composite Formatting) 방식처럼 전달인자를 달아주지 않아도 된다 
- **string 안에 직접 변수 이름을 집어 넣을 수 있다.**
- **"문자열" 앞에 달라(`$`)표기를 해주면 중괄호 안에 변수를 입력할 수 있다.**

- 조건부 삼항 연산자 
`bool isPair = (조건 ? 맞을때 : 틀릴때);`
</br>

```cs
int number = 25;

bool isPair;    // odd number, even number
isPair = ( (number % 2) == 0? true : false);
```

```cs
var rand = new Random();
for (int i = 0; i < 7; i++)
{
    Console.WriteLine($"Coin flip: {(rand.NextDouble() < 0.5 ? "heads" : "tails")}");
}
// output Example
Coin flip: tails
Coin flip: tails
Coin flip: heads
Coin flip: heads
Coin flip: heads
Coin flip: heads
Coin flip: tails
```

- 보간 문자열에서 중괄호 사용
```cs
$"public {prob.Type} {prob.Name} {{ get; private set; }}";
```
- 중괄호를 연이어서 작성 
</br>


### 직삼각형 모양으로 별 찍기 

```cs
// Make star points in a right triangle shape
for (int i = 0; i < 5; i++)                // row
{
	for (int j = 0; j <= i; j++)          // column
	{
		Console.Write("*");
	}
	Console.WriteLine();
}
```
- for문 한 개로는 `*` 을 쭈욱 늘어트려서만 출력됨 ➡️ Layer 를 늘려줘야 겠다
- 주어진 문제에서는 `*` 이 5개까지 즉 5행까지만 찍힘 ➡️ `i` 조건식은 0 ~ 4,  `i  < 5` , 5번만 시행
- `i` 가 n번 시행될 때, `j` 구문에서 `*` 을 찍어준다, 단 조건을 상수로 집어넣으면 계속 같은 개수가 찍히게 됨 ➡️ `j 조건식`은 `변수`로 표현되어야 한다!  ➡️  `j  <= i` (`<` 로 표현하면 첫번째 시행에서는 별을 안 찍어줌)

### Factorial Method 만들기 
- **반복문**으로 구현 
```cs
static int Factorial(int n)
{
	int sum = 1;
	for (int i = n; i > 0; i--)
	{
		sum = sum * i;
		// sum *= i;
	}
	return sum; 
}
- - -
int ret = Factorial(5);
Console.WriteLine(ret); 
```
5! = 5 * 4 * 3 * 2* 1 
4! = 4 * 3 * 2* 1
3! = 3 * 2* 1
2! = 2* 1
1! = 1 
- 💡 `n`을 입력 받으면 순서대로 반복해서 곱해줘야겠다 ➡️ for문 `i = n` 
- 값을 기억해줄 변수가 필요 ➡️ `sum` 
- sum 변수에 초기값은 1로 설정 (어떤수에 1을 곱하든 영향 없지만, 0을 곱해버리면 항상 0이니까)

최초 n = 5 일때 ,    sum =  1 * (i = 5)
다음 i--   sum =  (이전 sum = 5) * (i = 4)
.... 
</br>

- **재귀함수(Recursive function)** 방식
```cs
// Recursive function
static int Factorial(int n)
{
	if (n <= 1)
		return 1;
	return n * Factorial(n - 1);
}
- - -
int ret = Factorial(5);
Console.WriteLine(ret); 
```
- 자기 자신을 반복해서 호출
```cs 
n! = n * (n-1)!

5! = 5 * (4 * 3 * 2 * 1)
5! = 5 * 4! 
4! = 4 * 3!
3! = 3 * 2!
2! = 2 * 1!
1! = 1
```
- `return n * Factorial(n-1)`이 위 식과 비슷한 모양이 된다 
- 그러나 이렇게 그대로 실해하면 `stack overflow` 오류 발생 
- base statement를 컴퓨터에게 알려줘야함 
	- `f(1) = 1`  이라는 정보를 컴퓨터에게 전달해줘야 함 (여기서 막혔다...)
	- 조건문 `if (n <=1 )`문과 `return` 으로 n 값의 범위와  그때의 값을 지정해줌 
