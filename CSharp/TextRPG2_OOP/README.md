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