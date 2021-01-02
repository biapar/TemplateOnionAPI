﻿using AutoMapper;
using $safeprojectname$.Filters;
using $safeprojectname$.Interfaces;
using $safeprojectname$.Interfaces.Repositories;
using $safeprojectname$.Wrappers;
using $ext_projectname$.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace $safeprojectname$.Features.Positions.Queries.GetPositions
{
    public class GetPositionsQuery : QueryParameter, IRequest<PagedResponse<IEnumerable<Entity>>>
    {
        public string PositionNumber { get; set; }
        public string PositionTitle { get; set; }

    }
    public class GetAllPositionsQueryHandler : IRequestHandler<GetPositionsQuery, PagedResponse<IEnumerable<Entity>>>
    {
        private readonly IPositionRepositoryAsync _positionRepository;
        private readonly IMapper _mapper;
        private readonly IModelHelper _modelHelper;
        public GetAllPositionsQueryHandler(IPositionRepositoryAsync positionRepository, IMapper mapper, IModelHelper modelHelper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
            _modelHelper = modelHelper;
        }

        public async Task<PagedResponse<IEnumerable<Entity>>> Handle(GetPositionsQuery request, CancellationToken cancellationToken)
        {

            //filtered fields security
            if (!string.IsNullOrEmpty(request.Fields))
            {
                //limit to fields in view model
                validFilter.Fields = _modelHelper.ValidateModelFields<GetPositionsViewModel>(request.Fields);

            }
            if (string.IsNullOrEmpty(request.Fields))
            {
                //default fields from view model
                validFilter.Fields = _modelHelper.GetModelFields<GetPositionsViewModel>();
            }
            // query based on filter
            var entityPositions = await _positionRepository.GetPagedPositionReponseAsync(request);
            // response wrapper
            return new PagedResponse<IEnumerable<Entity>>(entityPositions, request.PageNumber, request.PageSize);
        }
    }
}
