# GamePPT_Api

Proyecto DAW que combina una **aplicación de consola en C#** con una **API REST en Node.js
(Express)** para simular un **juego de batallas Pokémon 1 vs 1**.


## ⚙️ Requisitos

- Node.js (LTS recomendado)
- .NET SDK
- Git

---

## 🚀 Cómo ejecutar el proyecto

### 1️⃣ Clonar el repositorio

```bash
git clone <url-del-repositorio>
cd GamePPT_Api
```

### 2️⃣ Iniciar la API (Node.js)

```bash
cd src/api
npm install
node server.js
```

La API se ejecuta en `http://localhost:4000`.

### 3️⃣ Ejecutar la aplicación de consola (C#)

```bash
dotnet run
```

---

## 🎮 Funcionamiento del juego

- **Nuevo Juego**
  - Restaura los Pokémon desde `pokemons.backup.json`
  - Selección del Pokémon del jugador
  - Selección aleatoria del Pokémon CPU
  - El jugador comienza con **3 vidas**

- **Combate**
  - Batalla 1 vs 1
  - Si el jugador pierde → pierde **1 vida**
  - Si el jugador gana → el Pokémon CPU se elimina de la API
  - El Pokémon del jugador **no se elimina** al perder

- **Game Over**
  - Cuando las vidas del jugador llegan a 0
  - Finaliza el juego

- **Partida Guardada**
  - El estado se guarda en `savegame.json`
  - Permite continuar una partida anterior

---

## 🔒 Sistema de backup

- `pokemons.backup.json` contiene el estado original del juego
- La API nunca destruye permanentemente los datos
- Cada **Nuevo Juego** restaura automáticamente los Pokémon

---

## 🧪 Buenas prácticas

- Separación entre lógica de juego, API y persistencia
- Control de flujo en consola sin excepciones para lógica normal
- Uso de `.gitignore` (no se suben `node_modules`, `bin`, `obj`, `.vs`)
- Arquitectura válida y defendible en DAW

---

## 📌 Nota

Proyecto con fines educativos orientado a prácticas reales de integración entre
**C#** y **API REST**, siguiendo criterios profesionales evaluables en DAW.
