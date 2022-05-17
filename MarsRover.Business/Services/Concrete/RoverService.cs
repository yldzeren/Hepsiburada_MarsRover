using MarsRover.Business.Abstract;
using MarsRover.Business.Concrete;
using MarsRover.Business.Services.Abstract;
using MarsRover.Core.Utilities.Results;
using MarsRover.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace MarsRover.Business.Services.Concrete
{
    public class RoverService : IRoverService
    {
        #region SingletonPattern
        private static readonly Lazy<IRoverService> lazy = new Lazy<IRoverService>(() => new RoverService(), true);
        public static IRoverService Current => lazy.Value;
        #endregion

        private readonly IRoverBusiness _roverBusiness;
        private RoverService()
        {
            _roverBusiness = new RoverBusiness();
        }
        public TransactionResult<IRoverDto> Create(IPlateauDto plateau, string roverPositionText)
        {
            var result = new TransactionResult<IRoverDto>();

            try
            {
                result.ResponseObject = _roverBusiness.Create(plateau, roverPositionText);
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
        public TransactionResult Explore(IRoverDto rover, string commandText)
        {
            var result = new TransactionResult<IRoverDto>();

            try
            {
                _roverBusiness.Explore(rover, commandText);
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
    }
}