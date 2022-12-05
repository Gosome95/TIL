# TextRPG 만들기 OOP

> 인프런 `Rookiss`님의 [<C#과 유니티로 만드는 MMORPG게임 개발 시리즈 Part1:C#기본문법>](https://inf.run/CJG3) 내용을 보고 공부목적으로 작성한 글 입니다.

## TextRPG2 - Player 생성 
- [ ]  `Class` 분리하기
    - [ ]  `Plaeyr.cs`
    - [ ]  `Monster.cs`

### Player class
- [ ]  `enum` `PlayerType`   만들어주기
    - [ ]  `None`, `Knight`, `Archer`, `Mage`
- [ ]  **in the class Player**
    - [ ]  `protected` 로 `int hp`, `attack` 선언해주기
- [ ]  `Player`를 상속받는 Knight, Archer, Mage Class 만들어주기
    - [ ]  각각의 `생성자` 만들어주기
- [ ]  `PlayerType` 을 각각의 `직업 class`에 넣어주기
    - [ ]  부모 클래스 Player에서 `protected`로 `PlayerType` `type` 선언
    - [ ]  `Player`를 생성할 때는 무조건 `PlayerType`이 있도록 `인자` 설정 (인자 없는 버전을 차단)
    ** PlayerType이 없는 Player가 생성되면 Knight, Archer, Mage도 아니게 되니까
    - [ ]  부모클래스 `Player`에서 `PlayerType` `type` 버전을 받는 `생성자` 만들기
        - [ ]  보호수준은 `protected`
        
        ```csharp
        protected Player(PlayerType type)
        {
        this.type = type;
        }
        ```
        
    - [ ]  부모님 생성자를 사용하는 것으로 하기
        - [ ]  `public Knight() : base(PlayerType.Knight)    {        }`
- [ ]  외부에서 `hp`, `attack` 을 넣어주는 방식으로 설계
    - [ ]  `부모 클래스` `Player`에서 `SetInfo` 함수로 멤버변수 접근하는 함수 만들어주기
        
        ```csharp
        public void SetInfo(int hp, int attack)
        {
        	this.hp = hp;
        	this.attack = attack;
        }
        ```
        
    - [ ]  외부에서 접근하는 용도로 각 속성을 `Get 함수`로 만들어주기
        
        ```csharp
        public PlayerType GetPalyerType() { return type; } 
        public int GetHP() { return hp; } 
        public ing GetAttack() { return attack; } 
        public bool IsDead() { return hp ≤ 0; }
        public void OnDamaged(int damage) 
        {  
            hp -= damage;
            if (hp < 0 ) 
                hp = 0; 
        }
        ```        
- [ ]  부모 클래스 멤버 변수들에 기본값 넣어주기
- [ ]  `자식 클래스` 각 직업별로 능력치 넣어주기
    - [ ]  `SetInfo` 함수 사용
    `SerInfo(100, 10);`

## TextRPG2 - 몬스터 생성
### `Creature` `클래스`를 추가

- [ ]  `Player` 클래스와 `Monster` 클래스가 갖는 공통적인 기능과 속성을 관리 
  코드 재사용을 위해서

```csharp
protected int hp = 0;
protected int attack  = 0;

public void SetInfo(int hp, int attack)
{
    this.hp = hp;
    this.attack = attack;
}

public int GetHP() { return hp; }
public int GetAttack() { return attack; }
public bool IsDead() { return hp <= 0; }
public void OnDamaged(int damage)
{
    hp -= damage;
    if (hp < 0)
        hp = 0;
}
```

- [ ]  `Creature` 클래스가 `Player` 인지 `Monster`인지 알아야 하니까 `구조체` `enum` 추가

```csharp
public enum CreatureType
{
	None,
	Player = 1,
	Monster = 2
}
```

- [ ]  class `Creature` 에서 구조체 관련 함수 설정

```csharp
CreatureType type;

protected Creature(CreatureType type)
{
	this.type = type;
}
```

- [ ]  `Creature Type`을 `Get 함수`로 외부접근 할 수 있게 해주기
- [ ]  `상속` 해주기

```mermaid
graph TD
  Creature --> Player --> Knight
	Creature --> Monster
	Player --> Archer
	Player --> Mage
	Monster --> Slime
	Monster --> Orc
	Monster --> Skeleton
```

- [ ]  `Player` `생성자`에서 `base`키워드 설정하여 인자 설정하기

```csharp
protected Player(PlayerType type) : base(CreatureType.Player)
{
    this.type = type;
}
```

### `Mosnter` class 설계

- [ ]  `MosnterType` 구조체 설정
    
    ```csharp
    public enum MonsterType
    {
    	None = 0,
      Slime = 1,
      Orc = 2,
      Skeleton = 3
    }
    ```
    
- [ ]  `Monster` 클래스 내 구조체를 인자로 받는 `생성자` 설정
- [ ]  Player 클래스와 마찬가지로 `GetMonsterType` 설정
- [ ]  `Slime`, `Orc`, `Skeleton` 각각의 `클래스`를 만들어준다
    - [ ]  `생성자`도 추가
- [ ]  `SetInfo`로 수치를 적용해주자

### `Main` 에서 사용

```csharp
Player player = new Knight();
Monster monster = new Orc();
```

- [ ]  플레이어가 몬스터를 공격하는 코드 작성 후 디버깅

```csharp
int damage = player.GetAttack();
monster.OnDamaged(damage);
// player한테 맞았는지가 중요하다 하면 OnDamaged 함수 수정해서 크리처타입 넣어주기 
```

- [ ]  `객체지향`이니까 조립해서 다른 기능도 가능
    - [ ]  `PvP` 기능
    
    ```csharp
    Player player = new Knight();
    Monster monster = new Orc();
    
    Player player2 = new Archer(); 
    int damage = player.GetAttack();
    player2.OnDamaged(damage); 
    ```