using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAPI.Modules.Items;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MediatR;
using System.Reflection;

namespace CoreAPI
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
            services.AddDbContext<ItemContext>(o => o.UseSqlServer(Configuration.GetConnectionString("ItemsConnection")));

            services.AddScoped<IItemsRepository, ItemsRepository>();
            //services.AddScoped(typeof(IItemsRepository), typeof(ItemsRepository));
            services.AddScoped<IRequestHandler<GetItemsListQuery, IEnumerable<ItemDto>>, GetItemsListQueryHandler>();
            services.AddScoped<IRequestHandler<GetItemQuery, ItemDto>, GetItemQueryHandler>();
            services.AddScoped<IRequestHandler<AddItemCommand, MediatR.Unit>, AddItemCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateItemCommand, MediatR.Unit>, UpdateItemCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteItemCommand, MediatR.Unit>, DeleteItemCommandHandler>();
            services.AddMediatR(typeof(Startup));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CoreAPI", Version = "v1" });
                c.CustomSchemaIds(i => i.FullName);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline. Test
        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoreAPI");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
