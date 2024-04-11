using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers
{
    public class GetAllBrandsHandler : IRequestHandler<GetAllBrandsQuery, IList<BrandResponse>>
    {
        private readonly IBrandRepsository _brandRepsository;
        private readonly IMapper _mapper;

        public GetAllBrandsHandler(IBrandRepsository brandRepsository, IMapper mapper)
        {
            _brandRepsository = brandRepsository;
            _mapper = mapper;
        }
        public async Task<IList<BrandResponse>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var brandList = await _brandRepsository.GetAllBrands();
            var brandReponseList = _mapper.Map<IList<BrandResponse>>(brandList);
            return brandReponseList;
        }
    }
}
