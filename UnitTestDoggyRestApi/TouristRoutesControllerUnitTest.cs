namespace UnitTestDoggyRestApi
{
    [TestClass]
    public class TouristRoutesControllerUnitTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<ITouristRouteRepository> _mockTouristRouteRepo;
        private readonly Mock<ILogger<TouristRoutesController>> _mockLogger;
        private readonly Mock<IUrlHelperFactory> _mockUrlHelperFactory;
        private readonly Mock<IActionContextAccessor> _mockActionContextAccessor;
        private readonly Guid _mockTouristRouteId;
        private readonly TouristRoutesController _touristRoutesController;
        public TouristRoutesControllerUnitTest()
        {
            _mapper ??= new MapperConfiguration(mc => mc.AddProfile(new TouristRouteProfile())).CreateMapper();
            _mockTouristRouteRepo = new Mock<ITouristRouteRepository>();
            _mockLogger = new Mock<ILogger<TouristRoutesController>>();
            _mockUrlHelperFactory = new Mock<IUrlHelperFactory>();
            _mockActionContextAccessor = new Mock<IActionContextAccessor>();
            _mockTouristRouteId = Guid.NewGuid();
            _touristRoutesController = GetDefaultTouristRouteControllerInstance();
        }

        private TouristRoutesController GetDefaultTouristRouteControllerInstance()
        {
            return new TouristRoutesController(_mockTouristRouteRepo.Object,
                                                     _mapper,
                                                     _mockLogger.Object,
                                                     _mockUrlHelperFactory.Object,
                                                     _mockActionContextAccessor.Object);
        }


        [TestMethod]
        public async Task GetTouristRouteById_ReturnTouristRoute()
        {
            //Arrange
            TouristRoute expectedTouristRoute = new TouristRoute()
            {
                Id = _mockTouristRouteId,
                Title = "Orientation Bay in Wellington, New Zealand",
                Description = "a stunning bay",
                OriginalPrice = 201m,
                CreateTime = DateTime.UtcNow
            };

            TouristRoutesController controller = _touristRoutesController;
            _mockTouristRouteRepo.Reset();
            _mockTouristRouteRepo.Setup(x => x.GetTouristRouteByIdAsync(_mockTouristRouteId)).
                                         ReturnsAsync(expectedTouristRoute);

            //Act
            IActionResult result = await controller.GetTouristRouteById("", _mockTouristRouteId, "");

            //Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;
            Assert.IsNotNull(okResult.Value as ExpandoObject);
            //var actualExpObject = (okResult.Value as ExpandoObject) as IDictionary<string, object>;
            //Assert.IsTrue(actualExpObject?.ContainsKey("Title"));

            //object? objPriceValue = null;
            //Assert.IsTrue(actualExpObject?.TryGetValue("Price", out objPriceValue));
            //Assert.IsTrue(decimal.TryParse(objPriceValue?.ToString(), out decimal price) && price == 201m);
            //_mockLogger.VerifyLogging("entering GetTouristRouteById", LogLevel.Information);

        }

        [TestMethod]
        public async Task GetTouristRouteById_IdIsEmpty_ReturnBadRequest()
        {
            //Arrange
            TouristRoutesController controller = _touristRoutesController;
            _mockTouristRouteRepo.Reset();
            _mockTouristRouteRepo.Setup(x => x.GetTouristRouteByIdAsync(_mockTouristRouteId)).
                                          ReturnsAsync(new TouristRoute()
                                          {
                                              Id = Guid.Empty,
                                          });

            //Act
            IActionResult result = await controller.GetTouristRouteById("", Guid.Empty, "");

            //Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
    }
}