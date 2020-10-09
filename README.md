## ninja-manager
### Generate migrations
```bash
cd NinjaManager.Domain/
dotnet ef migrations add InitialCreate --startup-project ../NinjaManager.Presentation
```

### Run migrations
```bash
cd NinjaManager.Domain/
dotnet ef database update --startup-project ../NinjaManager.Presentation
```

### Scaffold code
```bash
cd NinjaManager.Presentation/
dotnet aspnet-codegenerator controller -name NinjaController -m Ninja -dc DatabaseContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries
```
