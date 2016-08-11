using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;
using NancyDemo_0726.Authorization.User;
using NancyDemo_0726.Authorization;
using Nancy.Testing;
using Nancy.Conventions;
using Nancy.Diagnostics;

namespace NancyDemo_0726.MyBootstrapper
{
    public class MyBootstrapper: DefaultNancyBootstrapper
    {
        protected override DiagnosticsConfiguration DiagnosticsConfiguration
        {
            get
            {
                return new DiagnosticsConfiguration { Password = @"" };
            }
        }
        protected override IRootPathProvider RootPathProvider
        {
            get
            {
                return new RootPathProvider();
            }
        }
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            StaticConfiguration.DisableErrorTraces = false;
            //var bootstrapper = new DefaultNancyBootstrapper();
            //var browser = new Browser(bootstrapper);
            //var result = browser.Get("/", with => { with.HttpRequest(); });
            //this.Conventions.ViewLocationConventions.Add((viewname, model, context) =>
            //{
            //    return string.Concat("custom/", viewname);
            //}); 
            
        }
        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            if (context.Request.Url.ToString() == "http://localhost:4996")
            { }
            else
            {
                string token = context.Request.Headers.Authorization.ToString();
                if (token == "token")
                {
                    User login = new Authorization.User.User { UserName = "zhai.weihao", Id = "1" };
                    var loginresult = new MyUserManager<User, string>( new UserStore<User>()).CreateLoginResult(login);
                    context.CurrentUser = new UserIdentity { UserName = login.UserName, Claims = loginresult.Result.Identity.Claims.Select(o => o.Value) };
                }
                else
                {
                    pipelines.BeforeRequest .AddItemToEndOfPipeline(ctx => ctx.Response = new Response { StatusCode = HttpStatusCode.NotImplemented, ReasonPhrase= "Invalid token" });
                    return;
                }
            }
        }
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);
            //可以访问项目内的静态资源
            //nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory(""));
        }
    }
    public class RootPathProvider : IRootPathProvider
    {
        public string GetRootPath()
        {
            return string.Concat(@"D:\技术\MyProjects\NancyDemo_0726\NancyDemo_0726");
        }
    }
    public class DiagnosticsProvider : IDiagnosticsProvider
    {
        public DiagnosticsProvider(string description,object diagnosticobject,string name)
        {
            Description = description;
            DiagnosticObject = diagnosticobject;
            Name = name;
        }
        public string Description { get; private set; }
        public object DiagnosticObject { get; private set; }
        public string Name { get; private set; }
        
    }
}