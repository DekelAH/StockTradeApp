﻿using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using ServiceContracts.View_Models;
using StocksApp.Controllers;
using StocksApp.OptionsModels;
using StocksApp.ServiceContracts;

namespace UnitTesting
{
    public class StocksControllerTest
    {
        #region Fields

        private readonly ILogger<StocksController> _logger;
        private readonly IFinnhubGetterService _finnhubGetterService;
        private readonly Mock<IFinnhubGetterService> _finnhubGetterServiceMock;
        private readonly Mock<ILogger<StocksController>> _loggerMock;
        private readonly IFixture _fixture;

        #endregion

        #region Ctors

        public StocksControllerTest()
        {
            _fixture = new Fixture();
            _loggerMock = new Mock<ILogger<StocksController>>();
            _finnhubGetterServiceMock = new Mock<IFinnhubGetterService>();
            _finnhubGetterService = _finnhubGetterServiceMock.Object;
            _logger = _loggerMock.Object;
        }

        #endregion

        #region Test Methods

        [Fact]
        public async Task Explore_SymbolAsNull_ReturnSameStockList()
        {
            //Arrange
            IOptions<TradingOptions> tradingOptions = Options.Create(new TradingOptions()
            {
                DefaultOrderQuantity = "100",
                Top25PopularStocks = "AAPL,MSFT,AMZN,TSLA,GOOGL,GOOG,NVDA,BRK.B,META,UNH,JNJ,JPM,V,PG,XOM,HD,CVX,MA,BAC,ABBV,PFE,AVGO," +
              "COST,DIS,KO"
            });

            StocksController stocksController = new StocksController(tradingOptions, _finnhubGetterService, _logger);

            List<Dictionary<string, object>>? stocksDict = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, object>>>
                (@"[{'currency':'USD','description':'APPLE INC','displaySymbol':'AAPL','figi':'BBG000B9XRY4','isin':null,'mic':'XNAS','shareClassFIGI':'BBG001S5N8V8','symbol':'AAPL','symbol2':'','type':'Common Stock'}, 
                    {'currency':'USD','description':'MICROSOFT CORP','displaySymbol':'MSFT','figi':'BBG000BPH459','isin':null,'mic':'XNAS','shareClassFIGI':'BBG001S5TD05','symbol':'MSFT','symbol2':'','type':'Common Stock'}, 
                    {'currency':'USD','description':'AMAZON.COM INC','displaySymbol':'AMZN','figi':'BBG000BVPV84','isin':null,'mic':'XNAS','shareClassFIGI':'BBG001S5PQL7','symbol':'AMZN','symbol2':'','type':'Common Stock'}, 
                    {'currency':'USD','description':'TESLA INC','displaySymbol':'TSLA','figi':'BBG000N9MNX3','isin':null,'mic':'XNAS','shareClassFIGI':'BBG001SQKGD7','symbol':'TSLA','symbol2':'','type':'Common Stock'}, 
                    {'currency':'USD','description':'ALPHABET INC-CL A','displaySymbol':'GOOGL','figi':'BBG009S39JX6','isin':null,'mic':'XNAS','shareClassFIGI':'BBG009S39JY5','symbol':'GOOGL','symbol2':'','type':'Common Stock'}]");

            _finnhubGetterServiceMock.Setup(method => method.GetStocks()).ReturnsAsync(stocksDict);

            var expectedStocks = stocksDict!
              .Select(temp => new Stock() { StockName = Convert.ToString(temp["description"]), StockSymbol = Convert.ToString(temp["symbol"]) })
             .ToList();

            //Act
            IActionResult result = await stocksController.Explore(null, true);

            //Assert
            ViewResult viewResult = Assert.IsType<ViewResult>(result);

            viewResult.ViewData.Model.Should().BeAssignableTo<IEnumerable<Stock>>();
            viewResult.ViewData.Model.Should().BeEquivalentTo(expectedStocks);
        }

        #endregion
    }
}
