# Базовий образ для побудови
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Копіюємо все в контейнер
COPY . .

# Переходимо в папку з проєктом
WORKDIR /app/WebApiSushi

# Встановлюємо залежності
RUN dotnet restore

# Публікуємо додаток
RUN dotnet publish -c Release -o /out

# Базовий образ для запуску
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /app

# Копіюємо збірку з попереднього кроку
COPY --from=build /out .

# Запускаємо API
ENTRYPOINT ["dotnet", "WebApiSushi.dll"]
