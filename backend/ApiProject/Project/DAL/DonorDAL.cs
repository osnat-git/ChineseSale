using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project.DAL.Interfaces;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Project.DAL
{
    public class DonorDAL : IDonorDAL
    {
        private readonly AppDBContext dbContext;
        private readonly ILogger<DonorDAL> logger;

        public DonorDAL(AppDBContext dbContext, ILogger<DonorDAL> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }
        // Helper method to check if raffle has occurred
        private async Task<bool> HasRaffleOccurredAsync()
        {
            return await dbContext.Winner.AnyAsync();
        }
        // צפיה ברשימת התורמים עם פרטי המתנות של כל תורם
        public async Task<Result<Donor>> GetAllDonorsAsync()
        {
            try
            {
                // אולי כדאי להוסיף הדפסה לפני ההחזרה
                var donors = await dbContext.Donor
                    //.Include(d => d.Present) // כולל את רשימת התרומות של כל תורם
                    .ToListAsync();

                return new Result<Donor>
                {
                    Success = true,
                    Message = "Fetched all donors successfully.",
                    Data = donors // מחזירים את רשימת התורמים
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error fetching all donors.");
                return new Result<Donor>
                {
                    Success = false,
                    Message = "Error fetching all donors: " + ex.Message,
                    Data = Enumerable.Empty<Donor>() // מחזירים רשימה ריקה במקרה של שגיאה
                };
            }
        }
        // פונקצית עזר לבדיקת מייל כפול
        public async Task<bool> existingEmail(string email)
        {
            try
            {
                var existingDonor = await dbContext.Donor
                    .FirstOrDefaultAsync(d => d.Email == email);

                if (existingDonor != null)
                {
                    // אם יש כבר תורם עם האימייל הזה
                    logger.LogWarning($"Donor with email {email} already exists.");
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Donor {email}");
                return true;
            }
        }
        // הוספת תורם
        public async Task<Result<Donor>> AddDonorAsync(Donor donor)
        {
            try
            {
                // הוספת התורם למסד נתונים
                await dbContext.Donor.AddAsync(donor);
                await dbContext.SaveChangesAsync();
                logger.LogInformation($"Donor with email {donor.Email} added successfully.");

                return new Result<Donor>
                {
                    Success = true,
                    Message = $"Donor with email {donor.Email} added successfully.",
                    Data = null  // לא נדרש להחזיר נתונים נוספים
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error adding donor with email {donor.Email}.");
                return new Result<Donor>
                {
                    Success = false,
                    Message = $"Error adding donor with email {donor.Email}: {ex.Message}",
                    Data = null
                };
            }
        }


        // עדכון תורם
        public async Task<Result<Donor>> UpdateDonorAsync(Donor donor)
        {
            try
            {
                var d = dbContext.Donor.FirstOrDefault(d => d.Id == donor.Id);
                if (d == null)
                {
                    return new Result<Donor>
                    {
                        Success = false,
                        Message = $"Donor {donor.Email}",
                        Data = null
                    };
                }
                if(d.Name != donor.Name)
                    d.Name = donor.Name;
                if (d.Email != donor.Email)
                    d.Email = donor.Email;
                if (d.Phone != donor.Phone)
                    d.Phone = donor.Phone;

                dbContext.Donor.Update(d);
                await dbContext.SaveChangesAsync();
                logger.LogInformation($"Donor with email {donor.Email} updated successfully.");

                return new Result<Donor>
                {
                    Success = true,
                    Message = $"Donor with email {donor.Email} updated successfully.",
                    Data = null  // לא נדרש להחזיר נתונים נוספים
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error updating donor with email {donor.Email}.");
                return new Result<Donor>
                {
                    Success = false,
                    Message = $"Error updating donor with email {donor.Email}: {ex.Message}",
                    Data = null
                };
            }
        }


        // מחיקת תורם
        public async Task<Result<Donor>> RemoveDonorAsync(int id)
        {
            try
            {
                var donor = await dbContext.Donor.FindAsync(id);
                if (donor != null)
                {
                    dbContext.Donor.Remove(donor);
                    await dbContext.SaveChangesAsync();
                    logger.LogInformation($"Donor with id {id} removed successfully.");

                    return new Result<Donor>
                    {
                        Success = true,
                        Message = $"Donor with id {id} removed successfully.",
                        Data = null
                    };
                }
                else
                {
                    logger.LogWarning($"Donor with id {id} not found.");
                    return new Result<Donor>
                    {
                        Success = false,
                        Message = $"Donor with id {id} not found.",
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error removing donor with id {id}.");
                return new Result<Donor>
                {
                    Success = false,
                    Message = $"Error removing donor with id {id}: {ex.Message}",
                    Data = null
                };
            }
        }


        // סינון תורם לפי מייל
        public async Task<Result<Donor>> GetDonorsByEmailAsync(string email)
        {
            try
            {
                var donors = await dbContext.Donor
                    .Where(d => d.Email.Contains(email)) // חיפוש גמיש לפי מייל
                    //.Include(d => d.Presents)
                    .ToListAsync();

                return new Result<Donor>
                {
                    Success = true,
                    Message = $"Fetched donors matching email '{email}' successfully.",
                    Data = donors
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error fetching donors by email {email}.");
                return new Result<Donor>
                {
                    Success = false,
                    Message = $"Error fetching donors by email {email}: {ex.Message}",
                    Data = Enumerable.Empty<Donor>()
                };
            }
        }


        // סינון תורמים לפי שם
        public async Task<Result<Donor>> GetDonorsByNameAsync(string name)
        {
            try
            {
                var donors = await dbContext.Donor
                    .Where(d => d.Name.Contains(name)) // חיפוש גמיש לפי שם
                    //.Include(d => d.Presents)
                    .ToListAsync();

                return new Result<Donor>
                {
                    Success = true,
                    Message = $"Fetched donors matching name '{name}' successfully.",
                    Data = donors
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error fetching donors by name {name}.");
                return new Result<Donor>
                {
                    Success = false,
                    Message = $"Error fetching donors by name {name}: {ex.Message}",
                    Data = Enumerable.Empty<Donor>()
                };
            }
        }


        // סינון תורמים לפי שם מתנה
        public async Task<Result<Donor>> GetDonorsByPresentNameAsync(string presentName)
        {
            try
            {
                // סינון תורמים לפי שם המתנה
                var donors = await dbContext.Donor
                    .Where(d => dbContext.Present.Any(p => p.DonorId == d.Id && p.Name.Contains(presentName)))
                    .ToListAsync();  // מחזיר את התוצאות בצורה אסינכרונית

                return new Result<Donor>
                {
                    Success = true,
                    Message = $"Fetched donors for present name '{presentName}' successfully.",
                    Data = donors
                };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error fetching donors by present name {presentName}.");
                return new Result<Donor>
                {
                    Success = false,
                    Message = $"Error fetching donors by present name '{presentName}': {ex.Message}",
                    Data = Enumerable.Empty<Donor>()  // מחזירים רשימה ריקה במקרה של שגיאה
                };
            }
        }
    }
}