# Povho Dinner API

## Table of Contents

- [Povho Dinner API](#povho-dinner-api)
  - [Auth](#auth)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)

## Auth

### Register

```js
POST {{host}}/api/auth/register
```

#### Register Request

```json
{
    "firstname": "string",
    "lastname": "string",
    "password": "string",
    "email": "string"
}
```

#### Register Response

```js
200 OK
```

```json
{
    "token": "string",
    "firstname": "string",
    "lastname": "string",
    "email": "string",
    "id": "string"
}
```

### Login

```js
POST {{host}}/api/auth/login
```

#### Login Request

```json
{
    "password": "string",
    "email": "string"
}
```

#### Login Response

```js
200 Ok
```

```json
{
    "token": "string",
    "firstname": "string",
    "lastname": "string",
    "email": "string",
    "id": "string"
}
```
