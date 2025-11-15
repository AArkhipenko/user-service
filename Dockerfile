# Образ для сборки
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
# Копирование сборки
COPY ./publish/ ./
# Запуск приложения
ENTRYPOINT ["dotnet", "User.Service.API.dll"]