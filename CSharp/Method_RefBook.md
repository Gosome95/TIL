# Method 문법책 보충 내용 

>  Book [Manami Kitamura: Unity Textbook 5th Edition](http://aladin.kr/p/jfZpf) </br> Book [박상현 : 이것이 C#이다](http://aladin.kr/p/YysOb)

--- 

### 왜 만들까 
- 코드 처리가 길어지면 읽기도 힘들고 디버그도 어려워 문제가 발생할 수 있다 
- 모아 둔 처리마다 이름을 붙여 각각을 블록으로 사용할 수 있는 메소드를 쓰면 편리하다

## 메소드 Method
- 길어진 처리(코드)를 의미가 있는 처리(코드) 블록으로 분해하고 이름을 붙이는 구조
- 이렇게 분해한 각 절차를 메소드(Method, 또는 함수) 라고 한다 
- 이 외에도 메소드에 값을 전달해서 계산하거나 계산 결과를 돌려받을 수 있도록 하는 역할도 한다 
	- [관련 내용 in my TIL](https://github.com/Gosome95/TIL/blob/main/CSharp/Method.md#%EB%84%A3%EC%9D%80-%EC%9E%85%EB%A0%A5%EA%B0%92%EC%97%90-%EB%94%B0%EB%9D%BC-%EC%B6%9C%EB%A0%A5%EC%9D%84-%EB%B0%9B%EC%95%84%EC%99%80%EC%95%BC-%ED%95%98%EB%8A%94-%EA%B2%BD%EC%9A%B0)

- 메소드는 매개변수(Parameter)와 반환 형식(Return Type)을 가진다 
- 메소드로 건네는 값 : `인수` 
- 메소드에서 돌려받는 값 : `반환값` 
- <u>**`인수`는 여러 개 건넬 수 있지만 `반환값`은 한 개로 정해져 있다**</u> 

### 용어 정리  
- `인수` = 함수를 호출할 때 건네주는 변수 `Argument` 
- 인자 = 함수에서 정의되어 사용하는 `(매개)변수 Parameter`
- `지역 변수`(Local Variable) : 코드 블록 안에서 선언되는 변수 
	자기가 태어난 동네(Local), 코드 블록 안에서만 사용되고 코드 블록이 종료될 때 소멸
- 전역 변수(Global Variable) : (C/C++) 프로그램의 어느 코드에서나 접근해서 사용할 수 있는 변수
	C#에서는 코드의 가독성을 해치고 오류를 낳는 원흉으로 지적되어 왔기에 지원하지 않음
- 반환 `return` 
	- 점프문의 한 종류. 
	- 메소드를 종결시키고 프로그램의 흐름을 호출자아게 돌려 준다 
	- 반환 형식이 `void`인 경우에도 `return`문을 사용할 수 있다 
- `필드`(Fiedl) = 클래스(`class`) 안에 선언된 변수들
- `멤버`(Memeber) = `필드`와 `메소드`, `프로퍼티`, `이벤트` 등 클래스(`class`) 내에 선언된 요소들 


## 메소드를 만드는 방법 
![](https://github.com/Gosome95/TIL/blob/main/images/MethodExample.png?raw=true)
- 호출자가 <u>**메소드를 호출**</u>하면서 `인수(Argument)`를 넘기면 
- 이 인수는 메소드의 <u>**`매개변수(Parameter)`에 입력**</u> 된다
- 호출을 받은 메소드는 매개변수를 이용하여 계산을 수행한 후 `결과`를 호출자에게 `반환(Return)`
</br>

- Method 작성 방법 
```cs 
한정자 반환형식 메소드명 (매개변수 목록, Parameter, ···)
{
	메소드 처리;
	return 반환값; 
}
```
- 메소드 호출 방법 
```cs
메소드명(인수, Argument, ···); 
```
- 반환 형식 : 호출자의 메소드로 반환하는 값의 데이터형 지정 
	- 값을 반환하지 않는 메소드 ➡️ `void` 
- 매개변수(인자) : 호출자의 메소드에서 받은 값 (Input)
	- 매개변수(인자)를 갖지 않는 메소드 ➡️ 메소드명 뒤 괄호 안을 공백

## 값에 의한 전달 (pass by value)
- 한 변수를 또 다른 변수에 할당하면 변수가 담고 있는 데이터만 복사 될 뿐이다 
- 메소드가 매개변수를 받아들일 때는 `데이터의 복사`가 이루어진다 
- <u>**데이터를 복사해서 매개변수에 넘김**</u> = `값에 의한 전달` 
![](https://github.com/Gosome95/TIL/blob/main/images/MethodExample2.png?raw=true)
- 메소드가 호출될 경우 `x`가 담고 있는 데이터 `3`은 매개변수 `a`로,
	`y`가 담고 있는 데이터 `4`는 매개변수 `b`로 `복사`가 이루어진다 
- a와 x는 완전히 별개의 메모리 공간을 사용
- <u>**a를 수정한다고 해도 x는 아무런 영향을 받지 않는다**</u> 

## 참조에 의한 전달 (pass by reference)
![](https://github.com/Gosome95/TIL/blob/main/images/MethodExample3.png?raw=true)
- `ref` 키워드 사용 
- 매개변수를 메소드에 `참조`로 전달 
- 매개변수가 메소드에 넘겨진 <u>**원본 변수를 직접 참조**</u> 
- 메소드 안에서 매개변수를 수정하면 이 매개변수가 참조하고 있는 <u>**원본 변수에 수정이 이루어진다**</u> 

## 출력 전용 매개변수 out
- 두 개 이상의 결과를 반환하는 특별한 메소드
```cs
void Divide( int a, int b, out int quotient, out int remainder )
{
	quotient = a / b;
	remainder = a % b;
}
//////////////
int a = 20;
int b = 3;
int c = 0;
int d = 0;
Divide(a, b, out c, out d);

Console.WritLine("Quotient : {0}, Remainder {1}, c, d");
```
- `out` 키워드 = 출력 전용 매개변수 
- `ref` 키워드를 이용해서 매개변수를 넘기는 경우 
	- 메소드가 해당 매개변수에 결과를 저장하지 않아도 컴파일러는 아무런 경고를 해주지 않는다 
- out 키워드 
	- 메소드가 해당 매개변수에 결과를 저장하지 않으면 컴파일러가 에러 메시지를 출력 
	- <u>**컴파일러가 메소드에서 그 변수를 할당할 것을 보장**</u> 
	- 컴파일러를 통해 결과를 할당하지 않는 버그가 만들어질 가능성을 제거할 수 있다 

- 출력 전용 매개변수는 메소드를 호출하기 전에 미리 선언할 필요도 없다
- 호출할 때 매개변수 목록 안에서 바로 선언 가능 
```cs
int a = 20;
int b = 3;
Divide(a, b, out int c, out int d);

Console.WritLine("Quotient : {0}, Remainder {1}, c, d");
```

## 메소드의 결과를 참조로 반환
- 메소드의 결과를 참조로 반환 = 참조 반환값 `ref return`
- ref 한정자를 이용해서 메소드를 선언하고, `return`문이 반환하는 변수 앞에도 `ref` 키워드를 명시
```cs
int SomeValue = 10;

public ref int SomeMethod()
{
	// 메소드 내용
	return ref SomeValue;
}

////////////////////////////////
// 메소드 호출 
int result = SomeMethod();    // 값으로 반환 

ref int result = ref SomeMethod();     // result = 참조 지역변수 
```
- 값으로 반환받고자 할 때는 평상시처럼 메소드를 호출 
- 호출자가 참자로 넘겨받고 싶다면
	- 결과를 담는 지역변수와 호출할 메소드의 이름 앞에 키워드 위치 
	- 참조 지역 변수(`ref local`)

