using MediatR;
using System.Collections.Generic;
using Domain;
using Persistence;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;


namespace Application.Activities
{
    public class List
    {
        public class Query: IRequest<List<Activity>>{}   

        public class Handler: IRequestHandler<Query,List<Activity>>
         {
            public readonly DataContext _context;
        
            public Handler(DataContext context)
            {
                _context = context;
             
            }
            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
              
                return await _context.Activities.ToListAsync();
            }
        }
    }
}