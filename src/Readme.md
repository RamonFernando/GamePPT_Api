# PokeAPI — Proyecto Full-Stack (Node.js + C#)

Este proyecto combina una **API creada con Node.js** y una **aplicación de consola en C#** que consume dicha API.
Permite realizar búsquedas de Pokémon, filtrarlos por nombre, tipo, movimientos, ID,
gestionar favoritos y cargar/guardar datos en JSON.

El proyecto sigue una arquitectura organizada en capas:

- **API (Node.js)**
- **Aplicación C#**
- **Controllers**
- **Services**
- **Models**
- **Views**
- **Helpers**
- **JSON Local**

Para ejecutar el proyecto correctamente es necesario usar **dos consolas de forma simultánea**.

---

## 🚀 Ejecución del proyecto

## 1️⃣ Iniciar la API en Node.js

1. Abre una consola y navega a:

C:\Users\Ramon\Ramon Dropbox\Ramon Perez\PC\Desktop\PokeAPI\pokeAPI\src\api>
2. Ejecuta: node pokeAPI.js
3. Si todo está funcionando, aparecerá:
Servidor escuchando en http://localhost:4000/pokemons
La API ya está disponible y lista para que la aplicación en C# realice peticiones HTTP.

---

## 2️⃣ Ejecutar la aplicación en CSharp

1. Abrir una **segunda consola**.
2. Navegar a la ruta principal del proyecto:
C:\Users\Ramon\Ramon Dropbox\Ramon Perez\PC\Desktop\PokeAPI\pokeAPI>
3. Ejecutar: dotnet run

La aplicación se iniciará, mostrará el menú principal por consola y comenzará a interactuar con tu API en Node.js.

````C#
            Console.WriteLine("**=======================================**");
            Console.WriteLine($"  Bienvenido a la API de Pokemons");
            Console.WriteLine("===========================================");
            Console.WriteLine("         MENU PRINCIPAL");
            Console.WriteLine("===========================================");
            Console.WriteLine("1. Mostrar API");
            Console.WriteLine("2. Buscar (Id)");
            Console.WriteLine("3. Buscar (Nombre y Add a Favoritos)");
            Console.WriteLine("4. Mostrar Tipo");
            Console.WriteLine("5. Mostrar Altura");
            Console.WriteLine("6. Mostrar Peso");
            Console.WriteLine("7. Mostrar Movimientos");
            Console.WriteLine("8. Borrar Pokemon de Lista Favoritos");
            Console.WriteLine("9. Mostrar Lista API");
            Console.WriteLine("10. Actualizar Pokemon (PUT)");
            Console.WriteLine("11. Delete Pokemon (DELETE)");
            Console.WriteLine("0. Salir");
            Console.WriteLine("**=======================================**");
            Console.Write("Introduce una opcion: ");

````

🧩 1. Estructura general del proyecto
pokeAPI/
│
├── Program.cs
├── pokeAPI.csproj
├── pokeAPI.sln
│
├── .vscode/
│   └── settings.json
│
├── src/
│   ├── app/
│   │   └── App.cs
│   │
│   ├── Controllers/
│   │   ├── APIAddFavoriteList.cs
│   │   ├── APIControllers.cs
│   │   ├── APIDeletePokemonDELETE.cs
│   │   ├── APIRemoveFavoriteList.cs
│   │   ├── APIUpdatePokemonPUT.cs
│   │   ├── SearchByHeight.cs
│   │   ├── SearchById.cs
│   │   ├── SearchByMass.cs
│   │   ├── SearchByMoves.cs
│   │   ├── SearchByName.cs
│   │   └── SearchByType.cs
│   │
│   ├── Helpers/
│   │   ├── Helpers.cs
│   │   └── APIValidatorInputs.cs
│   │
│   ├── Models/
│   │   └── Models.cs
│   │
│   ├── Services/
│   │   ├── APILoadJson.cs
│   │   ├── APISaveJson.cs
│   │   ├── HttpClientService.cs
│   │   ├── SearchByHeight.cs
│   │   ├── SearchById.cs
│   │   ├── SearchByMass.cs
│   │   ├── SearchByMoves.cs
│   │   ├── SearchByName.cs
│   │   └── SearchByType.cs
│   │
│   └── Views/
│       ├── GetRequestAPI.cs
│       └── Views.cs
│
└── obj/

🟦 2. Archivos de nivel raíz
Program.cs

Punto de entrada del programa.

Define BASE_URL hacia el backend local (http://localhost:4000/pokemons).

Instancia App y ejecuta app.Run().

No contiene lógica propia; delega todo en App.

pokeAPI.csproj

Archivo de configuración del proyecto .NET.

Indica versión del framework y dependencias básicas.

🟥 3. /src/app
App.cs

- Es el centro de control del programa.

- Contiene el menú principal y la lógica que coordina controladores, vistas y servicios.

- Gestiona el flujo de trabajo: búsquedas, CRUD, favoritos, etc.

- Crítica: El archivo es grande; sería recomendable dividir parte del menú y lógica para mejorar SRP.

🟩 4. /src/Controllers

Controladores que gestionan cada operación del menú.
En general no realizan ellos mismos peticiones HTTP: delegan en los Services.

> APIAddFavoriteList.cs

- Llama a servicios para agregar un Pokémon a la lista de favoritos.

- Usa validación previa antes de guardar.

> APIRemoveFavoriteList.cs

- Elimina Pokémon de la lista de favoritos.

- Depende de validaciones y de la función de guardado en JSON.

> APIDeletePokemonDELETE.cs

- Gestiona la lógica para borrar un Pokémon mediante DELETE.

- Critica: Debería incluir manejo explícito de status codes de éxito/error.

> APIUpdatePokemonPUT.cs

- Gestiona actualización (PUT) de datos de Pokémon.

- Usa validadores antes de enviar la petición.

> APIControllers.cs

- Archivo contenedor con funciones comunes que usan los otros controladores.

- Centraliza llamadas repetidas.

``SearchByName.cs / SearchById.cs / SearchByType.cs / SearchByHeight.cs / SearchByMass.cs / SearchByMoves.cs``

- Cada archivo gestiona una búsqueda específica.

- Realizan validación + delegan en Services para obtener los datos.

- Crítica: Tienen lógica duplicada entre sí; se podría unificar.

🟨 5. /src/Services

HttpClientService.cs

- Servicio central que ejecuta las peticiones HTTP (GET/POST/PUT/DELETE).

- Maneja errores y devuelve el contenido bruto.

> APILoadJson.cs

- Carga JSON desde un archivo local (favoritos u otros datos persistentes).

- Devuelve modelos ya deserializados.

> APISaveJson.cs

- Guarda listas u objetos en archivos JSON.

## Servicios de búsqueda

- SearchByName.cs

- SearchById.cs

- SearchByType.cs

- SearchByHeight.cs

- SearchByMass.cs

- SearchByMoves.cs

Todos estos:

Consumen el HttpClientService.

Transforman la respuesta JSON en modelos.

Filtran o transforman resultados.

🟫 6. /src/Models
Models.cs

Define la estructura de datos usada para mapear el JSON recibido.

Incluye modelos como Pokémon, Stats, Moves, etc.

🟪 7. /src/Helpers
> Helpers.cs

- Contiene utilidades comunes: Manejo de errores

> APIValidatorInputs.cs

- Valida entradas del usuario antes de enviar peticiones.

- Reduce errores y evita fallos en Services.

🟧 8. /src/Views
> Views.cs

- Funciones para mostrar datos al usuario (formateo de Pokémon, listas, etc.).

> GetRequestAPI.cs

Muestra respuestas de llamadas HTTP GET.

Actúa como capa de presentación para respuestas JSON previamente procesadas.