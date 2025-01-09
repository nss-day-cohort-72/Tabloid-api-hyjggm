using Microsoft.AspNetCore.Mvc;
using Tabloid.Models;
using Tabloid.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Tabloid.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserProfileController : ControllerBase
{
    private TabloidDbContext _dbContext;

    public UserProfileController(TabloidDbContext context)
    {
        _dbContext = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        return Ok(_dbContext.UserProfiles.ToList());
    }

    [HttpGet("withroles")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetWithRoles()
    {
        return Ok(_dbContext.UserProfiles
        .Include(up => up.IdentityUser)
        .OrderBy(up => up.IdentityUser.UserName)
        .Select(up => new UserProfile
        {
            Id = up.Id,
            FirstName = up.FirstName,
            LastName = up.LastName,
            Email = up.IdentityUser.Email,
            UserName = up.IdentityUser.UserName,
            IdentityUserId = up.IdentityUserId,
            Roles = _dbContext.UserRoles
            .Where(ur => ur.UserId == up.IdentityUserId)
            .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
            .ToList(),
            IsDeactivated = up.IsDeactivated
        }));
    }

    [HttpPost("promote/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Promote(int id)
    {

          // Find the UserProfile by ID
        var userProfile = _dbContext.UserProfiles.SingleOrDefault(up => up.Id == id);
         
          if (userProfile == null)
          {
            return NotFound(new { Message = "UserProfile not found." });
          }
            // Get the corresponding AspNetUsers ID
        string aspNetUserId = userProfile.IdentityUserId;


       

        IdentityRole role = _dbContext.Roles.SingleOrDefault(r => r.Name == "Admin");
        _dbContext.UserRoles.Add(new IdentityUserRole<string>
        {
            RoleId = role.Id,
            UserId = aspNetUserId
        });
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpPost("demote/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Demote(int id)
    {

         // Find the UserProfile by ID
        var userProfile = _dbContext.UserProfiles.SingleOrDefault(up => up.Id == id);
         
          if (userProfile == null)
          {
            return NotFound(new { Message = "UserProfile not found." });
          }
            // Get the corresponding AspNetUsers ID
        string aspNetUserId = userProfile.IdentityUserId;
        
        IdentityRole role = _dbContext.Roles
            .SingleOrDefault(r => r.Name == "Admin");

        IdentityUserRole<string> userRole = _dbContext
            .UserRoles
            .SingleOrDefault(ur =>
                ur.RoleId == role.Id &&
                ur.UserId == aspNetUserId);

        _dbContext.UserRoles.Remove(userRole);
        _dbContext.SaveChanges();
        return NoContent();
    }

    [Authorize]
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        UserProfile user = _dbContext
            .UserProfiles
            .Include(up => up.IdentityUser)
            .SingleOrDefault(up => up.Id == id);

        if (user == null)
        {
            return NotFound();
        }
        user.Email = user.IdentityUser.Email;
        user.UserName = user.IdentityUser.UserName;
        user.Roles = _dbContext.UserRoles
            .Where(ur => ur.UserId == user.IdentityUserId)
            .Select(ur => _dbContext.Roles.SingleOrDefault(r => r.Id == ur.RoleId).Name)
            .ToList();
        
        
        
        return Ok(user);
    }

    [HttpPut("deactivate/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult DeactivateUser(int id)
    {
        var userProfile = _dbContext.UserProfiles.Find(id);
        if (userProfile == null)
        {
            return NotFound(new { Message = "User not found" });
        }

        userProfile.IsDeactivated = true;
        _dbContext.SaveChanges();

        return Ok(new { Message = "User successfully deactivated" });
    }

    [HttpPut("activate/{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult ActivateUser(int id)
    {
        var userProfile = _dbContext.UserProfiles.Find(id);
        if (userProfile == null)
        {
            return NotFound(new { Message = "User not found" });
        }

        userProfile.IsDeactivated = false;
        _dbContext.SaveChanges();

        return Ok(new { Message = "User successfully activated" });
    }


    [HttpPost("{id}/upload-avatar")]
    public async Task<IActionResult> UploadAvatar(int id, [FromForm] IFormFile file)
    {
        var userProfile = _dbContext.UserProfiles.SingleOrDefault(up => up.Id == id);
        if (userProfile == null)
        {
            return NotFound(new { Message = "User profile not found." });
        }

        if (file == null || file.Length == 0)
        {
            return BadRequest(new { Message = "Invalid file." });
        }

        var uploadsFolder = Path.Combine("wwwroot", "uploads", "avatars");
        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
        var filePath = Path.Combine(uploadsFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        // Update the user's profile with the image location
        userProfile.ImageLocation = $"/uploads/avatars/{fileName}";
        _dbContext.SaveChanges();

        return Ok(new { Message = "Avatar uploaded successfully.", ImageLocation = userProfile.ImageLocation });
    }





}