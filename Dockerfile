# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

#Copy csproj and restore as distinct layer
COPY url/*.sln .
COPY url/*.csproj .
# RUN dotnet restore

#Copy everything else and build app
COPY url/. .
# WORKDIR /source/url
RUN dotnet publish "UrlCreation.csproj" -c release -o /app

#Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
# ENV ASPNETCORE_URLS http://*:80
ENTRYPOINT ["dotnet", "UrlCreation.dll"]