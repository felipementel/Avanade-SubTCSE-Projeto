²
tD:\Avanade-Treinamento\Avanade-SubTCSE-Projeto\src\Avanade.SubTCSE.Projeto.Api\Controllers\EmployeeRoleController.cs
	namespace 	
Avanade
 
. 
SubTCSE 
. 
Projeto !
.! "
Api" %
.% &
Controllers& 1
{		 
[

 
Route

 

(


 
$str

 3
)

3 4
]

4 5
[ 

ApiVersion 
( 
$str 
, 

Deprecated 
=  !
false" '
)' (
]( )
[ 
ApiController 
] 
[ 
ApiExplorerSettings 
( 
	GroupName "
=# $
$str% )
)) *
]* +
public 

class "
EmployeeRoleController '
:( )
ControllerBase* 8
{ 
private 
readonly #
IEmployeeRoleAppService 0#
_employeeRoleAppService1 H
;H I
public "
EmployeeRoleController %
(% &#
IEmployeeRoleAppService& ="
employeeRoleAppService> T
)T U
{ 	#
_employeeRoleAppService #
=$ %"
employeeRoleAppService& <
;< =
} 	
[ 	
HttpPost	 
( 
Name 
= 
$str '
)' (
]( )
[ 	
Consumes	 
( 
MediaTypeNames  
.  !
Application! ,
., -
Json- 1
)1 2
]2 3
[ 	 
ProducesResponseType	 
( 
typeof $
($ %
EmployeeRoleDto% 4
)4 5
,5 6
StatusCodes7 B
.B C
Status201CreatedC S
)S T
]T U
[ 	 
ProducesResponseType	 
( 
StatusCodes )
.) *(
Status500InternalServerError* F
)F G
]G H
public 
async 
Task 
< 
IActionResult '
>' (
CreateEmployeeRole) ;
(; <
[< =
FromBody= E
]E F
EmployeeRoleDtoG V
employeeRoleDtoW f
)f g
{ 	
var 
item 
= 
await #
_employeeRoleAppService 4
.4 5 
AddEmployeeRoleAsync5 I
(I J
employeeRoleDtoJ Y
)Y Z
;Z [
if 
( 
! 
item 
. 
ValidationResult &
.& '
IsValid' .
). /
{   
return!! 

BadRequest!! !
(!!! "
string!!" (
.!!( )
Join!!) -
(!!- .
$char!!. 2
,!!2 3
item!!4 8
.!!8 9
ValidationResult!!9 I
.!!I J
Errors!!J P
)!!P Q
)!!Q R
;!!R S
}"" 
return$$ 
Ok$$ 
($$ 
)$$ 
;$$ 
}%% 	
}&& 
}'' –
YD:\Avanade-Treinamento\Avanade-SubTCSE-Projeto\src\Avanade.SubTCSE.Projeto.Api\Program.cs
	namespace 	
Avanade
 
. 
SubTCSE 
. 
Projeto !
.! "
Api" %
{ 
public 

class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{		 	
CreateHostBuilder

 
(

 
args

 "
)

" #
.

# $
Build

$ )
(

) *
)

* +
.

+ ,
Run

, /
(

/ 0
)

0 1
;

1 2
} 	
public 
static 
IHostBuilder "
CreateHostBuilder# 4
(4 5
string5 ;
[; <
]< =
args> B
)B C
=>D F
Host 
.  
CreateDefaultBuilder %
(% &
args& *
)* +
. $
ConfigureWebHostDefaults )
() *

webBuilder* 4
=>5 7
{ 

webBuilder 
. 

UseStartup )
<) *
Startup* 1
>1 2
(2 3
)3 4
;4 5
} 
) 
; 
} 
} Í 
YD:\Avanade-Treinamento\Avanade-SubTCSE-Projeto\src\Avanade.SubTCSE.Projeto.Api\Startup.cs
	namespace

 	
Avanade


 
.

 
SubTCSE

 
.

 
Projeto

 !
.

! "
Api

" %
{ 
public 

class 
Startup 
{ 
public 
IConfiguration 
_configuration ,
{- .
get/ 2
;2 3
}4 5
public 
Startup 
( 
IConfiguration %
configuration& 3
)3 4
{ 	
_configuration 
= 
configuration *
;* +
} 	
public 
void 
ConfigureServices %
(% &
IServiceCollection& 8
services9 A
)A B
{ 	
services 
. 
AddControllers #
(# $
)$ %
;% &
services 
. 
AddApiVersioning %
(% &
options 
=> 
{ 
options 
. 
ReportApiVersions -
=. /
true0 4
;4 5
options 
. /
#AssumeDefaultVersionWhenUnspecified ?
=@ A
trueB F
;F G
options   
.   
DefaultApiVersion   -
=  . /
new  0 3

ApiVersion  4 >
(  > ?
$num  ? @
,  @ A
$num  B C
)  C D
;  D E
}!! 
)!! 
."" #
AddVersionedApiExplorer"" (
(""( )
options"") 0
=>""1 3
{## 
options$$ 
.$$ 
GroupNameFormat$$ +
=$$, -
$str$$. 6
;$$6 7
options%% 
.%% %
SubstituteApiVersionInUrl%% 5
=%%6 7
true%%8 <
;%%< =
}&& 
)&& 
;&& 
services(( 
.(( 
AddSwaggerGen(( "
(((" #
c((# $
=>((% '
{)) 
c** 
.** 

SwaggerDoc** 
(** 
$str** !
,**! "
new**# &
OpenApiInfo**' 2
{**3 4
Title**5 :
=**; <
$str**= Z
,**Z [
Version**\ c
=**d e
$str**f j
}**k l
)**l m
;**m n
}++ 
)++ 
;++ 
services-- 
.-- -
!AddRegisterDependenciesInjections-- 6
(--6 7
)--7 8
;--8 9
}.. 	
public11 
void11 
	Configure11 
(11 
IApplicationBuilder11 1
app112 5
,115 6
IWebHostEnvironment117 J
env11K N
)11N O
{22 	
if33 
(33 
env33 
.33 
IsDevelopment33 !
(33! "
)33" #
)33# $
{44 
app55 
.55 %
UseDeveloperExceptionPage55 -
(55- .
)55. /
;55/ 0
app66 
.66 

UseSwagger66 
(66 
)66  
;66  !
app77 
.77 
UseSwaggerUI77  
(77  !
c77! "
=>77# %
c77& '
.77' (
SwaggerEndpoint77( 7
(777 8
$str778 R
,77R S
$str77T t
)77t u
)77u v
;77v w
}88 
app:: 
.:: 
UseHttpsRedirection:: #
(::# $
)::$ %
;::% &
app<< 
.<< 

UseRouting<< 
(<< 
)<< 
;<< 
app>> 
.>> 
UseAuthorization>>  
(>>  !
)>>! "
;>>" #
app@@ 
.@@ 
UseEndpoints@@ 
(@@ 
	endpoints@@ &
=>@@' )
{AA 
	endpointsBB 
.BB 
MapControllersBB (
(BB( )
)BB) *
;BB* +
}CC 
)CC 
;CC 
}DD 	
}EE 
}FF 