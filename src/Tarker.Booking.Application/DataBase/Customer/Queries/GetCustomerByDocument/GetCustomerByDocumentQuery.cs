using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.DataBase.Customer.Queries.GetCustomerByDocument
{
    public class GetCustomerByDocumentQuery : IGetCustomerByDocumentQuery
    {
        private readonly IDataBaseService _db;
        private readonly IMapper _mapper;
        /// <summary>
        /// Constructor DI.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="mapper"></param>
        public GetCustomerByDocumentQuery(IDataBaseService db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        /// <summary>
        /// This method is used to get customer by document number.
        /// </summary>
        /// <param name="documentNumber"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<GetCustomerByDocumentModel> Execute(string documentNumber)
        {
            try
            {
                return _mapper.Map<GetCustomerByDocumentModel>(await _db.Customer.FirstOrDefaultAsync(c => c.DocumentNumber == documentNumber));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex?.Message);
            }
        }
    }
}
