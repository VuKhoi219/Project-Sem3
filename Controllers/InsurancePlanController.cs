using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Sem3.Data;
using Project_Sem3.Models;

namespace Project_Sem3.Controllers;

    [ApiController]
[Route("api/[controller]")]
public class InsurancePlanController : ControllerBase
{
    private readonly MyDbContext _context;

    public InsurancePlanController(MyDbContext context)
    {
        _context = context;
    }

    // Get all insurance plans
    [HttpGet]
    public async Task<IActionResult> GetPlans()
    {
        var plans = await _context.InsurancePlans.ToListAsync();
        return Ok(plans);
    }

    // Get insurance plan by id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPlan(int id)
    {
        var plan = await _context.InsurancePlans.FindAsync(id);
        if (plan == null) return NotFound();
        return Ok(plan);
    }

    // Create a new insurance plan
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreatePlan([FromBody] InsurancePlan plan)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        _context.InsurancePlans.Add(plan);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Insurance plan created successfully!" });
    }

    // Update an existing insurance plan
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdatePlan(int id, [FromBody] InsurancePlan updatedPlan)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var plan = await _context.InsurancePlans.FindAsync(id);
        if (plan == null) return NotFound();

        plan.Name = updatedPlan.Name;
        plan.Description = updatedPlan.Description;
        plan.Premium = updatedPlan.Premium;
        plan.CoverageAmount = updatedPlan.CoverageAmount;

        await _context.SaveChangesAsync();
        return Ok(new { message = "Insurance plan updated successfully!" });
    }

    // Delete an insurance plan
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeletePlan(int id)
    {
        var plan = await _context.InsurancePlans.FindAsync(id);
        if (plan == null) return NotFound();

        _context.InsurancePlans.Remove(plan);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Insurance plan deleted successfully!" });
    }

    // Calculate premium based on the plan
    [HttpGet("calculate-premium/{id}/{multiplier}")]
    public async Task<IActionResult> CalculatePremium(int id, decimal multiplier)
    {
        var plan = await _context.InsurancePlans.FindAsync(id);
        if (plan == null) return NotFound();

        var calculatedPremium = plan.Premium * multiplier;
        return Ok(new { PlanName = plan.Name, CalculatedPremium = calculatedPremium });
    }
}
