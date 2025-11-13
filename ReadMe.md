# SimpleRPG

A lightweight console-based RPG written in C#. Create a character, fight monsters, level up, and progress through increasingly difficult enemies.

## Prerequisites

- .NET 8.0 SDK (or compatible .NET 8 runtime for building and running)
- A terminal (PowerShell recommended on Windows)

## Download

Clone this repository or download the ZIP and extract it:

PowerShell:

```powershell
git clone https://github.com/RoyZone96/SimpleRPG.git
cd "SimpleRPG"
```

Or download and extract the ZIP from the repo page.

## Build

From the project root (where `SimpleRPG.sln` and the `SimpleRPG` folder live), run:

```powershell
cd "D:\Projects\Personal Projects\SimpleRPG"  # adjust path if needed
dotnet build
```

This will produce a DLL under `SimpleRPG/bin/Debug/net8.0/`.

## Run / Play

Use the `dotnet run` command from the project folder to start the game:

```powershell
cd SimpleRPG
dotnet run
```

Gameplay basics:

- Enter your character's name when prompted.
- Choose a class: Warrior, Mage, Cleric, or Ranger.
- Combat is turn-based. When the combat menu appears, type the number for the action you want (e.g. `1` for Attack).
- Special class actions appear in the combat menu when available (Power Strike, Cast Spell, Heal, etc.).

Example session excerpt:

```
Welcome to Simple RPG!
Enter your character's name: Ron
Enter your character's class (Warrior, Mage, Cleric, Ranger): Warrior
A wild Bat appears!
Ron - Health: 100, Level: 1
Bat - Health: 30
What will Ron do?:
1. Attack
2. Power Strike
3. Shield Block
9. Run Away
```

## Troubleshooting

- If build fails, ensure you have the .NET 8 SDK installed and that `dotnet --version` shows a 8.x version.
- If the combat menu doesn't appear, ensure the project is up-to-date and that `Combat.cs` uses `CombatMenu.ShowCombatMenu(...)` for player turns.
- If you encounter errors referencing missing namespaces, make sure source files are in the `SimpleRPG` project and that namespaces are correct (`ClassList` and `MonsterList`).

## Notes for Modders / Developers

- The project is intentionally small and designed to be extended. Add new monsters in `MonsterList/` (implement `IMonster`) and new character features in `ClassList/` (implement `ICharacter`).
- Monster behavior can be customized with `TakeTurn` methods in each monster class.

## License

This repository uses the default project license (check repository root for LICENSE). If none exists, consider adding one.

## Contact

If you have questions or want to contribute, open an issue or a pull request on the GitHub repo.
