Ù
tD:\Avanade-Treinamento\Avanade-SubTCSE-Projeto\src\Avanade.SubTCSE.Projeto.Infra.CrossCutting\DependencyInjection.cs
	namespace 	
Avanade
 
. 
SubTCSE 
. 
Projeto !
.! "
Infra" '
.' (
CrossCutting( 4
{ 
public 

static 
class 
DependencyInjection +
{ 
public 
static 
void -
!AddRegisterDependenciesInjections <
(< =
this= A
IServiceCollectionB T
servicesU ]
)] ^
{ 	
services 
. 
AddAutoMapper "
(" #
typeof# )
() *
Application* 5
.5 6
AutoMapperConfigs6 G
.G H
ProfilesH P
.P Q
ConfigsQ X
)X Y
)Y Z
;Z [
services 
. 
AddSingleton !
<! "
IMongoDBContext" 1
,1 2
MongoDBContext3 A
>A B
(B C
)C D
;D E
services 
. 
	AddScoped 
< #
IEmployeeRoleAppService 6
,6 7"
EmployeeRoleAppService8 N
>N O
(O P
)P Q
;Q R
services 
. 
	AddScoped 
<  
IEmployeeRoleService 3
,3 4
EmployeeRoleService5 H
>H I
(I J
)J K
;K L
services 
. 
	AddScoped 
< #
IEmployeeRoleRepository 6
,6 7#
EmployeeRoleRespository8 O
>O P
(P Q
)Q R
;R S
services 
. 
AddTransient !
<! "

IValidator" ,
<, -
EmployeeRole- 9
>9 :
,: ;!
EmployeeRoleValidator< Q
>Q R
(R S
)S T
;T U
} 	
}   
}!! 