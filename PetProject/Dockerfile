
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY PetProject/*.sln ./
COPY PetProject/*.csproj ./PetProject/
RUN dotnet restore "PetProject/PetProject.csproj"

WORKDIR "/src/PetProject"
COPY . .
RUN dotnet build "PetProject/PetProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PetProject/PetProject.csproj" -c Release -o /app/publish

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PetProject.dll"]

