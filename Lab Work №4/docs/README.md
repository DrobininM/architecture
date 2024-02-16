Лабораторная работа 4 - проектирование API.

# Решение

В рамках предыдущей лабораторной работы мною был написан небольшой API на C# ASP.NET, который отвечает за получение и добавление пользователей и их ролей в базу данных PostgreSQL. В данной работе этот API доработан и теперь реализует GET, POST, PUT, DELETE для User и UserRole.

## Схема базы данных:
![Alt text](bd_schema.png)

## User:
Код, отвечающий за endpoint GET /users:

![Alt text](get_users_code.png)

Если нет пользователей, то возвращается код 204. Если возникли проблемы при чтении из БД, то возвращается код 500. Иначе возвращается код 200 и список со всеми пользователями, находящимися в БД. Описание выходных данных:

![Alt text](get_users_schema.png)

Код, отвечающий за endpoint GET /users/{id}:

![Alt text](get_user_code.png)

Если был передан id неправильного формата, то возвращается код 400. Если возникли проблемы при чтении из БД, то возвращается код 500. Если нет пользователя с переданным id, то возвращается код 404. Иначе возвращается код 200 и пользователь с указанным id. Описание входных и выходных данных:

![Alt text](get_user_schema.png)

Код, отвечающий за endpoint POST /users/create:

![Alt text](create_user_code.png)

Если переданы не все необходимые данные, то возвращается код 400. Если возникли проблемы при записи в БД, то возвращается код 500. Иначе возвращается код 200 и созданный пользователь, который был сохранён в БД. Описание входных и выходных данных:

![Alt text](create_user_schema.png)

Код, отвечающий за endpoint PUT /users/update/{id}:

![Alt text](update_user_code.png)

Если был передан id неправильного формата, то возвращается код 400. Если возникли проблемы при записи в БД, то возвращается код 500. Иначе возвращается код 200 и обновлённый пользователь. Описание входных и выходных данных:

![Alt text](update_user_schema.png)

Код, отвечающий за endpoint DELETE /users/delete/{id}:

![Alt text](delete_user_code.png)

Если был передан id неправильного формата, то возвращается код 400. Если пользователя с указанным id не существует, то возвращается код 404. Если возникли проблемы при записи в БД, то возвращается код 500. Иначе возвращается код 200. Описание входных и выходных данных:

![Alt text](delete_user_schema.png)

## UserRole:

Код, отвечающий за endpoint GET /userRoles:

![Alt text](get_userRoles_code.png)

Если нет ролей пользователей, то возвращается код 204. Если возникли проблемы при чтении из БД, то возвращается код 500. Иначе возвращается код 200 и список со всеми ролями, находящимися в БД. Описание выходных данных:

![Alt text](get_userRoles_schema.png)

Код, отвечающий за endpoint GET /userRoles/{id}:

![Alt text](get_userRole_code.png)

Если был передан id неправильного формата, то возвращается код 400. Если возникли проблемы при чтении из БД, то возвращается код 500. Если нет роли пользователя с переданным id, то возвращается код 404. Иначе возвращается код 200 и роль с указанным id. Описание входных и выходных данных:

![Alt text](get_userRole_schema.png)

Код, отвечающий за endpoint POST /userRoles/create:

![Alt text](create_userRole_code.png)

Если переданы не все необходимые данные, то возвращается код 400. Если возникли проблемы при записи в БД, то возвращается код 500. Иначе возвращается код 200 и созданная роль, которая была сохранена в БД. Описание входных и выходных данных:

![Alt text](create_userRole_schema.png)

Код, отвечающий за endpoint PUT /userRoles/update/{id}:

![Alt text](update_userRole_code.png)

Если был передан id неправильного формата, то возвращается код 400. Если возникли проблемы при записи в БД, то возвращается код 500. Иначе возвращается код 200 и обновлённая роль. Описание входных и выходных данных:

![Alt text](update_userRole_schema.png)

Код, отвечающий за endpoint DELETE /userRoles/delete/{id}:

![Alt text](delete_userRole_code.png)

Если был передан id неправильного формата, то возвращается код 400. Если роль с указанным id не существует, то возвращается код 404. Если возникли проблемы при записи в БД, то возвращается код 500. Иначе возвращается код 200. Описание входных и выходных данных:

![Alt text](delete_userRole_schema.png)

# Тестирование

Для вышеперечисленных эндпоинтов были написаны тесты в Postman.

## GET users/{id}

Ответ сервера:

![Alt text](./tests/get_user_response.png)
![Alt text](./tests/get_user_headers.png)

Код тестов и результаты их выполнения:

![Alt text](./tests/get_user_tests_code.png)
![Alt text](./tests/get_user_tests_res.png)

## POST users/create

Ответ сервера:

![Alt text](./tests/create_user_response.png)
![Alt text](./tests/create_user_headers.png)

Код тестов и результаты их выполнения:

![Alt text](./tests/create_user_tests_code.png)
![Alt text](./tests/create_user_tests_res.png)

## PUT users/update/{id}

Ответ сервера:

![Alt text](./tests/update_user_params.png)
![Alt text](./tests/update_user_body.png)
![Alt text](./tests/update_user_response.png)
![Alt text](./tests/update_user_headers.png)

Код тестов и результаты их выполнения:

![Alt text](./tests/update_user_tests_code.png)
![Alt text](./tests/update_user_tests_res.png)

## DELETE users/delete/{id}

Ответ сервера:

![Alt text](./tests/delete_user_response.png)
![Alt text](./tests/delete_user_headers.png)

Код тестов и результаты их выполнения:

![Alt text](./tests/delete_user_tests.png)