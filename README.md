# ACMLEM
<i>Actually Competent Monkey Loader Example Mod</i></br>

i originally made this because i couldnt find any example mods that WORKED.
so i made this.

ill also document my setup steps:
1. create a new LOCAL nuget source somewhere, put it into the `Nuget.Config` either in this repo or ur general config
2. don't use visual studio to install the packages, vs is dumb. instead use `dotnet add package <name>` where name is ur package name. (make sure ur cd'd into the `johnresonite` directory, so the config gets applied. also build it at least once so u get 2 new folders, `monkeyloader mods` and `monkeyloader gamepacks`)
3. youll wanna generate the resonite nuget packages. use [this thing i dont understand](https://github.com/MonkeyModdingTroop/ReferencePackageGenerator). build it for release and run it with the args: `resonite.json`, then open `resonite.json` and set `SourcePath` to `where_you_installed_resonite/Resonite_Data/Managed`. ive also found that setting `VersionBoost` to `2.2` can help with some annoyances where people set the wrong version on their copies of the nuget packages. anyway.
4. run that thing again with the same arguments and find the folder called `Packages`, now run `nuget init "path_to_that_folder" "path_to_ur_local_nuget_source"`
5. you can now actually start working on stuff. hopefully, idk. i learnt this an hour ago.

# what this mod actually does lol
it overrides the `AvatarNameTagAssigner` to call everyone `john resonite`. this started as a joke among my friends where we'd say `john` and then the name of a game. i made this mod since i needed to learn ML modding.<br/>
dont expect it to work or for me to release anything official.
