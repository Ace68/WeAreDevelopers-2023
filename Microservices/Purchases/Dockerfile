FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY . .
# COPY "Brewup.Purchases.Rest/Brewup.Purchases.Rest.csproj" "src/Brewup.Purchases.Rest/Brewup.Purchases.Rest/"
# COPY "Brewup.Purchases.ApplicationService/Brewup.Purchases.ApplicationService.csproj" "Brewup.Purchases.ApplicationService/"
# COPY "Brewup.Purchases.Messages/Brewup.Purchases.Messages.csproj" "Brewup.Purchases.Messages/"
# COPY "Brewup.Purchases.SharedKernel/Brewup.Purchases.SharedKernel.csproj" "Brewup.Purchases.SharedKernel/"

RUN dotnet restore "Purchases/Brewup.Purchases.Rest/Brewup.Purchases.Rest.csproj"
COPY . .
WORKDIR "/src/Purchases/Brewup.Purchases.Rest"
RUN dotnet build "Brewup.Purchases.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Brewup.Purchases.Rest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Brewup.Purchases.Rest.dll"]