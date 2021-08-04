™

|D:\Avanade-Treinamento\Avanade-SubTCSE-Projeto\src\Avanade.SubTCSE.Projeto.Application\AutoMapperConfigs\Profiles\Configs.cs
	namespace 	
Avanade
 
. 
SubTCSE 
. 
Projeto !
.! "
Application" -
.- .
AutoMapperConfigs. ?
.? @
Profiles@ H
{ 
public 

static 
class 
Configs 
{ 
public 
static 

AutoMapper  
.  !
MapperConfiguration! 4
RegisterMappings5 E
(E F
)F G
=>H J
new		 

AutoMapper		 
.		 
MapperConfiguration		 .
(		. /
cfg		/ 2
=>		3 5
{

 
cfg 
.  
AllowNullCollections (
=) *
true+ /
;/ 0
cfg 
. 

AddProfile 
< 
EmployeeRoleProfile 2
>2 3
(3 4
)4 5
;5 6
cfg 
. 

AddProfile 
< 
EmployeeProfile .
>. /
(/ 0
)0 1
;1 2
} 
) 
; 
} 
} ≠
ïD:\Avanade-Treinamento\Avanade-SubTCSE-Projeto\src\Avanade.SubTCSE.Projeto.Application\AutoMapperConfigs\Profiles\EmployeeRole\EmployeeRoleProfile.cs
	namespace 	
Avanade
 
. 
SubTCSE 
. 
Projeto !
.! "
Application" -
.- .
AutoMapperConfigs. ?
.? @
Profiles@ H
.H I
EmployeeRoleI U
{ 
public 

class 
EmployeeRoleProfile $
:% &
Profile' .
{ 
public 
EmployeeRoleProfile "
(" #
)# $
{ 	
	CreateMap		 
<		 
Dtos		 
.		 
EmployeeRole		 '
.		' (
EmployeeRoleDto		( 7
,		7 8
Domain		9 ?
.		? @

Aggregates		@ J
.		J K
EmployeeRole		K W
.		W X
Entities		X `
.		` a
EmployeeRole		a m
>		m n
(		n o
)		o p
.

 
ForCtorParam

 
(

 
$str

 (
,

( )
opt

* -
=>

. 0
opt

1 4
.

4 5
MapFrom

5 <
(

< =
src

= @
=>

A C
src

D G
.

G H
Cargo

H M
)

M N
)

N O
;

O P
	CreateMap 
< 
Domain 
. 

Aggregates '
.' (
EmployeeRole( 4
.4 5
Entities5 =
.= >
EmployeeRole> J
,J K
DtosL P
.P Q
EmployeeRoleQ ]
.] ^
EmployeeRoleDto^ m
>m n
(n o
)o p
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (
Identificador( 5
,5 6
opt7 :
=>; =
opt> A
.A B
MapFromB I
(I J
srcJ M
=>N P
srcQ T
.T U
IdU W
)W X
)X Y
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (
Cargo( -
,- .
opt/ 2
=>3 5
opt6 9
.9 :
MapFrom: A
(A B
srcB E
=>F H
srcI L
.L M
RoleNameM U
)U V
)V W
. 
ForAllOtherMembers #
(# $
i$ %
=>& (
i) *
.* +
Ignore+ 1
(1 2
)2 3
)3 4
;4 5
} 	
} 
} ’-
çD:\Avanade-Treinamento\Avanade-SubTCSE-Projeto\src\Avanade.SubTCSE.Projeto.Application\AutoMapperConfigs\Profiles\Employee\EmployeeProfile.cs
	namespace 	
Avanade
 
. 
SubTCSE 
. 
Projeto !
.! "
Application" -
.- .
AutoMapperConfigs. ?
.? @
Profiles@ H
.H I
EmployeeI Q
{ 
public 

class 
EmployeeProfile  
:! "
Profile# *
{ 
public 
EmployeeProfile 
( 
)  
{ 	
	CreateMap		 
<		 
Dtos		 
.		 
Employee		 #
.		# $
EmployeeDto		$ /
,		/ 0
Domain		1 7
.		7 8

Aggregates		8 B
.		B C
Employee		C K
.		K L
Entities		L T
.		T U
Employee		U ]
>		] ^
(		^ _
)		_ `
.

 
ConstructUsing

 
(

  
(

  !
ctor

! %
,

% &
res

' *
)

* +
=>

, .
{ 
return 
new 
Domain %
.% &

Aggregates& 0
.0 1
Employee1 9
.9 :
Entities: B
.B C
EmployeeC K
(K L
	firstName !
:! "
ctor# '
.' (
PrimeiroNome( 4
,4 5
surName 
:  
ctor! %
.% &
	Sobrenome& /
,/ 0
birthday  
:  !
ctor" &
.& '
Aniversario' 2
,2 3
active 
: 
ctor  $
.$ %
Ativo% *
,* +
salary 
: 
ctor  $
.$ %
Salario% ,
,, -
employeeRole $
:$ %
res& )
.) *
Mapper* 0
.0 1
Map1 4
<4 5
Domain5 ;
.; <

Aggregates< F
.F G
EmployeeRoleG S
.S T
EntitiesT \
.\ ]
EmployeeRole] i
>i j
(j k
ctork o
.o p
Cargop u
)u v
)v w
;w x
} 
) 
. 
ForAllOtherMembers #
(# $
i$ %
=>& (
i) *
.* +
Ignore+ 1
(1 2
)2 3
)3 4
;4 5
	CreateMap 
< 
Domain 
. 

Aggregates '
.' (
Employee( 0
.0 1
Entities1 9
.9 :
Employee: B
,B C
DtosD H
.H I
EmployeeI Q
.Q R
EmployeeDtoR ]
>] ^
(^ _
)_ `
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (
Identificador( 5
,5 6
opt7 :
=>; =
opt> A
.A B
MapFromB I
(I J
srcJ M
=>N P
srcQ T
.T U
IdU W
)W X
)X Y
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (
PrimeiroNome( 4
,4 5
opt6 9
=>: <
opt= @
.@ A
MapFromA H
(H I
srcI L
=>M O
srcP S
.S T
	FirstNameT ]
)] ^
)^ _
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (
	Sobrenome( 1
,1 2
opt3 6
=>7 9
opt: =
.= >
MapFrom> E
(E F
srcF I
=>J L
srcM P
.P Q
SurNameQ X
)X Y
)Y Z
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (
Aniversario( 3
,3 4
opt5 8
=>9 ;
opt< ?
.? @
MapFrom@ G
(G H
srcH K
=>L N
srcO R
.R S
BirthdayS [
)[ \
)\ ]
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (
Ativo( -
,- .
opt/ 2
=>3 5
opt6 9
.9 :
MapFrom: A
(A B
srcB E
=>F H
srcI L
.L M
ActiveM S
)S T
)T U
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (
Salario( /
,/ 0
opt1 4
=>5 7
opt8 ;
.; <
MapFrom< C
(C D
srcD G
=>H J
srcK N
.N O
SalaryO U
)U V
)V W
. 
	ForMember 
( 
dest 
=>  "
dest# '
.' (
Cargo( -
,- .
opt/ 2
=>3 5
opt6 9
.9 :
MapFrom: A
(A B
srcB E
=>F H
srcI L
.L M
EmployeeRoleM Y
)Y Z
)Z [
. 
ForAllOtherMembers #
(# $
i$ %
=>& (
i) *
.* +
Ignore+ 1
(1 2
)2 3
)3 4
;4 5
} 	
}   
}!! ¢
kD:\Avanade-Treinamento\Avanade-SubTCSE-Projeto\src\Avanade.SubTCSE.Projeto.Application\Dtos\Base\BaseDto.cs
	namespace 	
Avanade
 
. 
SubTCSE 
. 
Projeto !
.! "
Application" -
.- .
Dtos. 2
.2 3
Base3 7
{ 
public 

abstract 
class 
BaseDto !
{ 
public 
string 
Identificador #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public		 
ValidationResult		 
ValidationResult		  0
{		1 2
get		3 6
;		6 7
set		8 ;
;		; <
}		= >
}

 
} ö
{D:\Avanade-Treinamento\Avanade-SubTCSE-Projeto\src\Avanade.SubTCSE.Projeto.Application\Dtos\EmployeeRole\EmployeeRoleDto.cs
	namespace 	
Avanade
 
. 
SubTCSE 
. 
Projeto !
.! "
Application" -
.- .
Dtos. 2
.2 3
EmployeeRole3 ?
{ 
public 

class 
EmployeeRoleDto  
:! "
BaseDto# *
{ 
public 
string 
Cargo 
{ 
get !
;! "
set# &
;& '
}( )
} 
}		 Õ
sD:\Avanade-Treinamento\Avanade-SubTCSE-Projeto\src\Avanade.SubTCSE.Projeto.Application\Dtos\Employee\EmployeeDto.cs
	namespace 	
Avanade
 
. 
SubTCSE 
. 
Projeto !
.! "
Application" -
.- .
Dtos. 2
.2 3
Employee3 ;
{ 
public 

class 
EmployeeDto 
: 
BaseDto &
{ 
public 
string 
PrimeiroNome "
{# $
get% (
;( )
set* -
;- .
}/ 0
public

 
string

 
	Sobrenome

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
public 
DateTime 
Aniversario #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
bool 
Ativo 
{ 
get 
;  
set! $
;$ %
}& '
public 
decimal 
Salario 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
EmployeeRole 
. 
EmployeeRoleDto +
Cargo, 1
{2 3
get4 7
;7 8
set9 <
;< =
}> ?
} 
} ‘
âD:\Avanade-Treinamento\Avanade-SubTCSE-Projeto\src\Avanade.SubTCSE.Projeto.Application\Interfaces\EmployeeRole\IEmployeeRoleAppService.cs
	namespace 	
Avanade
 
. 
SubTCSE 
. 
Projeto !
.! "
Application" -
.- .

Interfaces. 8
.8 9
EmployeeRole9 E
{ 
public 

	interface #
IEmployeeRoleAppService ,
{ 
Task 
< 
EmployeeRoleDto 
>  
AddEmployeeRoleAsync 2
(2 3
EmployeeRoleDto3 B
employeeRoleDtoC R
)R S
;S T
}		 
}

 ¥
ÅD:\Avanade-Treinamento\Avanade-SubTCSE-Projeto\src\Avanade.SubTCSE.Projeto.Application\Interfaces\Employee\IEmployeeAppService.cs
	namespace 	
Avanade
 
. 
SubTCSE 
. 
Projeto !
.! "
Application" -
.- .

Interfaces. 8
.8 9
Employee9 A
{ 
public 

	interface 
IEmployeeAppService (
{ 
Task 
< 
EmployeeDto 
> 
AddEmployeeAsync *
(* +
EmployeeDto+ 6
employeeDto7 B
)B C
;C D
}		 
}

 ù
ÜD:\Avanade-Treinamento\Avanade-SubTCSE-Projeto\src\Avanade.SubTCSE.Projeto.Application\Services\EmployeeRole\EmployeeRoleAppService.cs
	namespace 	
Avanade
 
. 
SubTCSE 
. 
Projeto !
.! "
Application" -
.- .
Services. 6
.6 7
EmployeeRole7 C
{		 
public

 

class

 "
EmployeeRoleAppService

 '
:

( )#
IEmployeeRoleAppService

* A
{ 
private 
readonly 
IMapper  
_mapper! (
;( )
private 
readonly  
IEmployeeRoleService - 
_employeeRoleService. B
;B C
public "
EmployeeRoleAppService %
(% &
IMapper& -
mapper. 4
,4 5 
IEmployeeRoleService6 J
employeeRoleServiceK ^
)^ _
{ 	
_mapper 
= 
mapper 
;  
_employeeRoleService  
=! "
employeeRoleService# 6
;6 7
} 	
public 
async 
Task 
< 
EmployeeRoleDto )
>) * 
AddEmployeeRoleAsync+ ?
(? @
EmployeeRoleDto@ O
employeeRoleDtoP _
)_ `
{ 	
var 

itemDomain 
= 
_mapper $
.$ %
Map% (
<( )
EmployeeRoleDto) 8
,8 9
Domain: @
.@ A

AggregatesA K
.K L
EmployeeRoleL X
.X Y
EntitiesY a
.a b
EmployeeRoleb n
>n o
(o p
employeeRoleDtop 
)	 Ä
;
Ä Å
var 
item 
= 
await  
_employeeRoleService 1
.1 2 
AddEmployeeRoleAsync2 F
(F G

itemDomainG Q
)Q R
;R S
var 
itemDto 
= 
_mapper !
.! "
Map" %
<% &
Domain& ,
., -

Aggregates- 7
.7 8
EmployeeRole8 D
.D E
EntitiesE M
.M N
EmployeeRoleN Z
,Z [
EmployeeRoleDto\ k
>k l
(l m
itemm q
)q r
;r s
return"" 
itemDto"" 
;"" 
}## 	
}$$ 
}%% 