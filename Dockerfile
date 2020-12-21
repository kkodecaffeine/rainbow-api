#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
ARG ASPNETCORE_ENVIRONMENT
ARG AWS_DEFAULT_REGION
ARG AWS_ACCESS_KEY_ID
ARG AWS_SECRET_ACCESS_KEY

ENV ASPNETCORE_ENVIRONMENT=${ASPNETCORE_ENVIRONMENT:-Production}
ENV AWS_DEFAULT_REGION=${AWS_DEFAULT_REGION:-AP-NORTHEAST-2}
ENV AWS_ACCESS_KEY_ID=${AWS_ACCESS_KEY_ID}
ENV AWS_SECRET_ACCESS_KEY=${AWS_SECRET_ACCESS_KEY}

WORKDIR /app

EXPOSE 8080
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["RainbowApp.Api/RainbowApp.Api.csproj", "RainbowApp.Api/"]
COPY ["RainbowApp.Application/RainbowApp.Application.csproj", "RainbowApp.Application/"]
COPY ["RainbowApp.Core/RainbowApp.Core.csproj", "RainbowApp.Core/"]
COPY ["RainbowApp.Infrastructure/RainbowApp.Infrastructure.csproj", "RainbowApp.Infrastructure/"]
RUN dotnet restore "RainbowApp.Api/RainbowApp.Api.csproj"
COPY . .
WORKDIR "/src/RainbowApp.Api"
RUN dotnet build "RainbowApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RainbowApp.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://*:8080
ENTRYPOINT ["dotnet", "RainbowApp.Api.dll"]