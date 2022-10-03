
# Prueba Técnica Apuestas en Línea Campeonato Mundial

## Historias de Usuario

1. Carga de partidos
  -----------------
- Tables
-----------------
# SoccerTeam
  Id: guid
  Code: string
  Name: string

SoccerTeam
  Id: guid
  Code: string
  Name: string
-----------------
- DTOs
-----------------
# SoccerGameRegisterRequest
  GameDate: DateTime
  TeamAId: Guid
  TeamBId: Guid

# SoccerGameUpdateRequest
  GameDate: DateTime
  TeamAId: Guid
  TeamAScore: : byte --> 2
  TeamBId: Guid
  TeamBScore: byte   --> 1  
  Status: Enum       --> Programado / Parcial / Final

# OperationResponse
  StatusCode: int    --> 200 / 500 / 400
  StatusText: string --> Registered / Updated / Error
  Message: string    --> Null / Error message

-----------------
- Controllers
-----------------
# SoccerTeam
GET / --> GetAllSoccerGameAsync
POST / --> RegisterSoccerTeamAsync
DELETE/ --> DeleteSoccerTeamAsync

# SoccerGame
POST / --> Insert
  # SoccerGameRegisterRequest
  * Validar TeamAId que exista
  * Validar TeamBId que exista
  * Validar cruce de fechas
    1. El TeamAId, TeamBId no tengan otro partido en esa fecha
    2. Que la combinación TeamAId, TeamBId y GateDate no exista
  * Validar que la fecha no sea diferente al día de hoy

PUT / --> Update
  # SoccerGameUpdateRequest
  * Validar TeamAId que exista
  * Validar TeamBId que exista
  * Validar cruce de fechas
    1. El TeamAId, TeamBId no tengan otro partido en esa fecha
    2. Que la combinación TeamAId, TeamBId y GateDate no exista
  * Validar que la fecha no sea diferente al día de hoy
  * Validar que los resultados no sean negativos
  * Validar el estado del partido
  
3. Registro de sesión
4. Registro de apuestas
5. Resultado de apuestas 

# 6. Implementación de prueba initarias con Framework Xunit para verificación de calidad en metodos con datos simulados Mocks
 * Verifiar Proyecto # betting.soccer.scores.Tests   
 * Clase SoocerGamerTest
 * Se generan 2 tipos de pruebas para nserción de nuevos juegos, una con resultado positivo y la otra con un resultado controlado
 # * Objetivo de la prueba:
 * Ejecuión rápida
 * Rápida programación
 * No depende de otros elementos

# 7. Arquitectura y buenas practicas 
  * Se implmenta principios SOLID objetivamente los puntos:
  * S:Principio de responsabildiad Única: Se implementan resposabidiades Únicas para cada necesidad
  * O:Principio de Abierto o cerrado: Se realizan pruebas unitarias que trabajan sobre estructuras ya construidas, sin la posibildiad de ser modificadas mas con la posibilidad de crear nuevas funcionalidades
  * I: Principio de segregación de interfaces: Se realiza implementación de pequeas interfaces y no una generica que contenga todas las implementaciones
  * D: Principio de inversión de dependecia: Implementación de clases de alto------------
  # * Implementación Patron inyección de depndencias 

# 8. Arquitectura
  * Se implementa el patron Mediator para reducir las dependencis entre objetos, agilidad en la codificación y restrige la comunicación directa entre los objetos, se implementa un objeto mediador para redireccionar todo a esta clase.
  # * Implemetación de POO logrando:
  * Encapsulamiento
  * Abstracción
  * Herencia
  * Poliformismo
  

# 9 Estandares de codificación
* Se realiza implementación de estandares para el apoyo en los sigiuentes puntos:
* Disminución de errores
* Mantenimiento de Código estruturado
* Mantenmiento de Código escrito
* Performance de la aplicación



