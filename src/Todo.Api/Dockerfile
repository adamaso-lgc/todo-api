FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 6000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Todo.Api/Todo.Api.csproj", "src/Todo.Api/"]
COPY ["src/Todo.Application/Todo.Application.csproj", "src/Todo.Application/"]
COPY ["src/Todo.Domain/Todo.Domain.csproj", "src/Todo.Domain/"]
COPY ["src/Todo.Infra/Todo.Infra.csproj", "src/Todo.Infra/"]
RUN dotnet restore "src/Todo.Api/Todo.Api.csproj"
COPY . .
WORKDIR "/src/src/Todo.Api"
RUN dotnet build "Todo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Todo.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Todo.Api.dll"]
