using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebApplication1.Model;

namespace WebApplication1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //服务
            //AddMvc调用会调用包含所有必须的MVC服务。也包含MVC Core,而MVC Core 调用最核心的Mvc服务
            services.AddMvc();
            //services.AddMvcCore();
            //将学生接口和接口实现使用依赖注入方式关联起来，目前好处就是低耦合，数据源可以随时更改为其他方式。
            //这么做的原因是因为程序不知道哪个实现类实现了学生接口，使用这种方式将他们绑定起来，程序才可以解析。
            services.AddSingleton<IStudentRepository, MockStudentRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                //使用开发者异常页面中间件
                app.UseDeveloperExceptionPage();
            }
            //使用默认页面中间件，需放在静态文件中间件前，作用：指定默认加载静态网页
            //app.UseDefaultFiles("");
            //使用静态文件中间件
            app.UseStaticFiles();
            //调用mvc默认带路由中间件
            app.UseMvcWithDefaultRoute();

            //app.UseMvc();

            //摘要:向应用程序的请求管道中添加一个内联定义的中间件委托。(向管道中添加一个中间件)
            //app.Use(async (context, next) =>
            //{
            //    //将响应的文本类型改成utf-8
            //    context.Response.ContentType = "text/plain;charset=utf-8";
            //    //当前的进程名称
            //    //var processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            //    //await context.Response.WriteAsync(processName);
            //    logger.LogInformation("请求");
            //    //通过委托的方法调用下一个中间件
            //    // middleware:
            //    // A function that handles the request or calls the given next function.
            //    await next();
            //    logger.LogInformation("响应");
            //});
            //app.Run(async (context) =>
            //{
            //    context.Response.ContentType = "text/plain;charset=utf-8";
            //    //logger.LogInformation("处理响应");
            //    await context.Response.WriteAsync("环境："+env.EnvironmentName);
            //});
        }
    }
}
