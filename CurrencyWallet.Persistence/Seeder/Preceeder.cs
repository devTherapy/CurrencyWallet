using CurrencyWallet.Domain.Entities;
using CurrencyWallet.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyWallet.Persistence.Seeder
{
    public static class Preceeder
    {
        public static async Task SeedDB(CurrencyWalletDbContext ctx, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            await ctx.Database.EnsureCreatedAsync();
            var roles = new List<String>() { "Noob", "Elite", "Admin" };

            if (!roleManager.Roles.Any())
            {
                for (int i = 0; i < roles.Count; i++)
                {
                    var role = new IdentityRole(roles[i]);
                    await roleManager.CreateAsync(role);
                }

            }

            //seed merchants

            //seed users
            var Users = TransformJSONtoPOCO<ApplicationUser>("Users.json");
            if (!ctx.Users.Any())
            {
                int counter = 0;
                foreach (var user in Users)
                {
                    var result = await userManager.CreateAsync(user, "P@ssword");
                    if (!result.Succeeded)
                    {
                        HandlePreSeederError(result);
                    }
                    if (counter == 1) {
                        await userManager.AddToRoleAsync(user, roles[0]);
                    }
                    else if (counter == 2)
                    {
                        await userManager.AddToRoleAsync(user, roles[1]);
                    }

                    else
                    {
                        await userManager.AddToRoleAsync(user, roles[2]);

                    }


                    await userManager.AddToRoleAsync(user, roles[1]);
                    counter++;
                }
            }

        }

        /// <summary>
        /// Show errors if issues when adding user to database
        /// </summary>
        /// <param name="result"></param>
        /// <param name="userType"></param>
        private static void HandlePreSeederError(IdentityResult result)
        {
            var errMsg = "";
            foreach (var error in result.Errors)
            {
                errMsg += error.Description;
            }
            throw new Exception(errMsg);
        }

        private static  List<Tmodel> TransformJSONtoPOCO<Tmodel>(string json)
        {
            var path = Path.GetFullPath(@"../CurrencyWallet.Persistence/Seeder/" + json);
            return JsonConvert.DeserializeObject<List<Tmodel>>(File.ReadAllText(path));
        }

    }
}

