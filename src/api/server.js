const express = require("express");
const fs = require("fs");
const path = require("path");

const app = express();
app.use(express.json());

const DATA_PATH = path.join(__dirname, "../json/pokemons.json");
const BACKUP_PATH = path.join(__dirname, "../json/pokemons.backup.json");


// UTILIDADES
function loadPokemons() {
    return JSON.parse(fs.readFileSync(DATA_PATH, "utf8"));
}

function savePokemons(data) {
    fs.writeFileSync(DATA_PATH, JSON.stringify(data, null, 2));
}


//  NUEVO: RESTAURAR DESDE BACKUP
function restoreFromBackup() {
    const backup = JSON.parse(fs.readFileSync(BACKUP_PATH, "utf8"));
    savePokemons(backup);
    console.log("Pokemons restaurados desde backup");
}


// ENDPOINTS

// GET todos
app.get("/pokemons", (req, res) => {
    res.json(loadPokemons());
});

// DELETE por id
app.delete("/pokemons/:id", (req, res) => {
    const id = parseInt(req.params.id);
    let pokemons = loadPokemons();

    const index = pokemons.findIndex(p => p.id === id);
    if (index === -1) {
        return res.status(404).json({ message: "Pokemon no encontrado" });
    }

    pokemons.splice(index, 1);
    savePokemons(pokemons);

    res.json({ message: "Pokemon eliminado" });
});

//  NUEVO ENDPOINT: RESET GAME
app.post("/reset", (req, res) => {
    restoreFromBackup();
    res.json({ message: "Juego reiniciado correctamente" });
});


//  SERVER START
app.listen(4000, () => {
    console.log("API Pokemon corriendo en http://localhost:4000");
});
