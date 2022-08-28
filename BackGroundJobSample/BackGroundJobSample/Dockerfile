FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BackGroundJobSample/BackGroundJobSample.csproj", "BackGroundJobSample/"]
RUN dotnet restore "BackGroundJobSample/BackGroundJobSample.csproj"
COPY . .
WORKDIR "/src/BackGroundJobSample"
RUN dotnet build "BackGroundJobSample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackGroundJobSample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackGroundJobSample.dll"]
