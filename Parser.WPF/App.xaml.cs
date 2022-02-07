﻿using Microsoft.Extensions.DependencyInjection;
using Parser.BusinessLayer.Services;
using Parser.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Parser.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
            LoggerConfig.ConfigureNlog();      
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IHtmlService, HtmlService>();
            services.AddSingleton<MainWindow>();
            
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
