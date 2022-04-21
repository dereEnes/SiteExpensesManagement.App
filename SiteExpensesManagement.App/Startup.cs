using AutoMapper;
using FluentValidation.AspNetCore;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SiteExpensesManagement.App.Business.Abstracts;
using SiteExpensesManagement.App.Business.Concretes;
using SiteExpensesManagement.App.Business.Validations.CarValidations;
using SiteExpensesManagement.App.Business.Validations.FluentValidation.ApartmentValidations;
using SiteExpensesManagement.App.Business.Validations.FluentValidation.ApplicationUserValidations;
using SiteExpensesManagement.App.Business.Validations.FluentValidation.BillValidations;
using SiteExpensesManagement.App.Business.Validations.FluentValidation.CarValidations;
using SiteExpensesManagement.App.Business.Validations.FluentValidation.CreditCardValidations;
using SiteExpensesManagement.App.Business.Validations.FluentValidation.DuesValidations;
using SiteExpensesManagement.App.Business.Validations.FluentValidation.MessageValidations;
using SiteExpensesManagement.App.Business.Validations.FluentValidation.PaymentValidations;
using SiteExpensesManagement.App.Business.Validations.FluentValidation.RoomTypeValidations;
using SiteExpensesManagement.App.DataAccess.EntityFramework;
using SiteExpensesManagement.App.DataAccess.EntityFramework.Repository.Abstracts;
using SiteExpensesManagement.App.DataAccess.EntityFramework.Repository.Concretes;
using SiteExpensesManagement.App.Domain.Entities;
using System;

namespace SiteExpensesManagement.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<CreditCardValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<ApartmentForAddDtoValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<BillForAddDtoValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<BillForUpdateDtoValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<DuesForAddDtoValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<DuesForUpdateDtoValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<CarForAddDtoValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<CarForUpdateDtoValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<MessageForAddDtoValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<MessageForUpdateDtoValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<RoomTypeForAddDtoValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<PaymentForAddDtoValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<ApplicationUserValidator>();
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser,IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IApartmentService, ApartmentService>();
            services.AddTransient<IRoomTypeService, RoomTypeService>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<IMessageService, MessageService>();
            services.AddTransient<IBillService, BillService>();
            services.AddTransient<IDuesService, DuesService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IBillPaymentService, BillPaymentService>();
            services.AddTransient<IDuesPaymentService, DuesPaymentService>();

            services.AddHttpClient();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.ConfigureCustomExceptionMiddleware();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
