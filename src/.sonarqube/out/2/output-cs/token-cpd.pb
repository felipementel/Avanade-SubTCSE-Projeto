ñ
yD:\Avanade-Treinamento\Avanade-SubTCSE-Projeto\src\Avanade.SubTCSE.Projeto.Infra.Data\Repositories\Base\BaseRepository.cs
	namespace 	
Avanade
 
. 
SubTCSE 
. 
Projeto !
.! "
Infra" '
.' (
Data( ,
., -
Repositories- 9
.9 :
Base: >
{ 
public		 

abstract		 
class		 
BaseRepository		 (
<		( )
TEntity		) 0
,		0 1
Tid		2 5
>		5 6
:

 	
IBaseRepository


 
<

 
TEntity

 !
,

! "
Tid

# &
>

& '
where

( -
TEntity

. 5
:

6 7

BaseEntity

8 B
<

B C
Tid

C F
>

F G
{ 
private 
readonly 
IMongoCollection )
<) *
TEntity* 1
>1 2
_collection3 >
;> ?
	protected 
BaseRepository  
(  !
IMongoDBContext! 0
mongoDBContext1 ?
,? @
stringA G
collectioNameH U
)U V
{ 	
_collection 
= 
mongoDBContext (
.( )
GetCollection) 6
<6 7
TEntity7 >
>> ?
(? @
collectioName@ M
)M N
;N O
} 	
public 
virtual 
async 
Task !
<! "
TEntity" )
>) *
AddAsync+ 3
(3 4
TEntity4 ;
entity< B
)B C
{ 	
await 
_collection 
. 
InsertOneAsync ,
(, -
entity- 3
)3 4
;4 5
return 
entity 
; 
} 	
public 
async 
Task 
< 
TEntity !
>! "
FindByIdAsync# 0
(0 1
Tid1 4
Id5 7
)7 8
{ 	
throw 
new 
System 
. #
NotImplementedException 4
(4 5
)5 6
;6 7
} 	
} 
} â
ÅD:\Avanade-Treinamento\Avanade-SubTCSE-Projeto\src\Avanade.SubTCSE.Projeto.Infra.Data\Repositories\Base\MongoDB\MongoDBContext.cs
	namespace 	
Avanade
 
. 
SubTCSE 
. 
Projeto !
.! "
Infra" '
.' (
Data( ,
., -
Repositories- 9
.9 :
Base: >
.> ?
MongoDB? F
{ 
public 

class 
MongoDBContext 
:  !
IMongoDBContext" 1
{ 
private 
readonly 
IMongoDatabase '
_mongoDatabase( 6
;6 7
public

 
MongoDBContext

 
(

 
)

 
{ 	
MongoClientSettings 
mongoClientSettings  3
=4 5
MongoClientSettings6 I
. 
FromUrl 
( 
new 
MongoUrl %
(% &
$str& P
)P Q
)Q R
;R S
mongoClientSettings 
.  
SslSettings  +
=, -
new 
SslSettings 
(  
)  !
{ 
EnabledSslProtocols '
=( )
System* 0
.0 1
Security1 9
.9 :
Authentication: H
.H I
SslProtocolsI U
.U V
Tls12V [
} 
; 
MongoClient 
mongoClient #
=$ %
new& )
MongoClient* 5
(5 6
settings6 >
:> ?
mongoClientSettings@ S
)S T
;T U
_mongoDatabase 
= 
mongoClient (
.( )
GetDatabase) 4
(4 5
$str5 @
)@ A
;A B
} 	
public 
IMongoCollection 
<  
TEntity  '
>' (
GetCollection) 6
<6 7
TEntity7 >
>> ?
(? @
string@ F

collectionG Q
)Q R
{ 	
return 
_mongoDatabase !
.! "
GetCollection" /
</ 0
TEntity0 7
>7 8
(8 9
name9 =
:= >

collection? I
)I J
;J K
} 	
} 
} î	
äD:\Avanade-Treinamento\Avanade-SubTCSE-Projeto\src\Avanade.SubTCSE.Projeto.Infra.Data\Repositories\EmployeeRole\EmployeeRoleRespository.cs
	namespace 	
Avanade
 
. 
SubTCSE 
. 
Projeto !
.! "
Infra" '
.' (
Data( ,
., -
Repositories- 9
.9 :
EmployeeRole: F
{ 
public 

class #
EmployeeRoleRespository (
: 	
BaseRepository
 
< 
Domain 
.  

Aggregates  *
.* +
EmployeeRole+ 7
.7 8
Entities8 @
.@ A
EmployeeRoleA M
,M N
stringO U
>U V
,		 	#
IEmployeeRoleRepository		
 !
{

 
public #
EmployeeRoleRespository &
(& '
IMongoDBContext' 6
mongoDBContext7 E
)E F
: 
base 
( 
mongoDBContext !
,! "
$str# 1
)1 2
{ 	
} 	
} 
} Ò
ÅD:\Avanade-Treinamento\Avanade-SubTCSE-Projeto\src\Avanade.SubTCSE.Projeto.Infra.Data\Repositories\Employee\EmployeeRepository.cs
	namespace 	
Avanade
 
. 
SubTCSE 
. 
Projeto !
.! "
Infra" '
.' (
Data( ,
., -
Repositories- 9
.9 :
Employee: B
{ 
public 

class 
EmployeeRepository #
: 	
BaseRepository
 
< 
Domain 
.  

Aggregates  *
.* +
Employee+ 3
.3 4
Entities4 <
.< =
Employee= E
,E F
stringG M
>M N
,		 	
IEmployeeRepository		
 
{

 
public 
EmployeeRepository !
(! "
IMongoDBContext" 1
mongoDBContext2 @
)@ A
: 
base 
( 
mongoDBContext !
,! "
$str# -
)- .
{ 	
} 	
} 
} 