# Образ для сборки
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
# Копирование сборки
COPY ./src/User.Service.API/bin/Release/net*/ ./
# Запуск приложения
ENTRYPOINT ["dotnet", "User.Service.API.dll"]