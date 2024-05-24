﻿using _7Lab.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace _7Lab.Services.Implementations
{
    public class ViewsManager : IViewsManager
    {
        private readonly IServiceProvider _serviceProvider;
        private Window _current;

        public ViewsManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Window Current => _current;

        public void Open<TView>(object? dataContext = null) where TView : Window
        {
            _current?.Close();
            _current = _serviceProvider.GetRequiredService<TView>();
            _current.DataContext = dataContext ?? _serviceProvider.GetRequiredService<TView>().DataContext;
            _current.Show();
        }
    }
}
