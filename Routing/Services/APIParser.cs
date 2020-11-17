using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Routing.Extensions;
using Routing.Models;
using Shared.Attributes;
using Shared.Extensions;

namespace Routing.Services
{
    public class APIParser
    {

        protected IStringService StringService { get; set; }

        public Utility GetApiMap<T>()
        {
            var type = typeof(T);
            var utilityAttribute = type.GetCustomAttribute<UtilityAttribute>();
            var parserAttribute = type.GetCustomAttribute<ParserAttribute>();
            if (utilityAttribute != null)
            {
                var utility = new Utility
                {
                    UtilityType = type,
                    Name = utilityAttribute.UtilityName,
                };

                if(parserAttribute != null)
                {
                    utility.ParserExists = true;
                    utility.ParserType = parserAttribute.Parser;
                }

                var methods = type.GetMethods();
                methods.Foreach(method =>
                {
                    var routAttribute = method.GetCustomAttribute<RoutAttribute>();
                    if (routAttribute != null)
                    {
                        var rout = GetRout(method, utility.Name, routAttribute);
                        rout.Class = type;
                        utility.Routs.Add(rout);
                    }
                });
                return utility;
            }
            return null;
        }


        private Rout GetRout(MethodInfo method, string utilityName, RoutAttribute attribute)
        {
            var apiMethodName = attribute.CommandName;
            var parametersLine = attribute.Parameters;
            var parameters = new List<Parameter>();
            var selectableParameters = new List<Parameter>();

            var rout = new Rout()
            {
                Method = method,
                Name = apiMethodName
            };

            var id = StringService.AddProfile();
            StringService.SetInputLine(id, parametersLine, x => { parametersLine = x; })
                         .SetRemoveStat(id, true)
                         .SetPattern(id, @"\{.+?\}");
            var res = StringService.Next(id);
            while (res.success)
            {
                var parameter = new Parameter();
                parameter.IsSelectable = true;
                parameter.SelectableValues = GetParams<string>(res.output, x => x);
                selectableParameters.Add(parameter);
                res = StringService.Next(id);
            }

            if (parametersLine.MultiContains("[", "]"))
            {
                parameters = GetParams<Parameter>(parametersLine, x => new Parameter() { Name = x });
            }

            parameters.AddRange(selectableParameters);
            var methodParams = method.GetParameters();
            if (parameters.Count() == methodParams.Count())
            {
                for (int i = 0; i < methodParams.Count(); i++)
                {
                    var methodParam = methodParams[i];
                    if (parameters[i].IsSelectable)
                    {
                        parameters[i].Name = methodParam.Name;
                    }
                    parameters[i].ParameterInfo = methodParam;
                    parameters[i].ParameterType = methodParam.ParameterType;
                }
            }
            StringService.RemoveProfile(id);
            rout.Parameters = parameters;
            return rout;
        }

        private List<T> GetParams<T>(string input, Func<string, T> creator)
        {
            var outLst = new List<T>();
            var id = StringService.AddProfile();
            StringService.SetInputLine(id, input, x => input = x)
                         .SetRemoveStat(id, true)
                         .SetPattern(id, @"\[.+?\]");
            var res = StringService.Next(id);
            while (res.success)
            {
                outLst.Add(creator(res.output));
                res = StringService.Next(id);
            }
            StringService.RemoveProfile(id);
            return outLst;
        }

    }
}