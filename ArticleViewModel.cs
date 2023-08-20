using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchuhLadenApp
{
    class ArticleViewModel
    {
        private Artikel _artikel;

        public ArticleViewModel(Artikel artikel)
        {
            _artikel = artikel;
        }

        public string ArtikelId
        {
            get { return _artikel.getArtikelId(); }
            set { _artikel.setArtikelId(value); }
        }

        public string Name
        {
            get { return _artikel.getName(); }
            set { _artikel.setName(value); }
        }

        public string Lieferant
        {
            get { return _artikel.getLieferant(); }
            set { _artikel.setLieferant(value); }
        }

        public double Preis
        {
            get { return _artikel.getPreis(); }
            set { _artikel.setPreis(value); }
        }

        public int Menge
        {
            get { return _artikel.getMenge(); }
            set { _artikel.setMenge(value); }
        }
    }
}
