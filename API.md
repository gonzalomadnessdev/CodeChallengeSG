# Introducción

La solución consta de dos servicios. Uno para manejar lo que es autenticación (AuthService) y otro para manejar los saldos y movimientos de las cuentas (CuentasService). Ambos estan unificados en una misma API mediante el servicio de Api Gateway.

## Endpoints

#### Register:
```
POST /auth/register
```
Request:
```
{
    "username": "JohnDoe",
    "password": "123456"
}
```
Response:
```
201
```
___________ 
#### Login:
```
POST /auth/login
```
Request:
```
{
    "username": "JohnDoe",
    "password": "123456"
}
```
Response:
```
200

{
    "token" : "",
    "expires" : ""
}
```
___________ 

#### Saldo:
```
GET /cuenta/saldo
```
Headers:
```
Authorization: Bearer token
```

Response:
```
200

{
    "saldo": 100
}
```
___________ 

#### CashIn:
```
POST /cuenta/cashin
```
Headers:
```
Authorization: Bearer token
```

Request:
```
{
    "importe": 100
}
```

Response:
```
200
```
___________ 

#### CashOut:
```
POST /cuenta/cashout
```
Headers:
```
Authorization: Bearer token
```

Request:
```
{
    "importe": 100
}
```

Response:
```
200
```
___________ 
