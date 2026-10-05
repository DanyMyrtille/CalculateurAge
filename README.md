# CalculateurAge — TP1 : Routing et MVVM

Application .NET MAUI (.NET 8, Android) de calcul d'âge.

- **Phase A** : application en code-behind
- **Phase B** : 2e page, navigation Shell et passage de paramètres (nom, date)
- **Phase C** : réécriture en MVVM (ViewModels, binding, injection de dépendances)
- **Activité 6** : jours vécus / jour de naissance / signe du zodiaque, historique, partage, thème sombre

## Compiler
```
dotnet workload install maui-android
dotnet build -f net8.0-android
dotnet build -t:Run -f net8.0-android
```
