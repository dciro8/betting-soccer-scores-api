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
 * Se generan 2 tipos de pruebas, una con resultado positivo y la otra con un resultado controlado
 * 




