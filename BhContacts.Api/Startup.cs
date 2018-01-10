using BhContacts.Api.Filters;
using BhContacts.DataAccess.Contact;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;


namespace BhContacts.Api
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

            services.AddMvcCore()
                .AddJsonFormatters();

            services.AddMvc(option =>
                {
                    option.Filters.Add(new ExceptionHandlerAttribute());
                    option.Filters.Add(new ValidateModelAttribute());
                })
                .AddJsonOptions(opts =>
                {
                    // Force Camel Case to JSON
                    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new Info
                    {
                        Title = "BH Contacts API V1",
                        Version = "v1"
                    });
                });

            //IoC to Data Access
            services.AddTransient<IContactService, ContactService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:5001");
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();
            });

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BH Contacts API V1");
                });

                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
