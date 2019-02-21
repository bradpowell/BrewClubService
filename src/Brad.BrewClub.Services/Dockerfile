FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
COPY src/Brad.BrewClub.Servicesbin/Release/netcoreapp2.2/publish /app .
ENTRYPOINT ["dotnet", "Brad.BrewClub.Services.dll"]