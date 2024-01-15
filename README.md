# Тестовое задание для Versta24

## Запуск проекта

1. Скачать и установить [.Net Core SDK 8](https://dotnet.microsoft.com/en-us/download)
2.  Если на вашей системе нет sqlite, то скачать и установить [Sqlite](https://www.sqlite.org/download.html)
3. Cклонировать проект:
```shell
git clone https://github.com/m0u5/Versta24Test.git
cd Versta24Test/Versta24.Backend/Versta24.WebApi

```
4. находясь в папке Versta24Test/Versta24.Backend/Versta24.WebApi ввести команды для запуска сервера (backEnd): 
```shell
dotnet build
dotnet run 
```
- Документация к webApi будет доступна по адресу: https://localhost:7018/swagger

5. для запуска клиента открыть терминал в директории ./Versta24/Versta24.Client

- Ввести команды в консоли: 
```shell
npm install
npm start
```
- Клиент будет доступен по ссылке: https://localhost:3000/