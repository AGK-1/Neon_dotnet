FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Укажите правильный путь к файлу проекта
COPY SQLE_sam/SQLE-sam.csproj ./
RUN dotnet restore

# Копируем остальные файлы проекта
COPY SQLE_sam/ ./
RUN dotnet publish -c Release -o out

# Образ для запуска
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT ["dotnet", "SQLE-sam.dll"]
