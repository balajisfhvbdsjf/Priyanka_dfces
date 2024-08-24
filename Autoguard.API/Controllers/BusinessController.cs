using Autoguard.Application.DTOs;
using Autoguard.Application.Features.Business.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace Autoguard.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BusinessController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterBusiness(
            [FromForm] BusinessDto businessDto,
            IFormFile psiraDocumentationFile,
            IFormFile businessLogoImage,
            IFormFile cipcFile)
        {
            // Handle file uploads
            if (psiraDocumentationFile != null)
            {
                var psiraPath = Path.Combine("C:\\Users\\hp\\OneDrive\\Pictures", Guid.NewGuid().ToString() + "_" + psiraDocumentationFile.FileName);
                using (var stream = new FileStream(psiraPath, FileMode.Create))
                {
                    await psiraDocumentationFile.CopyToAsync(stream);
                }
                businessDto.PsiraDocumentationFilePath = psiraPath;
            }

            if (businessLogoImage != null)
            {
                var logoPath = Path.Combine("C:\\Users\\hp\\OneDrive\\Pictures", Guid.NewGuid().ToString() + "_" + businessLogoImage.FileName);
                using (var stream = new FileStream(logoPath, FileMode.Create))
                {
                    await businessLogoImage.CopyToAsync(stream);
                }
                businessDto.BusinessLogoImagePath = logoPath;
            }

            if (cipcFile != null)
            {
                var cipcPath = Path.Combine("C:\\Users\\hp\\OneDrive\\Pictures", Guid.NewGuid().ToString() + "_" + cipcFile.FileName);
                using (var stream = new FileStream(cipcPath, FileMode.Create))
                {
                    await cipcFile.CopyToAsync(stream);
                }
                businessDto.CipcFilePath = cipcPath;
            }

            // Register business with command
            var command = new RegisterBusinessCommand(businessDto);
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(RegisterBusiness), new { id = result.BusinessId }, result);
        }
    }
}
