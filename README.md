# gala-wars

# General
- Unity version `2021.3.5`
- Zenject as DI.
- All configuration are extracted into config files
- For UI animation I used DOTween
- Enemies and player are spawned in runtime
- Data stored in json files `Application.persistentDataPath` check `AbstractSerializableController.cs`


# Configuration
You can configure Bullets, Ships, Level in Resources/GameStateScriptableInstaller
<img width="1039" alt="image" src="https://user-images.githubusercontent.com/6231331/178290397-289a7527-463a-4c52-a86a-154b4c5c766a.png">

# Entry Point
The Entry point of code is `ProjectInstaller`. Also in `Scripts/Game/Controllers` you will find main controllers of the game.

# Movement System 
You will find movement system under `Scripts/Game/Movement`. `AbstractMovementSystem` and `AbstractCombatSystem` are using State pattern. AI for enemies could be implemented in much more better way.


# Known problems
- Resource loading could be handled in much better way like `Addressable`, or at least must be added some abstract load layer. (Didnt have much time)
- Passing `ShipDto` to Movement system, maybe could be done better



