using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Дипломная_работа.View;

namespace Дипломная_работа.ViewModel
{
    internal class MainViewModel : ViewModelBase
    {

        private Page mains = new MainPage();
        private Page user = new UsersPage();
        private Page order = new OrderPage();
        private Page worker = new WorkerPage();
        private Page client = new ClientPage();
        private Page auto = new AutoparkPage();
        private Page vod = new VodetelPage();
        private Page trans = new TransportPage();

        private Page _CurPage = new MainPage();

        public Page CurPage
        {
            get => _CurPage;
            set => Set(ref _CurPage, value);
        }

        public ICommand OpenUserPage
        {
            get
            {
                return new RelayCommand(() => CurPage = user);
            }
        }

        public ICommand OpenOrderPage
        {
            get
            {
                return new RelayCommand(() => CurPage = order);
            }
        }

        public ICommand OpenWorkerPage
        {
            get
            {
                return new RelayCommand(() => CurPage = worker);
            }
        }

        public ICommand OpenClientPage
        {
            get
            {
                return new RelayCommand(() => CurPage = client);
            }
        }

        public ICommand OpenAutoPage
        {
            get
            {
                return new RelayCommand(() => CurPage = auto);
            }
        }

        public ICommand OpenVodPage
        {
            get
            {
                return new RelayCommand(() => CurPage = vod);
            }
        }

        public ICommand OpenTransPage
        {
            get { return new RelayCommand(() => CurPage = trans); }
        }

        public ICommand OpenMainPage
        {
            get
            {
                return new RelayCommand(() => CurPage = mains);
            }
        }

    }

}
