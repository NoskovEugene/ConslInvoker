using System.Collections.Generic;
using System.Linq;
using System;
using System.Reflection;

using Microsoft.Extensions.Configuration;
using UI.MessengerUI.Configurations;
namespace UI.MessengerUI.Configurations
{
    public static class ConfigurationConverter
    {


        public static Configuration Convert(IConfigurationSection section)
        {
            var configuration = new Configuration();
            var pattern = section["Pattern"];
            if (pattern == "" || pattern == string.Empty)
            {
                pattern = "$\"message\"";
            }
            configuration.Pattern = pattern;
            return InitProfiles(section,ref configuration);
        }

        private static Configuration InitProfiles(IConfigurationSection configurationSection,ref Configuration configuration)
        {
            foreach (var property in configuration.GetType().GetProperties())
            {
                if (property.PropertyType == typeof(Profile))
                {
                    var profileSection = configurationSection.GetSection(property.Name);
                    
                    if (profileSection.GetChildren().Count() <= 0)
                    {
                        property.SetValue(configuration, new Profile());
                    }
                    else
                    {
                        var profile = GetProfile(configurationSection.GetSection(property.Name));
                        property.SetValue(configuration, profile);
                    }

                }
            }
            return configuration;
        }
        private static Profile GetProfile(IConfigurationSection section)
        {
            var profile = new Profile();
            var props = profile.GetType().GetProperties();
            var foregroundProp = props.Where(x => x.Name == nameof(Profile.ForegroundColor)).First();
            var backgroundProp = props.Where(x => x.Name == nameof(Profile.BackgroundColor)).First();
            SetColor(ref profile, foregroundProp, section[nameof(Profile.ForegroundColor)]);
            SetColor(ref profile, backgroundProp, section[nameof(Profile.BackgroundColor)]);
            return profile;
        }

        private static void SetColor(ref Profile instance, PropertyInfo property, string value)
        {
            if (int.TryParse(value, out var intValue))
            {
                if (intValue > -1 && intValue < 15)
                {
                    property.SetValue(instance, (ConsoleColor)intValue);
                }
            }
            else
            {
                var colors = ((IEnumerable<ConsoleColor>)Enum.GetValues(typeof(ConsoleColor))).Where(x => x.ToString().Equals(value, StringComparison.OrdinalIgnoreCase));
                if (colors.Count() > 0)
                {
                    var color = colors.First();
                    property.SetValue(instance, color);
                }
            }
        }
    }
}