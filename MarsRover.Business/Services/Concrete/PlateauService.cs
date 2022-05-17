using MarsRover.Business.Abstract;
using MarsRover.Business.Concrete;
using MarsRover.Business.Services.Abstract;
using MarsRover.Core.Utilities.Results;
using MarsRover.Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MarsRover.Business.Services.Concrete
{
    public class PlateauService : IPlateauService
    {
        #region SingletonPattern
        private static readonly Lazy<IPlateauService> lazy = new Lazy<IPlateauService>(() => new PlateauService(), true);
        public static IPlateauService Current => lazy.Value;
        #endregion

        private readonly IPlateauBusiness _plateauBusiness;
        private PlateauService()
        {
            _plateauBusiness = new PlateauBusiness();
        }
        public TransactionResult<IPlateauDto> Create(string widthHeightText)
        {
            var result = new TransactionResult<IPlateauDto>();

            try
            {
                result.ResponseObject = _plateauBusiness.Create(widthHeightText);
                result.SetStatusSucceeded("Transaction succeed.");
            }
            catch (ValidationException ve)
            {
                result.SetStatusValidationException(ve.Message);
            }
            catch (Exception ex)
            {
                result.SetStatusUnhandledException(ex);
            }

            return result;
        }

        public TransactionResult<string> DisplayText(IPlateauDto plateau)
        {
            var result = new TransactionResult<string>();
            StringBuilder textBuilder = new StringBuilder();
            int i = 1;
            foreach (var rover in plateau.Rovers)
            {
                textBuilder.Append("Rover" + i + ": ");
                textBuilder.AppendLine(rover.Position.ToString());
                i++;
            }
            result.ResponseObject = textBuilder.ToString();
            result.SetStatusSucceeded("Transaction succeed.");
            return result;
        }
    }
}
