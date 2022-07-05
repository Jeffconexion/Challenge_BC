﻿using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebApi.Application.CustomerServices;
using WebApi.Application.ICustomerServices;
using WebApi.Core.IRepository;
using WebApi.Infrastructure.Context;
using WebApi.Infrastructure.ExternalServices;
using WebApi.Infrastructure.ExternalServices.IExternalServices;
using WebApi.Infrastructure.Repository;
using WebApi.RegisterCustomer.Validations;

namespace WebApi.RegisterCustomer
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

      services.AddDbContext<DataContext>(options =>
      {
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
      });

      services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CustomerValidator>());


      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi.RegisterCustomer", Version = "v1" });
      });

      services.AddScoped<DataContext>();
      services.AddScoped<IRepositoryCustomer, RepositoryCustomer>();
      services.AddScoped<ICustomerService, CustomerService>();
      services.AddScoped<IExternalHttpManagerServices, ExternalHttpManagerServices>();
      services.AddScoped<IPostalCodeServices, PostalCodeServices>();


    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi.RegisterCustomer v1"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}