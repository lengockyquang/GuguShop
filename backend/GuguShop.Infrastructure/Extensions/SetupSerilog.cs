using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuguShop.Infrastructure.Extensions
{
    public static class SetupSerilog
    {
        public static ConfigureHostBuilder SetupSerilogHostBuilder(this ConfigureHostBuilder builder)
        {
            builder.UseSerilog((ctx, lc) => lc
                        .WriteTo.Console()
                        .ReadFrom.Configuration(ctx.Configuration)
                    );
            return builder;
        }

        public static WebApplication UseLoggingMiddleware(this WebApplication app)
        {
            app.UseSerilogRequestLogging();
            return app;
        }
    }
}
