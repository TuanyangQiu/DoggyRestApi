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
            _mapper ??= new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TouristRouteProfile());
                mc.AddProfile(new TouristRoutePictureProfile());
            }).CreateMapper();
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


        [TestMethod]
        public async Task GetTouristRouteById_WithNonExistentTouristRouteId_ReturnNotFound()
        {
            //Arrange
            TouristRoutesController controller = _touristRoutesController;
            _mockTouristRouteRepo.Reset();
            _mockTouristRouteRepo.Setup(x => x.GetTouristRouteByIdAsync(_mockTouristRouteId)).
                                               ReturnsAsync(new TouristRoute()
                                               {
                                                   Id = _mockTouristRouteId,
                                               });

            Guid nonExistenTouristRouteId = Guid.NewGuid();

            //Act
            IActionResult result = await controller.GetTouristRouteById("", nonExistenTouristRouteId, "");

            //Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }

        /// <summary>
        /// If the fields is null, should response all fields
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetTouristRouteById_NotSpecifyFields_ReturnTouristRoute_WithAllFields()
        {
            //Arrange
            TouristRoutesController controller = _touristRoutesController;
            _mockTouristRouteRepo.Reset();
            _mockTouristRouteRepo.Setup(x => x.GetTouristRouteByIdAsync(_mockTouristRouteId)).
                                               ReturnsAsync(new TouristRoute()
                                               {
                                                   Id = _mockTouristRouteId,
                                                   Title = "Lakes and Mountains - Salzburg, Lake Wolfgang",
                                                   Description = "Immerse yourself in the beauty of Austria's lakes and mountains on this 6-day tour.  ",
                                                   OriginalPrice = 1234m,
                                                   DiscountPercent = 0.8,
                                                   CreateTime = DateTime.UtcNow,
                                                   Features = "Guided tours, Accommodation in lakeside hotels, Transportation within Austria",
                                                   Notes = "Airfare not included, Valid passport required",
                                                   Fees = "Entrance fees to attractions, Meals included",
                                                   TouristRoutePictures = new List<TouristRoutePicture>(),
                                                   Rating = 4.7,
                                                   TravelDays = TravelDays.Four,
                                                   TripType = TripType.BackPackTour,
                                                   DepartureCity = DepartureCity.Canton
                                               });

            List<string> allFields = new List<string>() { "Id","Title", "Description", "Price" , "CreateTime", "Notes",
                                                             "Features",  "Fees", "TouristRoutePictures", "Rating" ,
                                                               "TravelDays","TripType","DepartureCity" };

            //Act
            IActionResult result = await controller.GetTouristRouteById("", _mockTouristRouteId, null);


            //Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var expObject = (result as OkObjectResult)?.Value as ExpandoObject;
            IDictionary<string, object>? dictExpObj = expObject as IDictionary<string, object>;
            Assert.IsNotNull(dictExpObj);

            //whether returns all fields
            foreach (var i in allFields)
                Assert.IsTrue(dictExpObj.ContainsKey(i));

        }

        /// <summary>
        /// specified fields should be fully returned
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetTouristRouteById_ReturnTouristRoute_WithSpecifiedFields()
        {
            //Arrange
            TouristRoutesController controller = _touristRoutesController;
            _mockTouristRouteRepo.Reset();
            _mockTouristRouteRepo.Setup(x => x.GetTouristRouteByIdAsync(_mockTouristRouteId)).
                                               ReturnsAsync(new TouristRoute()
                                               {
                                                   Id = _mockTouristRouteId,
                                                   Title = "Lakes and Mountains - Salzburg, Lake Wolfgang",
                                                   Description = "Immerse yourself in the beauty of Austria's lakes and mountains on this 6-day tour.  ",
                                                   OriginalPrice = 1234m,
                                                   DiscountPercent = 0.8,
                                                   CreateTime = DateTime.UtcNow,
                                                   Features = "Guided tours, Accommodation in lakeside hotels, Transportation within Austria",
                                                   Notes = "Airfare not included, Valid passport required",
                                                   Fees = "Entrance fees to attractions, Meals included",
                                                   TouristRoutePictures = new List<TouristRoutePicture>(),
                                                   Rating = 4.7,
                                                   TravelDays = TravelDays.Four,
                                                   TripType = TripType.BackPackTour,
                                                   DepartureCity = DepartureCity.Canton
                                               }); ;
            string expectedFields = "Title,Description,Features";


            //Act
            IActionResult result = await controller.GetTouristRouteById("", _mockTouristRouteId, expectedFields);


            //Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var expObject = (result as OkObjectResult)?.Value as ExpandoObject;
            IDictionary<string, object>? dictExpObj = expObject as IDictionary<string, object>;
            Assert.IsNotNull(dictExpObj);

            //whether the response body contains the expected fields
            Assert.IsTrue(dictExpObj.ContainsKey("Title"));
            Assert.IsTrue(dictExpObj.ContainsKey("Description"));
            Assert.IsTrue(dictExpObj.ContainsKey("Features"));
        }


        /// <summary>
        /// only specified fields can be returned, other fields should not be returned
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetTouristRouteById_OnlyReturnTouristRoute_WithSpecifiedFields()
        {
            //Arrange
            TouristRoutesController controller = _touristRoutesController;
            _mockTouristRouteRepo.Reset();
            _mockTouristRouteRepo.Setup(x => x.GetTouristRouteByIdAsync(_mockTouristRouteId)).
                                               ReturnsAsync(new TouristRoute()
                                               {
                                                   Id = _mockTouristRouteId,
                                                   Title = "Lakes and Mountains - Salzburg, Lake Wolfgang",
                                                   Description = "Immerse yourself in the beauty of Austria's lakes and mountains on this 6-day tour.  ",
                                                   OriginalPrice = 1234m,
                                                   DiscountPercent = 0.8,
                                                   CreateTime = DateTime.UtcNow,
                                                   Features = "Guided tours, Accommodation in lakeside hotels, Transportation within Austria",
                                                   Notes = "Airfare not included, Valid passport required",
                                                   Fees = "Entrance fees to attractions, Meals included",
                                                   TouristRoutePictures = new List<TouristRoutePicture>(),
                                                   Rating = 4.7,
                                                   TravelDays = TravelDays.Four,
                                                   TripType = TripType.BackPackTour,
                                                   DepartureCity = DepartureCity.Canton
                                               }); ;
            string expectedFields = "Title,Description,Features";
            List<string> unexptedFields = new List<string>() { "Id", "Price" , "CreateTime", "Notes",
                                                               "Fees", "TouristRoutePictures", "Rating" ,
                                                               "TravelDays","TripType","DepartureCity"};

            //Act
            IActionResult result = await controller.GetTouristRouteById("", _mockTouristRouteId, expectedFields);


            //Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var expObject = (result as OkObjectResult)?.Value as ExpandoObject;
            IDictionary<string, object>? dictExpObj = expObject as IDictionary<string, object>;
            Assert.IsNotNull(dictExpObj);

            //whether the response body contains the unexpected fields
            foreach (var i in unexptedFields)
            {
                Assert.IsFalse(dictExpObj.ContainsKey(i));
            }
        }


        /// <summary>
        /// if some of fields does not existed in model 'TouristRoute', then only return those existed fields
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetTouristRouteById_OnlyReturnTouristRoute_WithExistentSpecifiedFields()
        {
            //Arrange
            TouristRoutesController controller = _touristRoutesController;
            _mockTouristRouteRepo.Reset();
            _mockTouristRouteRepo.Setup(x => x.GetTouristRouteByIdAsync(_mockTouristRouteId)).
                                               ReturnsAsync(new TouristRoute()
                                               {
                                                   Id = _mockTouristRouteId,
                                                   Title = "Lakes and Mountains - Salzburg, Lake Wolfgang",
                                                   Description = "Immerse yourself in the beauty of Austria's lakes and mountains on this 6-day tour.  ",
                                                   OriginalPrice = 1234m,
                                                   DiscountPercent = 0.8,
                                                   CreateTime = DateTime.UtcNow,
                                                   Features = "Guided tours, Accommodation in lakeside hotels, Transportation within Austria",
                                                   Notes = "Airfare not included, Valid passport required",
                                                   Fees = "Entrance fees to attractions, Meals included",
                                                   TouristRoutePictures = new List<TouristRoutePicture>(),
                                                   Rating = 4.7,
                                                   TravelDays = TravelDays.Four,
                                                   TripType = TripType.BackPackTour,
                                                   DepartureCity = DepartureCity.Canton
                                               });
            string existentFields = "Title,Description,Features";
            string nonExistentFields = "AnyFieldName";
            string testFields = $"{existentFields},{nonExistentFields}";

            //Act
            IActionResult result = await controller.GetTouristRouteById("", _mockTouristRouteId, testFields);


            //Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var expObject = (result as OkObjectResult)?.Value as ExpandoObject;
            IDictionary<string, object>? dictExpObj = expObject as IDictionary<string, object>;
            Assert.IsNotNull(dictExpObj);

            //whether the response body contains the existent fields
            Assert.IsTrue(dictExpObj.ContainsKey("Title"));
            Assert.IsTrue(dictExpObj.ContainsKey("Description"));
            Assert.IsTrue(dictExpObj.ContainsKey("Features"));

            //Whether the response body does not contain the nonexistent fields
            Assert.IsFalse(dictExpObj.ContainsKey(nonExistentFields));

        }


        /// <summary>
        /// if all of fields does not existed in model 'TouristRoute', then only return empty body
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetTouristRouteById_ReturnEmptyTouristRoute_IfAllFieldsNotExist()
        {
            //Arrange
            TouristRoutesController controller = _touristRoutesController;
            _mockTouristRouteRepo.Reset();
            _mockTouristRouteRepo.Setup(x => x.GetTouristRouteByIdAsync(_mockTouristRouteId)).
                                               ReturnsAsync(new TouristRoute()
                                               {
                                                   Id = _mockTouristRouteId,
                                                   Title = "Lakes and Mountains - Salzburg, Lake Wolfgang",
                                                   Description = "Immerse yourself in the beauty of Austria's lakes and mountains on this 6-day tour.  ",
                                                   OriginalPrice = 1234m,
                                                   DiscountPercent = 0.8,
                                                   CreateTime = DateTime.UtcNow,
                                                   Features = "Guided tours, Accommodation in lakeside hotels, Transportation within Austria",
                                                   Notes = "Airfare not included, Valid passport required",
                                                   Fees = "Entrance fees to attractions, Meals included",
                                                   TouristRoutePictures = new List<TouristRoutePicture>(),
                                                   Rating = 4.7,
                                                   TravelDays = TravelDays.Four,
                                                   TripType = TripType.BackPackTour,
                                                   DepartureCity = DepartureCity.Canton
                                               });
            string nonExistentFields = "AnyFieldName1,AnyFieldName2";

            //Act
            IActionResult result = await controller.GetTouristRouteById("", _mockTouristRouteId, nonExistentFields);


            //Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var expObject = (result as OkObjectResult)?.Value as ExpandoObject;
            IDictionary<string, object>? dictExpObj = expObject as IDictionary<string, object>;
            Assert.IsNotNull(dictExpObj);


            //Whether the response body does not contain the nonexistent fields
            Assert.IsFalse(dictExpObj.ContainsKey("AnyFieldName1"));
            Assert.IsFalse(dictExpObj.ContainsKey("AnyFieldName2"));

        }


    }
}