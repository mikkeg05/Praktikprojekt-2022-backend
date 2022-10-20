//using System.Web.Http;
//using System.Web.Http.Cors;
//using Umbraco.Core;
//using Umbraco.Core.Composing;



//namespace SpaceDebris.Web.Composers
//{

//    [RuntimeLevel(MinLevel = RuntimeLevel.Boot)]
//    public class CorsComposer : IUserComposer
//    {
//        public void Compose(Composition composition)
//        {
//            GlobalConfiguration.Configure(Register);
//        }


//        public static void Register(HttpConfiguration config)
//        {
//            var corsAttr = new EnableCorsAttribute("http://localhost:3000/", "*", "*");
//            config.EnableCors(corsAttr);
//        }
//    }

//}