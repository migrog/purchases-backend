# purchases-backend
Gestión de Compras - API Rest Services

## Pasos Iniciales

###Clonar el repositorio

```bash
  git clone https://github.com/migrog/purchases-backend.git
```

###Crear la base de datos(SQL Server):

Ubica los scripts en carpeta "database" y Ejecutalos en el siguiente orden:
  1. schema.sql
  2. data-default.sql

###Configurar la conexión de la base datos de los servicios:

Modificar el archivo: appsettings.json de cada servicio:
*rutas:
- servicio "user" --> user\user.api\appsettings.json
- servicio "product" --> product\product.api\appsettings.json
- servicio "purchase" --> purchase\purchase.api\appsettings.json

####Sección a modificar:
```bash
  "ConnectionStrings": {
        "Conexion": "Server=localhost\\SQL2019; Database=purchases; User Id=sa; Password=password"
    },
```
Nota: 
-Se recomienda cambiar el Server, User Id y Password según la configuración de tu servidor de base datos.
-Se recomienda mantener el nombre de la Database.

## Ejecutar Localmente(IIS Express):

Abra las soluciones: user.sln, product.sln y purchase.sln y presionar f5 en cada solución abierta.


## Probar las APIs(Postman):

Abra la aplicación Postman e importa el archivo "Purchases Backend API.postman_collection" que se encuentra ubicado en la carpeta "test-api".
