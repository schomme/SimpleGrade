using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleGradeApi.Data;

namespace SimpleGradeApi.Controllers
{
    public abstract class ControllerBase : Controller
    {
        private AppDbContext _context;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ControllerBase(AppDbContext context, ILogger logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }
        public AppDbContext Context => _context;
        public ILogger Logger => _logger;
        public IMapper Mapper => _mapper;
    }
}
