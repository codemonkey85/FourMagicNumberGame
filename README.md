# FourMagicNumberGame

Four is the magic number!

Requires the .NET 11 SDK selected by `global.json` and the WebAssembly tools workload:

```sh
dotnet workload install wasm-tools
dotnet build FourMagicNumberGame.sln
dotnet test FourMagicNumberGame.sln --configuration Release
dotnet run --project FourMagicNumberGame
```

[![Deploy to GitHub Pages](https://github.com/codemonkey85/FourMagicNumberGame/actions/workflows/main.yml/badge.svg)](https://github.com/codemonkey85/FourMagicNumberGame/actions/workflows/main.yml)

Deployed to GitHub Pages: [https://codemonkey85.github.io/FourMagicNumberGame/](https://codemonkey85.github.io/FourMagicNumberGame/)
