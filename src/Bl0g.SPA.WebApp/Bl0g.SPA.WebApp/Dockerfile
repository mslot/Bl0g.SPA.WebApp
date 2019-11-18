FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Bl0g.SPA.WebApp/Bl0g.SPA.WebApp.csproj", "Bl0g.SPA.WebApp/"]
RUN dotnet restore "Bl0g.SPA.WebApp/Bl0g.SPA.WebApp.csproj"
COPY . .
WORKDIR "/src/Bl0g.SPA.WebApp"
RUN dotnet build "Bl0g.SPA.WebApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Bl0g.SPA.WebApp.csproj" -c Release -o /app

FROM base AS copy
WORKDIR /app
COPY --from=publish /app /app/minimal

FROM nginx:alpine as final
COPY --from=copy /app/minimal /usr/share/nginx/html/
COPY Bl0g.SPA.WebApp/nginx.conf /etc/nginx/nginx.conf