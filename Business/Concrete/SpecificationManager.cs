using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete.SuccessResults;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.SpecificationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SpecificationManager : ISpecificationService
    {
        private readonly ISpecificationDAL _specificationDAL;
        private readonly IMapper _mapper;
        public SpecificationManager(IMapper mapper, ISpecificationDAL specificationDAL)
        {
            _mapper = mapper;
            _specificationDAL = specificationDAL;
        }

        public IResult CreateSpecification(int productId, List<SpecificationAddDTO> specificationAddDTOs)
        {
            var map = _mapper.Map<List<Specification>>(specificationAddDTOs);
            _specificationDAL.AddSpecification(productId, map);
            return new SuccessResult();
        }
    }
}
