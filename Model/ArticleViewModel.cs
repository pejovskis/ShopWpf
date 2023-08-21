using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuhLadenApp.Model
{
    class ArticleViewModel
    {
        private Article _artikel;

        public ArticleViewModel(Article artikel)
        {
            _artikel = artikel;
        }

        public string ArtikelId
        {
            get { return _artikel.GetArticleId(); }
        }

        public string Name
        {
            get { return _artikel.GetName(); }
            set { _artikel.SetName(value); }
        }

        public string Lieferant
        {
            get { return _artikel.GetSupplier(); }
            set { _artikel.SetSupplier(value); }
        }

        public double Preis
        {
            get { return _artikel.GetPrice(); }
            set { _artikel.SetPrice(value); }
        }

        public int Menge
        {
            get { return _artikel.GetQuantity(); }
            set { _artikel.SetQuantity(value); }
        }
    }
}
