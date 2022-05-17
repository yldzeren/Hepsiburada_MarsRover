using MarsRover.Business.Services.Concrete;
using MarsRover.Entities.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Tests
{

    [TestClass]
    public class PlateauTest
    {
        private IPlateauDto plateauDto;

        [TestInitialize]
        public void Initialize()
        {
            plateauDto = null;
        }

        [TestMethod("Create Plateau")]
        [DataRow("5 5", DisplayName = "Plateau width and height")]
        public void IsPlateauCreate(string plateauSizeText)
        {
            var plateauServiceResult = PlateauService.Current.Create(plateauSizeText);
            plateauDto = plateauServiceResult.ResponseObject;
            Assert.IsTrue(plateauServiceResult.IsSuccess, plateauServiceResult.Message);
        }

        [TestMethod("Validation Plateau")]
        [DataRow("55", DisplayName = "Plateau width and height wrong!")]
        public void HandleValidationException(string plateauSizeText)
        {
            var plateauServiceResult = PlateauService.Current.Create(plateauSizeText);
            Assert.IsFalse(plateauServiceResult.IsSuccess, plateauServiceResult.Message);
            Assert.AreEqual(plateauServiceResult.Message, $"{plateauSizeText} is not matched.");
        }
    }
}