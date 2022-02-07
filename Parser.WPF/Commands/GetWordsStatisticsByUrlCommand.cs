using Parser.BusinessLayer.Models;
using Parser.BusinessLayer.Services;
using Parser.Core.Enum;
using Parser.WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Parser.WPF.Commands
{
    public class GetWordsStatisticsByUrlCommand : CommandBase
    {
        private readonly WordViewModel _viewModel;
        private readonly IHtmlService _service;

        public GetWordsStatisticsByUrlCommand(WordViewModel viewModel, IHtmlService service)
        {
            _viewModel = viewModel;
            _service = service;
        }

        public override void Execute(object parameter)
        {
            var words = _service.GetWordsStatisticsByUrl(_viewModel.TextBoxUrl);

            if (words.Status == Status.bad)
            {
                MessageBox.Show($"{words.Message}", "неправильный формат", MessageBoxButton.OK);
            }

            else
            {
                foreach (var word in words.Body)
                {
                    _viewModel.Words.Add(word);
                }
            }
        }
    }
}
