using Microsoft.Extensions.Options;
using betting.soccer.scores.api;

using Xunit;
using betting.soccer.scores.api.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using AutoMapper;
using System.Threading.Tasks;
using Moq;
using betting.soccer.scores.api.Domains.SoccerGameService.SoccerGamePage;
using betting.soccer.scores.Tests.Mocks;
using betting.soccer.scores.api.Domains.SoccerTeamService.SoccerTeamPage;
using betting.soccer.scores.api.Domains.UserService.AuthorizationEntity;
using System;

namespace betting.soccer.scores.Tests;

public class SoocerGamerTest{
    


    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public Task MockRegisterSoocerGame(bool isResult)
    {
        ///Se crea Mock de la nterface Applicacition IRegisterSoccerGame
        var _agentMock = new Mock<IRegisterSoccerGame>();

        //Especifica una configuraci�n en el tipo simulado para una llamada a un no vac�o (retorno de valor)
        //Expresi�n lambda que especifica la invocaci�n del m�todo.
        _agentMock.Setup(m => m.RegisterSoccerGameAsync(SoccerGameMocks.SoccerGameMock())).Returns(SoccerGameMocks.returnChangesAsync());

        //Mock de "Set" para el envi� de parametros en la entidad "SoccerGame"
        var _mockSet = new Mock<DbSet<SoccerGame>>();
        var _mockContext = new Mock<SqlServerDataContext>();
        _mockContext.Setup(m => m.SoccerGames).Returns(_mockSet.Object);

        //Mock de "Interfaces" para el envi� de parametros en la interface "IMapper"
        Mock<IMapper> _mockIMapper = new Mock<IMapper>();
        _mockIMapper.Setup(m => m.Map<SoccerGame, SoccerGameResponse>
        (It.IsAny<SoccerGame>())).Returns(SoccerGameMocks.SoccerGameResponse);

        //Mock de "Interfaces" para el envi� de parametros en la interface "IJwtUtils"
        Mock<IJwtUtils> _mockIJwtUtils = new Mock<IJwtUtils>();
        //Mock de clase "Interfaces"  para el envi� de parametros en la interface "IRegisterSoccerGame"
        Mock<IRegisterSoccerGame> _mockIGenerics = new Mock<IRegisterSoccerGame>();
        //Mock de clase "Interfaces"  para el envi� de parametros en la interface "ISoccerGame"
        Mock<ISoccerGame> _mockISoccerGame = new Mock<ISoccerGame>();
        //Mock de clase "Interfaces"  para el envi� de parametros en la interface "ISoccerTeam"
        Mock<ISoccerTeam> _mockISoccerTeam = new Mock<ISoccerTeam>();
        //Cargar de "SoccerGameProcessor" con los mocks de las "Interfaces" para la implementaci�n de las pruebas
        SoccerGameProcessor soccerGameProcessor = new SoccerGameProcessor(_mockIMapper.Object,
            _mockIJwtUtils.Object,          
            _agentMock.Object,
            _mockISoccerGame.Object,
            _mockISoccerTeam.Object);

        //Llamado al m�todo "RegisterSoccerGameAsync" DomainService
        //Al envirse en el mock "_agentMock" en la instancia, esta cosumira
        //Metodo y su resultado sera con la data mokeada en el m�todo "RegisterSoccerGameAsync(isResult)"
        var request = soccerGameProcessor.RegisterSoccerGameAsync(SoccerGameMocks.SoccerGameResponse(isResult));

        //Evaluaci�n del resultado esperado //Se realiza dos ingresos al m�tdo
        //1: Con reultados positivos //2: Con reultados negativos
        Assert.True(!request.Result.Items.Equals(SoccerGameMocks._indicateError));
        return Task.FromResult(request);
    }
}