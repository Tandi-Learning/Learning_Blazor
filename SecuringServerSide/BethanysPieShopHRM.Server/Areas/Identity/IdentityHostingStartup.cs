// *****
// This identity registration logic should belong in the IDP project
// *****
// using System;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.AspNetCore.Identity;
// //using Microsoft.AspNetCore.Identity.UI;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using BethanysPieShopHRM.Data;
//
// [assembly: HostingStartup(typeof(BethanysPieShopHRM.Server.Areas.Identity.IdentityHostingStartup))]
// namespace BethanysPieShopHRM.Server.Areas.Identity
// {
//     public class IdentityHostingStartup : IHostingStartup
//     {
//         public void Configure(IWebHostBuilder builder)
//         {
//             builder.ConfigureServices((context, services) => {
//                 services.AddDbContext<ApplicationDbContext>(options =>
//                 {
//                     options.UseSqlite(context.Configuration.GetConnectionString("IdentityContextConnection"));
//                 });
//
//                 services.AddDefaultIdentity<IdentityUser>(options =>
//                 {
//                    options.SignIn.RequireConfirmedAccount = true;
//                 })
//                 .AddEntityFrameworkStores<ApplicationDbContext>();
//             });
//         }
//     }
// }