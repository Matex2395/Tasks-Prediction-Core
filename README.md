  # Tasks-Prediction-Core

Este repositorio contiene un proyecto Core basado en el Modelo Vista-Controlador que permite, por el momento, realizar operaciones CRUD
con usuarios y tareas. Asimismo, algunas funcionalidades están disponibles solo a nivel de administrador; por lo tanto,
este proyecto incluye una implementación de Registro, Inicio de Sesión y Autenticación por cookies.

Hablando de las funcionalidades del usuario "Administrador", solo este podrá acceder al CRUD de usuarios y no podrá ni editar ni eliminar otros usuarios administradores.
Por otro lado, el usuario "Desarrollador" solo podrá acceder al CRUD de tareas. 

Para este proyecto se usaron las tecnologías de ASP.NET & EntityFramework, siendo esta última una gran 
ayuda para poder gestionar bases de datos desde la consola del Administrador de Paquetes NuGet. 

Un desafío encontrado fue el mostrar y ocultar ciertos elementos cuando un tipo de usuario iniciaba sesión; sin embargo, esto fue 
solucionado fácilmente con el uso de unas pocas líneas de código y sentencias condicionales ```If```.

## Requisitos Previos

- Tener instalado Visual Studio 2022
- Tener instalado Microsoft SQL Server Management Studio 20

## Instrucciones de Uso

1. **Clona el Repositorio:** Clona este repositorio utilizando Git:

    ```bash
    git clone https://github.com/Matex2395/Tasks-Prediction-Core.git
    ```

2. **Abre el Proyecto en Visual Studio 2022:** Abre Visual Studio 2022 y ejecuta el archivo que contiene la solución del proyecto, con esto podrás acceder a los archivos del proyecto.

3. **Crea la Base de Datos**

    - Modifica la cadena de conexión en ```appsettings.json``` para que esta responda a tu base de datos en SQL Server.
    - Añade las migraciones y actualiza la Base de Datos por medio de la consola del Administrador de Paquetes NuGet.

4. **Ejecuta el proyecto**

   - Pon a correr al proyecto y prueba registrarte e iniciar sesión.
   - En Microsoft SQL Server Management Studio podrás encontrar el usuario administrador y desarrollador para que puedas verificar la limitación de ciertas funcionalidades.
   **NOTA:** En caso de que quieras probar el proyecto desplegado, aquí te dejo todo lo necesario para que puedas acceder a él.
     - __Enlace al sitio web:__ http://matex2395123-001-site1.ntempurl.com/Home/Index
     - __Usuario:__ 11203405
     - __Contraseña:__ 60-dayfreetrial

## Créditos

Los siguientes tutoriales apoyaron en gran medida la realización de este proyecto:
- Creación del CRUD, Modelos y Controladores: https://www.youtube.com/watch?v=dhguXv3vRIk
- Login, Registro y Autenticación de usuarios: https://www.youtube.com/watch?v=pJb9O7foT-8

## Contribuciones

¡Siéntete libre de contribuir al proyecto abriendo issues o enviando pull requests!
