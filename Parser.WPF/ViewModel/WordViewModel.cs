using Parser.BusinessLayer.Models;
using Parser.BusinessLayer.Services;
using Parser.WPF.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Parser.WPF.ViewModel
{
    public class WordViewModel : INotifyPropertyChanged
    {

        private readonly IHtmlService _service;

        public ICommand GetWordsStatisticsByUrlCommand { get; set; }        

        public ObservableCollection<WordModel> Words { get; set; }

        public WordViewModel()
        {
            _service = new HtmlService();

            GetWordsStatisticsByUrlCommand = new GetWordsStatisticsByUrlCommand(this, _service);

            Words = new ObservableCollection<WordModel>();
        }

        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private int _count;
        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                OnPropertyChanged();
            }
        }

        private string _textBoxUrl;
        public string TextBoxUrl
        {
            get => _textBoxUrl;
            set
            {
                _textBoxUrl = value;
                OnPropertyChanged(nameof(TextBoxUrl));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
