Tarea 3 – Sistema de Gestión de Empleados con Entity Framework Core

Nombre: Ricardo Josué Castillo Acevedo
Carnet: C21785

--------------------------------------------------

Descripción del proyecto

Aplicación web desarrollada en ASP.NET Core MVC que permite la gestión de empleados de una empresa.

El sistema permite:
- Registrar empleados
- Editar empleados
- Dar de baja o activar empleados (baja lógica)
- Buscar empleados por nombre, apellidos o departamento
- Visualizar resultados con paginación

Se implementa el patrón Repositorio utilizando Entity Framework Core.

--------------------------------------------------

Tecnologías utilizadas

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- C#

--------------------------------------------------

Funcionalidad de búsqueda

El sistema permite buscar empleados mediante un término que se compara con:
- Nombre
- Apellidos
- Departamento

La búsqueda es case-insensitive utilizando Contains() en LINQ.

--------------------------------------------------

Funcionalidad de paginación

- Tamaño de página: 5 registros
- Implementación con Skip() y Take()
- Se muestra:
  - Página actual
  - Total de páginas
  - Total de registros encontrados

--------------------------------------------------

Toggle de estado (Activo / Baja)

No se elimina el empleado físicamente.

Se implementa una acción ToggleActivo que:
- Cambia el estado del empleado (Activo = true/false)
- Muestra en la interfaz:
  - Activo
  - Dado de baja

--------------------------------------------------

Ejemplos de uso

/Empleados
/Empleados?busqueda=TI
/Empleados?busqueda=Ana&pagina=2

--------------------------------------------------

Instrucciones de ejecución

1. Clonar el repositorio
2. Abrir el proyecto en Visual Studio
3. Configurar la cadena de conexión en appsettings.json
4. Ejecutar migraciones:

Add-Migration InitialCreate
Update-Database

5. Ejecutar el proyecto

--------------------------------------------------

Base de datos

El proyecto incluye un script SQL en la carpeta:

script sql/

--------------------------------------------------

Estructura del proyecto

- Models → Entidades del sistema
- Data → DbContext
- Repositories → Acceso a datos (patrón repositorio)
- Controllers → Lógica de la aplicación
- Views → Interfaz de usuario

--------------------------------------------------

Notas finales

El proyecto implementa buenas prácticas de:
- Clean Code
- Separación de responsabilidades
- Arquitectura por capas