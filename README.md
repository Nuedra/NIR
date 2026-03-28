# NIR Platform

## Требования

- .NET SDK 8.0 (проверка: `dotnet --version`)
- macOS/Linux/Windows с установленным `dotnet`

## Структура решения

В решении `Platform.sln` есть несколько проектов, точка запуска веб-приложения:

- `Platform.Application` (Blazor Server, основной исполняемый проект)

## Сборка проекта

Из корня репозитория выполните:

```bash
dotnet restore "Platform.sln"
dotnet build "Platform.sln"
```

## Запуск проекта

Запуск из корня репозитория:

```bash
dotnet run --project "Platform.Application/Platform.Application.csproj"
```

После старта приложение доступно по адресу:

- `http://localhost:5284`, если порт 5284 свободен