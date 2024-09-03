using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using support_app.Data;
using support_app.Role.Repository;

namespace support_app.Role
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly RoleRepository _roleRepository;

        public RoleController(AppDbContext context, IMapper mapper, RoleRepository roleRepository)
        {
            _context = context;
            _mapper = mapper;
            _roleRepository = roleRepository;
        }
    }
}
