# Instrucciones para el despliegue en entorno local

1. Posicionado en "./" ejecutar el comando:
```
docker compose up -d
```
2. Una vez corriendo los contenedores conectarse a la base de datos mapeada en el puerto 11433 mediante SSMS u otro DBMS:
```
Server : 127.0.0.1\sgdb-1,11433
User: sa
Password: password@12345#
```
3. Ejecutar la query del archivo "SG.sql" (una vez ejecutada, la DB va a persistir en el volumen de la carpeta "./mssql")

4. En caso de usar postman, importe la colleccion de endpoints mediante el archivo "CodeChallengeSG.postman_collection.json".

5. En el archivo API.md se encuentra la documentacion de los endpoints